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
    public class PullingBeam : GameObject
    {
        Vec2 position = new Vec2(0, 0);
        Vec2 mousePos = new Vec2(0, 0);
        public LineSegment line;

        bool firstRun = true;
        public PullingBeam()
        {
            line = new LineSegment(new Vec2(0, 0), new Vec2(0, 0));
        }

        void Update()
        {
            if (firstRun)
            {
                parent.AddChild(line);
                firstRun = false;
            }

            x = parent.x;
            y = parent.y;

            //x = position.x = parent.x;
            //y = position.y = parent.y;

            mousePos = new Vec2(Input.mouseX - x, Input.mouseY - y);

            //position.RotateDegrees((mousePos - position).GetAngleDegrees());

            line.end = mousePos;
        }
    }
}
