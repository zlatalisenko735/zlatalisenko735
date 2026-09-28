using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Generated
{
    
    
    
    
    
    [DisallowMultipleComponent]
    internal sealed class v0339ae2b922a : MonoBehaviour
    {
        
        internal event Action v4b6ed93e4cbf;

        private bool vc1034eadb3ba;

        internal void vb58ed50ae678(bool vf7dc17f65c65)
        {
            this.vc1034eadb3ba = vf7dc17f65c65;
        }

        private void Update()
        {
            if (!this.vc1034eadb3ba)
            {
                return;
            }

            Vector2 position;
            if (!ve1aeaf29e794(out position))
            {
                return;
            }

            float height = Screen.height;
            if (height <= 0f)
            {
                return;
            }

            float fraction = position.y / height;
            if (fraction < v2fcef25e0767.vd156db0c4591 || fraction > v2fcef25e0767.v2a6ba49ac3fb)
            {
                return;
            }

            Action handler = this.v4b6ed93e4cbf;
            if (handler != null)
            {
                handler();
            }
        }

        private static bool ve1aeaf29e794(out Vector2 position)
        {
            Touchscreen touchscreen = Touchscreen.current;
            if (touchscreen != null && touchscreen.primaryTouch.press.wasPressedThisFrame)
            {
                position = touchscreen.primaryTouch.position.ReadValue();
                return true;
            }

            
            Mouse mouse = Mouse.current;
            if (mouse != null && mouse.leftButton.wasPressedThisFrame)
            {
                position = mouse.position.ReadValue();
                return true;
            }

            position = Vector2.zero;
            return false;
        }
    }
}
