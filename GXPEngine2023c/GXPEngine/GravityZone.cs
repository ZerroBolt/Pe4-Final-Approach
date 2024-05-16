using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine
{
    public class GravityZone : Sprite
    {
        Interactable interactable;
        public bool active = false;
        public GravityZone(Vec2 pos, int _width, int _height, Interactable interactable = null) : base("square.png", false, true)
        {
            collider.isTrigger = true;
            SetColor(1, 0, 1);

            x = pos.x;
            y = pos.y;

            width = _width;
            height = _height;

            this.interactable = interactable;
        }

        void Update()
        {
            if (interactable == null || interactable.activated)
            {
                active = true;
                visible = true;
            }
            else
            {
                active = false;
                visible = false;
            }
        }
    }
}
