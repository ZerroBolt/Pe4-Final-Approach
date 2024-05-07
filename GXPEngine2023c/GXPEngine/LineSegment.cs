using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using GXPEngine.Core;
using TiledMapParser;

namespace GXPEngine
{
    public class LineSegment : GameObject
    {
        public Vec2 start;
        public Vec2 end;

        public uint color;
        public uint lineWidth;

        MyGame myGame;
        Data data;

        public LineSegment(Vec2 _start, Vec2 _end)
        {
            myGame = ((MyGame)game);
            data = ((MyGame)game).data;

            start = _start;
            end = _end;
            color = data.lineColor;
            lineWidth = data.lineWidth;
        }

        override protected void RenderSelf(GLContext glContext)
        {
            if (game != null)
            {
                Gizmos.RenderLine(start.x, start.y, end.x, end.y, color, lineWidth);
            }
        }
    }
}
