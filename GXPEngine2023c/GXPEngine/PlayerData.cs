using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class PlayerData
    {
        static Vec2 gravityPlayer = new Vec2(0, .1f);

        static float speedPlayer = 5;
        static float heightJump = 7;



        static uint colorLine = 0xff00ff00;
        static uint widthLine = 3;

        public Vec2 playerGravity
        {
            get
            {
                return gravityPlayer;
            }
        }

        public float playerSpeed
        {
            get
            {
                return speedPlayer;
            }
        }

        public float jumpHeight
        {
            get
            {
                return heightJump;
            }
        }

        public uint lineColor
        {
            get
            {
                return colorLine;
            }
        }

        public uint lineWidth
        {
            get
            {
                return widthLine;
            }
        }

        public PlayerData()
        {

        }
    }
}
