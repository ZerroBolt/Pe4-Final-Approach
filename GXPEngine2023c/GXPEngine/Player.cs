using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class Player : AnimationSprite
    {
        Vec2 position;
        bool arrowKeybind;

        float velocity = 1f;

        public Player(Vec2 position, bool arrowKeybind = false) : base("square.png", 1, 1)
        {
            SetOrigin(width / 2, height / 2);
            this.arrowKeybind = arrowKeybind;
            this.position = position;
        }

        void Update()
        {
            Move();
        }

        void Move()
        {
            if (arrowKeybind)
            {
                if (Input.GetKey(Key.LEFT))
                {
                    position.SetXY(position.x + -velocity, position.y);
                }
                if (Input.GetKey(Key.RIGHT))
                {
                    position.SetXY(position.x + velocity, position.y);
                }
            }
            else
            {
                if (Input.GetKey(Key.A))
                {
                    position.SetXY(position.x + -velocity, position.y);
                }
                if (Input.GetKey(Key.D))
                {
                    position.SetXY(position.x + velocity, position.y);
                }
            }

            this.x = position.x;
            this.y = position.y;
        }
    }
}
