using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class GravityZone : Sprite
    {

        public GravityZone(Vec2 pos, int _width, int _height) : base("square.png", false, true)
        {
            collider.isTrigger = true;
            SetColor(1, 0, 1);

            x = pos.x;
            y = pos.y;

            width = _width;
            height = _height;
        }
    }
}
