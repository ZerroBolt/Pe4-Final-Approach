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
        public GravityZone(Vec2 pos, int _width, int _height, Interactable interactable = null) : base("white.png", false, true)
        {
            collider.isTrigger = true;
            SetColor(0.3f, 0, 0.3f);

            x = pos.x;
            y = pos.y;

            width = _width;
            height = _height;

            this.interactable = interactable;
            alpha = 0.5f;
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
