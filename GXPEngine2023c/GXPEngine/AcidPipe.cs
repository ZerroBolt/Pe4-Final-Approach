using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class AcidPipe : Sprite
    {
        List<AcidDroplet> droplets = new List<AcidDroplet>();
        bool gravityInverted = false;
        bool dripping;

        int spawnIntervalMs = 5000;
        int lastSpawn = 0;
        public AcidPipe(string image, Vec2 pos, bool dripping = false, bool gravityInverted = false) : base (image)
        {
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

            int rand = new Random().Next(5, width - 5);
            if (gravityInverted)
            {
                acidDroplet = new AcidDroplet(new Vec2(x + rand, y - height));
            }
            else
            {
                acidDroplet = new AcidDroplet(new Vec2(x + rand, y + height));
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
