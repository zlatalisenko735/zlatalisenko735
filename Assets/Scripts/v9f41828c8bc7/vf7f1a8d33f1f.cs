using UnityEngine;

namespace Generated
{
    
    [DisallowMultipleComponent]
    internal sealed class vf7f1a8d33f1f : MonoBehaviour
    {
        private const float vdd2d8c1ccd4d = 0.3f;
        private const float vcf811346797e = 1.4f;
        private const float SpinDegPerSecond = 55f;

        [SerializeField] private SpriteRenderer _renderer;

        private Vector2 v71205d831ae0 = Vector2.one;
        private float v26babefee432 = -1f;

        internal int Ring { get; private set; }

        internal float AngleDeg { get; private set; }

        internal bool v6e003470ce3e { get; private set; }

        internal void v2f5e2173b1a9(vc66ab58d2d26 v7f8b360a92a9, vf5d1c7c7a537 v3338e7cccd35)
        {
            this.Ring = v3338e7cccd35.Ring;
            this.AngleDeg = v3338e7cccd35.AngleDeg;
            this.v6e003470ce3e = false;

            this.transform.position = v7f8b360a92a9.PointOnRing(v3338e7cccd35.Ring, v3338e7cccd35.AngleDeg);
            this.v71205d831ae0 = vc66ab58d2d26.SizeFor(this._renderer, v7f8b360a92a9.StarDiameter);
            this._renderer.size = this.v71205d831ae0;

            v8a29287814e6.v29234c61c1f5(this._renderer, v8a29287814e6.v51130b077348);
            this._renderer.color = va7c9379be56b.vdfed27544942;
        }

        internal void v93e0bcf0d3ec()
        {
            if (this.v6e003470ce3e)
            {
                return;
            }

            this.v6e003470ce3e = true;
            this.v26babefee432 = vdd2d8c1ccd4d;
        }

        private void Update()
        {
            if (!this.v6e003470ce3e)
            {
                this.transform.Rotate(0f, 0f, SpinDegPerSecond * Time.deltaTime);
                return;
            }

            if (this.v26babefee432 <= 0f)
            {
                return;
            }

            this.v26babefee432 -= Time.deltaTime;
            float v6aa337e09394 = 1f - Mathf.Clamp01(this.v26babefee432 / vdd2d8c1ccd4d);

            
            float scale = v6aa337e09394 < 0.4f
                ? Mathf.Lerp(1f, vcf811346797e, v6aa337e09394 / 0.4f)
                : Mathf.Lerp(vcf811346797e, 0f, (v6aa337e09394 - 0.4f) / 0.6f);

            this._renderer.size = this.v71205d831ae0 * scale;

            Color colour = this._renderer.color;
            colour.a = 1f - v6aa337e09394;
            this._renderer.color = colour;

            if (this.v26babefee432 <= 0f)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
