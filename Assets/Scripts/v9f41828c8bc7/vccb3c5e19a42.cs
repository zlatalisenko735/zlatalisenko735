using UnityEngine;

namespace Generated
{
    
    [DisallowMultipleComponent]
    internal sealed class vccb3c5e19a42 : MonoBehaviour
    {
        private const float ve8757fd46a0f = 0.05f;
        private const float v638905d17896 = 0.8f;
        private const float v2d9915eb557a = 0.35f;
        private const float v17a9bc3a62dd = 0.25f;
        private const float SpinDegPerSecond = -22f;

        [SerializeField] private SpriteRenderer _renderer;

        private Vector2 v71205d831ae0 = Vector2.one;
        private float v05f8991508da;

        internal void v2f5e2173b1a9(vc66ab58d2d26 v7f8b360a92a9)
        {
            this.transform.position = new Vector3(v7f8b360a92a9.Centre.x, v7f8b360a92a9.Centre.y, 0f);
            this.v71205d831ae0 = vc66ab58d2d26.SizeFor(this._renderer, v7f8b360a92a9.PortalDiameter);
            this._renderer.size = this.v71205d831ae0;

            v8a29287814e6.v29234c61c1f5(this._renderer, v8a29287814e6.v4ddf3b247277);
            this._renderer.color = va7c9379be56b.v97a9dfa1067f;
        }

        internal void vb9d7f2bd7053()
        {
            this.v05f8991508da = v2d9915eb557a;
        }

        
        internal void v125a5ac74305(bool vaf85034972c5)
        {
            this._renderer.color = vaf85034972c5 ? va7c9379be56b.v97a9dfa1067f : va7c9379be56b.vb09e0d1013c6;
        }

        private void Update()
        {
            this.transform.Rotate(0f, 0f, SpinDegPerSecond * Time.deltaTime);

            float breath = 1f + (Mathf.Sin(Time.time * v638905d17896 * Mathf.PI * 2f) * ve8757fd46a0f);

            if (this.v05f8991508da > 0f)
            {
                this.v05f8991508da -= Time.deltaTime;
                breath += v17a9bc3a62dd * vc0d78983fe6a.vc58549d3874d(1f - Mathf.Clamp01(this.v05f8991508da / v2d9915eb557a));
            }

            this._renderer.size = this.v71205d831ae0 * breath;
        }
    }
}
