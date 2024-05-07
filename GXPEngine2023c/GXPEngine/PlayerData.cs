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

        static float speedPlayer = 10;
        static float heightJump = 20;

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

        public PlayerData()
        {

        }
    }
}
