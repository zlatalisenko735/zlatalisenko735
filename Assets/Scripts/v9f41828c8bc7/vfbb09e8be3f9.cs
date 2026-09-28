using UnityEngine;

namespace Generated
{
    
    
    
    
    
    [DisallowMultipleComponent]
    internal sealed class vfbb09e8be3f9 : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _renderer;

        private float vefe06e18a63f = 1f;
        private float v4be71eace2b6;
        private float vfae30f3d9110 = 0.25f;

        internal void v2f5e2173b1a9(vc66ab58d2d26 v7f8b360a92a9, int v87c1c391a755, int sortingOrder, Color v391535648d39)
        {
            this.transform.position = new Vector3(v7f8b360a92a9.Centre.x, v7f8b360a92a9.Centre.y, 0f);

            
            
            
            this._renderer.size = vc66ab58d2d26.SizeFor(
                this._renderer, v7f8b360a92a9.RingRadius(v87c1c391a755) * 2f);

            v8a29287814e6.v29234c61c1f5(this._renderer, sortingOrder);

            this.vefe06e18a63f = v391535648d39.a;
            this._renderer.color = v391535648d39;
        }

        internal void vfe378af14e7e(float v75bb14d6312e)
        {
            this.transform.rotation = Quaternion.Euler(0f, 0f, v75bb14d6312e);
        }

        
        internal void v299c8e8c5ef2()
        {
            this.v4be71eace2b6 = this.vfae30f3d9110;
        }

        private void Update()
        {
            if (this.v4be71eace2b6 <= 0f)
            {
                return;
            }

            this.v4be71eace2b6 -= Time.deltaTime;
            float v6aa337e09394 = 1f - Mathf.Clamp01(this.v4be71eace2b6 / this.vfae30f3d9110);

            Color colour = this._renderer.color;
            colour.a = Mathf.Lerp(this.vefe06e18a63f * 0.4f, this.vefe06e18a63f, v6aa337e09394);
            this._renderer.color = colour;
        }
    }
}
