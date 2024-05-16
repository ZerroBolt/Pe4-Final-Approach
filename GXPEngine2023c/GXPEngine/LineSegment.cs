using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using GXPEngine.Core;

namespace GXPEngine
{
    public class LineSegment : GameObject
    {
        public Vec2 start;
        public Vec2 end;

        public uint color;
        public uint lineWidth;

        public bool moving;
        public float moveSpeed;
        public float moveTimer;
        private float moveTimeLeft;

        MyGame myGame;
        PlayerData data;

        Interactable interactable;

        public LineSegment(Vec2 _start, Vec2 _end, bool _moving = false, float _moveSpeed = 0, float _moveTimer = 0, Interactable interactable = null)
        {
            myGame = ((MyGame)game);
            data = ((MyGame)game).playerData;

            start = _start;
            end = _end;
            color = data.lineColor;
            lineWidth = data.lineWidth;

            this.interactable = interactable;

            moving = _moving;
            moveSpeed = _moveSpeed;
            moveTimer = _moveTimer;
            moveTimeLeft = moveTimer;
        }

        //override protected void RenderSelf(GLContext glContext)
        //{
            
        //        Gizmos.RenderLine(start.x, start.y, end.x, end.y, color, lineWidth);
            
        //}

        void Update()
        {
            if (game != null && moving && (interactable != null && interactable.activated))
            {
                start.x += moveSpeed;
                end.x += moveSpeed;

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
