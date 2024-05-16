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
        public Button(Vec2 pos) : base (pos, "ButtonSheet.png", 2, 1)
        {

        }

        private void Update()
        {
            base.Update();
            CheckInteraction();
            if (activated)
            {
                SetCycle(1, 1);
            }
            else
            {
                SetCycle(0, 1);
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
