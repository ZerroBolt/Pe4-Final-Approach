using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class Button : Interactable
    {
        public Button(Vec2 pos) : base (pos, "circle.png", 1, 1)
        {

        }

        private void Update()
        {
            base.Update();
            CheckInteraction();
            if (activated)
            {
                
                //TODO: Add functionality
            }
        }

        private void CheckInteraction()
        {
            if (!isColliding)
            {
                activated = false;
            }
            else
            {
                activated = true;
            }
        }
    }
}
