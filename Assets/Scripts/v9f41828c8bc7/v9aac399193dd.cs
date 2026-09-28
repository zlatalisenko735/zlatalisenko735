using UnityEngine;
using UnityEngine.EventSystems;

namespace Generated
{
    
    
    
    
    [DisallowMultipleComponent]
    internal sealed class v9aac399193dd : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private const float v1e320f33cf7a = 0.94f;
        private const float vb1bcbfea09cd = 0.16f;

        private Vector3 v0cfaf4c6ca8f = Vector3.one;
        private float vb198fb1932de;

        private void Awake()
        {
            this.v0cfaf4c6ca8f = this.transform.localScale;
        }

        public void OnPointerDown(PointerEventData ve70ae56cc19d)
        {
            this.vb198fb1932de = 0f;
            this.transform.localScale = this.v0cfaf4c6ca8f * v1e320f33cf7a;
        }

        public void OnPointerUp(PointerEventData ve70ae56cc19d)
        {
            this.vb198fb1932de = vb1bcbfea09cd;
        }

        private void OnDisable()
        {
            this.vb198fb1932de = 0f;
            this.transform.localScale = this.v0cfaf4c6ca8f;
        }

        private void Update()
        {
            if (this.vb198fb1932de <= 0f)
            {
                return;
            }

            this.vb198fb1932de -= Time.deltaTime;
            float v6aa337e09394 = 1f - Mathf.Clamp01(this.vb198fb1932de / vb1bcbfea09cd);
            float scale = Mathf.LerpUnclamped(v1e320f33cf7a, 1f, vc0d78983fe6a.ve269e9eb030b(v6aa337e09394));

            this.transform.localScale = this.v0cfaf4c6ca8f * scale;

            if (this.vb198fb1932de <= 0f)
            {
                this.transform.localScale = this.v0cfaf4c6ca8f;
            }
        }
    }
}
