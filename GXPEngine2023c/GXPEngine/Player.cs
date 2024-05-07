using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class Player : AnimationSprite
    {
        PlayerData data;

        Vec2 position = new Vec2(100, 100);
        Vec2 velocity = new Vec2(0, 0);
        bool arrowKeybind;

        public Player(bool arrowKeybind = false) : base("square.png", 1, 1)
        {
            data = ((MyGame)game).playerData;

            x = position.x;
            y = position.y;

            SetOrigin(width / 2, height / 2);
            this.arrowKeybind = arrowKeybind;
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
                    velocity.x -= data.playerSpeed;
                }
                else if (Input.GetKey(Key.RIGHT))
                {
                    velocity.x += data.playerSpeed;
                }
            }
            else
            {
                if (Input.GetKey(Key.A))
                {
                    velocity.x -= data.playerSpeed;
                }
                else if (Input.GetKey(Key.D))
                {
                    velocity.x += data.playerSpeed;
                }
            }

            velocity += data.playerGravity;

            UpdatePosition();
        }

        void UpdatePosition()
        {
            position += velocity;
            velocity.x = 0;
            x = position.x;
            y = position.y;
        }
    }
}
