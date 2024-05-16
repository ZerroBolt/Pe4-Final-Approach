using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledMapParser;

namespace GXPEngine
{
    public class Tile : Sprite
    {
        MyGame myGame;
        PlayerData data;

        public bool moving;
        public float moveSpeed;
        public float moveTimer;
        private float moveTimeLeft;

        Interactable interactable;
        public Tile(string image, int xPos = 0, int yPos = 0, bool moving = false, float _moveSpeed = 0, float _moveTimer = 0, Interactable interactable = null) : base (image)
        {
            myGame = ((MyGame)game);
            data = ((MyGame)game).playerData;

            width = 60;
            height = 60;

            x = xPos;
            y = yPos;

            this.interactable = interactable;

            this.moving = moving;
            moveSpeed = _moveSpeed;
            moveTimer = _moveTimer;
            moveTimeLeft = moveTimer;
        }

        void Update()
        {
            if (game != null && moving && (interactable != null && interactable.activated))
            {
                x += moveSpeed;

                moveTimeLeft -= Time.deltaTime;

                if (moveTimeLeft <= 0)
                {
                    moveSpeed *= -1;
                    moveTimeLeft = moveTimer;
                }
            }
        }
    }
}
