using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class Lever : Interactable
    {
        int timerTimeMs = 0;
        int timeElapsed = 0;
        public Lever(Vec2 pos, int timerTimeMs = 0) : base(pos, "LeverAnimationSheet.png", 4, 1)
        {
            this.timerTimeMs = timerTimeMs;
        }

        private void Update()
        {
            base.Update();
            CheckInteraction();
            if (activated) 
            {
                SetColor(1, 1, 1);
                SetCycle(3, 1);
            }
            else
            {
                SetCycle(0, 1);
                SetColor(0.5f, 0.5f, 0.5f);
            }
        }

        private void CheckInteraction()
        {
            //TODO: When timer is set can the player still turn it off manually??
            //      Or does it turn off only after the timer is done??
            if (timerTimeMs > 0 && activated)
            {
                timeElapsed += Time.deltaTime;
                if (timeElapsed >= timerTimeMs)
                {
                    activated = !activated;
                    timeElapsed = 0;
                }
            }
            if (!isColliding)
            {
                canInteract = true;
            }
            else if (canInteract)
            {
                canInteract = false;
                activated = !activated;
                timeElapsed = 0;
            }
        }
    }
}
