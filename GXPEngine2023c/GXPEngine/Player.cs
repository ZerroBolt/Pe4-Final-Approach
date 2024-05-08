using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class Player : AnimationSprite
    {
        PlayerData data;

        List<LineSegment> horLines;
        List<LineSegment> vertLines;

        Vec2 position = new Vec2(100, 100);
        Vec2 velocity = new Vec2(0, 0);
        bool arrowKeybind;

        float earliestTOIHor;
        float earliestTOIVert;
        string lineDir = "none";

        bool gravityInverted = false;
        bool isGrounded = false;

        public Player(Vec2 pos, bool arrowKeybind = false) : base("square.png", 1, 1)
        {
            data = ((MyGame)game).playerData;

            horLines = ((MyGame)game).horLines;
            vertLines = ((MyGame)game).vertLines;

            position = pos;

            x = position.x;
            y = position.y;

            SetOrigin(width / 2, height / 2);
            this.arrowKeybind = arrowKeybind;
        }

        void Update()
        {
            Move();
            UpdatePosition();
        }

        void Move()
        {
            if (arrowKeybind)
            {
                if (Input.GetKey(Key.LEFT))
                {
                    velocity.x -= data.playerSpeed;
                }
                else if (Input.GetKey(Key.RIGHT))
                {
                    velocity.x += data.playerSpeed;
                }

                if (Input.GetKeyDown(Key.UP) && isGrounded)
                {
                    velocity.y = -data.jumpHeight;
                }
            }
            else
            {
                if (Input.GetKey(Key.A))
                {
                    velocity.x -= data.playerSpeed;
                }
                else if (Input.GetKey(Key.D))
                {
                    velocity.x += data.playerSpeed;
                }

                if (Input.GetKeyDown(Key.W) && isGrounded)
                {
                    velocity.y = -data.jumpHeight;
                    
                }
            }

            Gravity();

            Collisions();
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

                    if (!gravityInverted)
                    {
                        isGrounded = true;
                    }
                }
                else if (position.y > otherHor.start.y)
                {
                    position.y = otherHor.start.y + height / 2;
                    velocity.y = 0;

                    if (gravityInverted)
                    {
                        isGrounded = true;
                    }
                }

                if (!gravityInverted && position.y < otherHor.start.y)
                {
                    isGrounded = true;
                }
                else if (gravityInverted && position.y > otherVert.start.y)
                {
                    isGrounded = true;
                }
            }
            else
            {
                isGrounded = false;
                position.y += velocity.y;
            }

            if (otherVert != null)
            {
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
            lineDir = "none";

            LineSegment other = null;

            foreach (LineSegment line in horLines)
            {
                if (Mathf.Abs(DistanceCalc(line, position)) < height / 2 && IsOnSegment(newPos, width / 2, line))
                {
                    float oldDistance = DistanceCalc(line, position);
                    float newDistance = DistanceCalc(line, newPos);
                    float toi = Vec2.TOI(oldDistance, height / 2, newDistance);
                    if (toi < earliestTOIHor)
                    {
                        earliestTOIHor = toi;
                        lineDir = "hor";
                        other = line;
                    }
                }
            }

            return other;
        }

        LineSegment EarliestCollisionVert(Vec2 newPos)
        {
            earliestTOIVert = 1;
            lineDir = "none";

            LineSegment other = null;
            
            foreach (LineSegment line in vertLines)
            {
                if (Mathf.Abs(DistanceCalc(line, position)) < width && IsOnSegment(newPos, height / 2, line))
                {
                    float oldDistance = DistanceCalc(line, position);
                    float newDistance = DistanceCalc(line, newPos);
                    float toi = Vec2.TOI(oldDistance, width / 2, newDistance);
                    if (toi < earliestTOIVert)
                    {
                        earliestTOIVert = toi;
                        lineDir = "vert";
                        other = line;
                        Console.WriteLine(toi);
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

            if (distanceAlongLine + edgeDistance > 0 && distanceAlongLine - edgeDistance     < lineVec.Length())
            {
                return true;
            }
            else
            {
                return false;
            }
        }




        void UpdatePosition()
        {
            x = position.x;
            y = position.y;
        }
    }
}
