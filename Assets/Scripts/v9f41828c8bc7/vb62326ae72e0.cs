using UnityEngine;

namespace Generated
{
    
    [DisallowMultipleComponent]
    internal sealed class vb62326ae72e0 : MonoBehaviour
    {
        private const float v91523a880868 = 0.45f;

        [SerializeField] private SpriteRenderer _renderer;

        private Vector3 vb5cb8857c7ed;
        private Vector3 v24e80ab8f367;
        private Vector2 v71205d831ae0 = Vector2.one;
        private float vf9e62c1481fc;

        internal void v781425e1fb44(vc66ab58d2d26 v7f8b360a92a9, Vector3 v07c0b1033342, float v67119ea9ea40, Color v391535648d39)
        {
            float radians = v67119ea9ea40 * Mathf.Deg2Rad;

            this.vb5cb8857c7ed = v07c0b1033342;
            this.v24e80ab8f367 = v07c0b1033342 + (new Vector3(Mathf.Cos(radians), Mathf.Sin(radians), 0f) * v7f8b360a92a9.SparkSpread);
            this.vf9e62c1481fc = v91523a880868;

            this.v71205d831ae0 = vc66ab58d2d26.SizeFor(this._renderer, v7f8b360a92a9.StarDiameter * 0.6f);
            this.transform.position = v07c0b1033342;
            this._renderer.size = this.v71205d831ae0;

            v8a29287814e6.v29234c61c1f5(this._renderer, v8a29287814e6.v81e37634330e);
            this._renderer.color = v391535648d39;
        }

        private void Update()
        {
            this.vf9e62c1481fc -= Time.deltaTime;
            if (this.vf9e62c1481fc <= 0f)
            {
                Destroy(this.gameObject);
                return;
            }

            float v6aa337e09394 = 1f - Mathf.Clamp01(this.vf9e62c1481fc / v91523a880868);

            this.transform.position = Vector3.Lerp(this.vb5cb8857c7ed, this.v24e80ab8f367, vc0d78983fe6a.vb9b3b3ba8fc5(v6aa337e09394));
            this._renderer.size = this.v71205d831ae0 * (1f - (v6aa337e09394 * 0.7f));

            Color colour = this._renderer.color;
            colour.a = 1f - v6aa337e09394;
            this._renderer.color = colour;
        }
    }
}
