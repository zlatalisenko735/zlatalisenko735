using UnityEngine;

namespace Generated
{
    
    
    
    
    
    [DisallowMultipleComponent]
    internal sealed class vd7bdb109f122 : MonoBehaviour
    {
        [SerializeField] private float _degreesPerSecond = 18f;

        private void Update()
        {
            this.transform.Rotate(0f, 0f, this._degreesPerSecond * Time.deltaTime);
        }
    }
}
