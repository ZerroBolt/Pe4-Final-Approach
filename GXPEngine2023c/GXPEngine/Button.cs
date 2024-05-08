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
        public Button() : base (250, 100, "circle.png", 1, 1)
        {

        }

        private void Update()
        {
            base.Update();
            CheckInteraction();
            if (activated)
            {
                Console.WriteLine("Button activated");
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
