using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class Lever : Interactable
    {
        public Lever() : base(500, 100, "triangle.png", 1, 1)
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
                canInteract = true;
            }
            else if (canInteract)
            {
                canInteract = false;
                activated = !activated;
            }
        }
    }
}
