using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class AcidDroplet : AnimationSprite
    {
        public Vec2 velocity = new Vec2(0, 0);
        public Vec2 gravityDroplet = new Vec2(0, .05f);
        public AcidDroplet(Vec2 pos) : base("AcidDroplet.png", 1, 1)
        {
            SetOrigin(width / 2, height / 2);
            collider.isTrigger = true;

            scale = 2;

            x = pos.x;
            y = pos.y;
        }

        void Update()
        {
            //GameObject[] collisions = GetCollisions();
            //foreach (GameObject col in collisions)
            //{
            //    if (col is AcidPuddle)
            //    {
            //        continue;
            //    }
            //    else if (col is Player)
            //    {
            //        Player p = col as Player;
            //        p.ResetPosition();
            //        LateDestroy();
            //    }
            //    else
            //    {
            //        LateDestroy();
            //    }
            //}
        }
    }
}
