﻿using System;
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

        public LineSegment(Vec2 _start, Vec2 _end, bool _moving = false, float _moveSpeed = 0, float _moveTimer = 0)
        {
            myGame = ((MyGame)game);
            data = ((MyGame)game).playerData;

            start = _start;
            end = _end;
            color = data.lineColor;
            lineWidth = data.lineWidth;

            moving = _moving;
            moveSpeed = _moveSpeed;
            moveTimer = _moveTimer;
            moveTimeLeft = moveTimer;
        }

        override protected void RenderSelf(GLContext glContext)
        {
            if (game != null && !moving)
            {
                Gizmos.RenderLine(start.x, start.y, end.x, end.y, color, lineWidth);
            }
        }

        void Update()
        {
            if (game != null && moving)
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
