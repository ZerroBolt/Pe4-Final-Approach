using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class Crate : Sprite
    {
        PlayerData data;

        List<LineSegment> horLines;
        List<LineSegment> vertLines;

        public Vec2 position;
        
        public Crate(Vec2 pos) : base("square.png", false, false)
        {
            data = ((MyGame)game).playerData;

            horLines = ((MyGame)game).horLines;
            vertLines = ((MyGame)game).vertLines;

            SetColor(1, 1, 1);
        }
    }
}
