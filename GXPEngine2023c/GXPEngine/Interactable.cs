﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class Interactable : AnimationSprite
    {
        protected bool isColliding = false;
        protected bool canInteract = true;
        protected bool activated = false;
        public Interactable(float xPos, float yPos, string fileName, int cols, int rows) : base(fileName, cols, rows)
        {
            SetOrigin(width / 2, height / 2);
            collider.isTrigger = true;
            SetXY(xPos, yPos);
        }

        protected void Update()
        {
            isColliding = false;
            GameObject[] collisions = GetCollisions();
            foreach (Player col in collisions)
            {
                if (col is Player)
                {
                    isColliding = true;
                }
            }

            if (activated)
            {
                SetColor(1, 1, 1);
            }
            else
            {
                SetColor(0.5f, 0.5f, 0.5f);
            }
        }
    }
}
