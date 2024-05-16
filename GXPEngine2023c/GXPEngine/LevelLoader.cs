using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class LevelLoader : AnimationSprite
    {
        bool isColliding = false;
        int collisionTimeMs = 0;
        int collisionTimeElapsed = 0;
        public LevelLoader(Vec2 pos, int collisionTimeMs = 0) : base("triangle.png", 1, 1)
        { 
            SetOrigin(width / 2, height / 2);
            SetColor(1, 0, 0);

            x = pos.x;
            y = pos.y;

            this.collisionTimeMs = collisionTimeMs;
        }

        void Update()
        {
            isColliding = false;
            GameObject[] collisions = GetCollisions();
            foreach (GameObject col in collisions)
            {
                if (col is Player)
                {
                    isColliding = true;
                    collisionTimeElapsed += Time.deltaTime;
                    if (collisionTimeElapsed >= collisionTimeMs)
                    {
                        //TODO: uncomment
                        ((MyGame)game).levelData.LoadNextLevel();
                    }
                }
            }
            if (!isColliding)
            {
                collisionTimeElapsed = 0;
            }
        }
    }
}
