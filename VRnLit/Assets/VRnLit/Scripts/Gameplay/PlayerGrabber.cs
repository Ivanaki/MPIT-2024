using UnityEngine;
using UnityEngine.InputSystem;

namespace VRnLit.Scripts.Gameplay
{
    public class PlayerGrabber : MonoBehaviour
    {
        [SerializeField] private Transform _cameraTransform;

        [SerializeField] private float _distnce = 2f;
        [SerializeField] private LayerMask _layerMask;
        
        public void OnTake(InputValue value)
        {
            if (value.isPressed)
            {
                Take();
            }
        }

        private void Take()
        {
            if (Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out var hit, _distnce, _layerMask))
            {
                if (hit.collider.TryGetComponent(out ITake take))
                {
                    take.Take();
                }
            }
        }
    }
}