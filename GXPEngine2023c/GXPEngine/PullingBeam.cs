using GXPEngine.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class PullingBeam : Sprite
    {
        Vec2 position = new Vec2(0, 0);
        Vec2 mousePos = new Vec2(0, 0);
        public PullingBeam() : base("checkers.png")
        {
            SetOrigin(0, height/2);
            collider.isTrigger = true;
            width = 300;

            alpha = 0;
        }

        void Update()
        {
            mousePos = new Vec2(Input.mouseX - parent.x, Input.mouseY - parent.y);
            rotation = (mousePos - position).GetAngleDegrees();
        }
    }
}
