using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledMapParser;

namespace GXPEngine
{
    public class AcidPuddle : AnimationSprite
    {
        List<AcidDroplet> droplets = new List<AcidDroplet>();
        bool gravityInverted = false;
        bool dripping;

        int spawnIntervalMs = 1500;
        int lastSpawn = 0;
        public AcidPuddle(Vec2 pos, bool dripping = false, bool gravityInverted = false) : base ("colors.png", 1, 1)
        {
            SetOrigin(width / 2, height / 2);
            collider.isTrigger = true;
            
            x = pos.x;
            y = pos.y;
            this.dripping = dripping;

            this.gravityInverted = gravityInverted;
        }

        void Update()
        {
            if (!dripping) 
            { 
                return; 
            }
            if (Time.time > lastSpawn)
            {
                lastSpawn = Time.time + spawnIntervalMs;
                SpawnDroplet();
            }
            MoveDroplets();
        }

        void SpawnDroplet()
        {
            AcidDroplet acidDroplet;

            int rand = new Random().Next(-width/2, width/2);
            if (gravityInverted)
            {
                acidDroplet = new AcidDroplet(new Vec2(x + rand, y - height/2));
            }
            else
            {
                acidDroplet = new AcidDroplet(new Vec2(x + rand, y + height / 2));
            }
            droplets.Add(acidDroplet);
            parent.LateAddChild(acidDroplet);
        }

        void MoveDroplets()
        {
            for (int i = droplets.Count - 1; i >= 0; i--)
            {
                AcidDroplet droplet = droplets[i];

                if (!gravityInverted)
                {
                    droplet.velocity += droplet.gravityDroplet;
                }
                else
                {
                    droplet.velocity -= droplet.gravityDroplet;
                }

                droplet.y += droplet.velocity.y;

                if (droplet.y < 0 || droplet.y > ((MyGame)game).height)
                {
                    droplets.Remove(droplet);
                    droplet.LateDestroy();
                }
            }
        }
    }
}
