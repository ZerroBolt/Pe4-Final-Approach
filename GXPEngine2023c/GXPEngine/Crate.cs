using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class Crate : Sprite
    {
        PlayerData data;

        List<LineSegment> horLines;
        List<LineSegment> vertLines;

        Player player;

        public Vec2 position;
        public Vec2 velocity = new Vec2(0, 0);

        float earliestTOIHor;
        float earliestTOIVert;

        bool gravityInverted = false;

        LineSegment top;
        LineSegment left;
        LineSegment right;
        LineSegment bottom;
        
        public Crate(Vec2 pos) : base("square.png", false, true)
        {
            data = ((MyGame)game).playerData;

            horLines = ((MyGame)game).horLines;
            vertLines = ((MyGame)game).vertLines;



            SetColor(1, 0, 0);

            position = pos;

            x = position.x;
            y = position.y;

            SetOrigin(width/2, height/2);

            top = new LineSegment(new Vec2(x - width/2 + 1, y - height/2), new Vec2(x + width/2 - 1, y - height/2));
            left = new LineSegment(new Vec2(x - width/2, y - height/2 + 1), new Vec2(x - width/2, y + height/2 - 1));
            right = new LineSegment(new Vec2(x + width/2, y - height/2 + 1), new Vec2(x + width/2, y + height/2 - 1));
            bottom = new LineSegment(new Vec2(x - width/2 + 1, y + height/2), new Vec2(x + width/2 - 1, y + height/2));
            horLines.Add(top);
            vertLines.Add(left);
            vertLines.Add(right);
            horLines.Add(bottom);
            ((MyGame)game).AddChild(top);
            ((MyGame)game).AddChild(left);
            ((MyGame)game).AddChild(right);
            ((MyGame)game).AddChild(bottom);
        }

        void Update()
        {
            if (player == null)
            {
                player = ((MyGame)game).FindObjectOfType<Player>();
            }
            else
            {
                Move();
                UpdatePosition();
                UpdateLines();
            }
        }

        void Move()
        {
            Gravity();
            Collisions();
            CheckObjectCollisions();
        }

        void Gravity()
        {
            if (!gravityInverted)
            {
                velocity += data.playerGravity;
            }
            else
            {
                velocity -= data.playerGravity;
            }
        }

        void Collisions()
        {
            Vec2 newPos = position + velocity;

            LineSegment otherHor = EarliestCollisionHor(newPos);
            LineSegment otherVert = EarliestCollisionVert(newPos);

            if (otherHor != null)
            {
                if (position.y < otherHor.start.y)
                {
                    position.y = otherHor.start.y - height / 2;
                    velocity.y = 0;
                }
                else if (position.y > otherHor.start.y)
                {
                    position.y = otherHor.start.y + height / 2;
                    velocity.y = 0;
                }
            }
            else
            {
                position.y += velocity.y;
            }

            if (otherVert != null)
            {
                Console.WriteLine("col");
                if (position.x < otherVert.start.x)
                {
                    position.x = otherVert.start.x - width / 2 - 5;
                    velocity.x = 0;
                }
                else if (position.x > otherVert.start.x)
                {
                    position.x = otherVert.start.x + width / 2 + 5;
                    velocity.x = 0;
                }
            }
            position.x += velocity.x;
            velocity.x = 0;
        }

        LineSegment EarliestCollisionHor(Vec2 newPos)
        {
            earliestTOIHor = 1;

            LineSegment other = null;

            foreach (LineSegment line in horLines)
            {
                if (Mathf.Abs(DistanceCalc(line, position)) < height / 2 && IsOnSegment(newPos, width / 2, line) && line != top && line != bottom)
                {
                    float oldDistance = DistanceCalc(line, position);
                    float newDistance = DistanceCalc(line, newPos);
                    float toi = Vec2.TOI(oldDistance, height / 2, newDistance);
                    if (toi < earliestTOIHor)
                    {
                        earliestTOIHor = toi;
                        other = line;
                    }
                }
            }

            return other;
        }

        LineSegment EarliestCollisionVert(Vec2 newPos)
        {
            earliestTOIVert = 1;

            LineSegment other = null;

            foreach (LineSegment line in vertLines)
            {
                if (Mathf.Abs(DistanceCalc(line, position)) < width && IsOnSegment(newPos, height / 2, line) && line != left && line != right)
                {
                    float oldDistance = DistanceCalc(line, position);
                    float newDistance = DistanceCalc(line, newPos);
                    float toi = Vec2.TOI(oldDistance, width / 2, newDistance);
                    if (toi < earliestTOIVert)
                    {
                        earliestTOIVert = toi;
                        other = line;
                        //Console.WriteLine(toi);
                    }
                }
            }

            return other;
        }

        float DistanceCalc(LineSegment line, Vec2 pos)
        {
            Vec2 diffVec = pos - line.start;
            Vec2 lineVec = line.end - line.start;
            Vec2 normalVec = lineVec.Normal();
            return diffVec.Dot(normalVec);
        }

        bool IsOnSegment(Vec2 newPos, float edgeDistance, LineSegment line)
        {
            Vec2 poi = position + velocity * Vec2.TOI(DistanceCalc(line, position), edgeDistance, DistanceCalc(line, newPos));
            Vec2 diffVec = poi - line.start;
            Vec2 lineVec = line.end - line.start;
            float distanceAlongLine = diffVec.Dot(lineVec.Normalized());

            if (distanceAlongLine + edgeDistance > 0 && distanceAlongLine - edgeDistance < lineVec.Length())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        void CheckObjectCollisions()
        {
            gravityInverted = false;

            GameObject[] collisions = GetCollisions();
            foreach (GameObject col in collisions)
            {
                if (col is GravityZone)
                {
                    GravityZone gravityZone = col as GravityZone;
                    if (gravityZone.active)
                    {
                        gravityInverted = true;
                    }
                }

                if (col is PullingBeam)
                {
                    if (Input.GetMouseButton(0))
                    {
                        if (player.position.x < position.x)
                        {
                            velocity.x = -data.pushAndPullSpeed;
                        }
                        else if (player.position.x > position.x)
                        {
                            velocity.x = data.pushAndPullSpeed;
                        }
                    }
                    else if (Input.GetMouseButton(1))
                    {
                        if (player.position.x < position.x)
                        {
                            velocity.x = data.pushAndPullSpeed;
                        }
                        else if (player.position.x > position.x)
                        {
                            velocity.x = -data.pushAndPullSpeed;
                        }
                    }
                }
            }
        }

        void UpdatePosition()
        {
            x = position.x;
            y = position.y;
        }

        void UpdateLines()
        {
            top.start = new Vec2(x - width / 2 + 1, y - height / 2);
            top.end = new Vec2(x + width / 2 - 1, y - height / 2);
            left.start = new Vec2(x - width / 2, y - height / 2 + 1);
            left.end = new Vec2(x - width / 2, y + height / 2 - 1);
            right.start = new Vec2(x + width / 2, y - height / 2 + 1);
            right.end = new Vec2(x + width / 2, y + height / 2 - 1);
            bottom.start = new Vec2(x - width / 2 + 1, y + height / 2);
            bottom.end = new Vec2(x + width / 2 - 1, y + height / 2);
        }
    }
}
