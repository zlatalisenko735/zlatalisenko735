using UnityEngine;

namespace Generated
{
    
    [DisallowMultipleComponent]
    internal sealed class v4de849b5d17b : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _renderer;

        internal void v2f5e2173b1a9(vc66ab58d2d26 v7f8b360a92a9, int v87c1c391a755, Color v391535648d39)
        {
            this.transform.position = new Vector3(v7f8b360a92a9.Centre.x, v7f8b360a92a9.Centre.y, 0f);
            this._renderer.size = vc66ab58d2d26.SizeFor(
                this._renderer, v7f8b360a92a9.RingRadius(v87c1c391a755) * 2f);

            v8a29287814e6.v29234c61c1f5(this._renderer, v8a29287814e6.Ring(v87c1c391a755));
            this._renderer.color = v391535648d39;
        }

        
        internal void v7e850f96fcc3(bool v00ea4792f22f)
        {
            Color colour = this._renderer.color;
            colour.a = v00ea4792f22f ? 0.95f : 0.4f;
            this._renderer.color = colour;
        }
    }
}
