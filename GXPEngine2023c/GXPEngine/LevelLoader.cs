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
        int collisionIntervalMs = 1000;
        int collisionTime = 0;
        public LevelLoader(Vec2 pos) : base("triangle.png", 1, 1)
        { 
            SetOrigin(width / 2, height / 2);
            SetColor(1, 0, 0);

            x = pos.x;
            y = pos.y;
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
                    collisionTime += Time.deltaTime;
                    if (collisionTime >= collisionIntervalMs)
                    {
                        //TODO: uncomment
                        //((MyGame)game).levelData.LoadNextLevel();
                    }
                }
            }
            if (!isColliding)
            {
                collisionTime = 0;
            }
        }
    }
}
