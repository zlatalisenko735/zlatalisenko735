using UnityEngine;

namespace Generated
{
    
    
    
    
    [DisallowMultipleComponent]
    internal sealed class v73d0b57143d4 : MonoBehaviour
    {
        private const float v2d9915eb557a = 0.18f;
        private const float v17a9bc3a62dd = 0.18f;
        private const float va7562c05839c = 6f;

        [SerializeField] private SpriteRenderer _renderer;

        private Vector2 v71205d831ae0 = Vector2.one;
        private Color v632f2e8b9207 = Color.white;
        private float v05f8991508da;
        private float v3529cce86299 = 1f;
        private bool v2fdcbf242316;

        internal void v2f5e2173b1a9(vc66ab58d2d26 v7f8b360a92a9)
        {
            this.v71205d831ae0 = vc66ab58d2d26.SizeFor(this._renderer, v7f8b360a92a9.BallDiameter);
            this._renderer.size = this.v71205d831ae0;

            v8a29287814e6.v29234c61c1f5(this._renderer, v8a29287814e6.vbaeca1c4ead9);

            this.v632f2e8b9207 = va7c9379be56b.v02610b855b7f;
            this._renderer.color = this.v632f2e8b9207;
        }

        internal void v00bf61e06ec1(Vector3 vd13773b992ee)
        {
            this.transform.position = vd13773b992ee;
        }

        
        internal void v026bd491211e()
        {
            this.v05f8991508da = v2d9915eb557a;
        }

        internal void v927eb4f61510(bool v150a3eacebbc)
        {
            this.v2fdcbf242316 = v150a3eacebbc;
            if (!v150a3eacebbc)
            {
                Color solid = this.v632f2e8b9207;
                solid.a = 1f;
                this._renderer.color = solid;
            }
        }

        
        internal void v8e8805125499(float v6aa337e09394)
        {
            this.v3529cce86299 = 1f - (Mathf.Clamp01(v6aa337e09394) * 0.8f);
        }

        internal void v6a5f16905bc7()
        {
            this.v3529cce86299 = 1f;
        }

        private void Update()
        {
            float scale = this.v3529cce86299;
            Color colour = this.v632f2e8b9207;

            if (this.v05f8991508da > 0f)
            {
                this.v05f8991508da -= Time.deltaTime;
                float swell = vc0d78983fe6a.vc58549d3874d(1f - Mathf.Clamp01(this.v05f8991508da / v2d9915eb557a));
                scale *= 1f + (v17a9bc3a62dd * swell);
                colour = Color.Lerp(this.v632f2e8b9207, va7c9379be56b.v793c5f9ef2be, swell);
            }

            if (this.v2fdcbf242316)
            {
                colour.a = Mathf.Lerp(0.35f, 1f, Mathf.PingPong(Time.time * va7562c05839c, 1f));
            }

            this._renderer.size = this.v71205d831ae0 * scale;
            this._renderer.color = colour;
        }
    }
}
