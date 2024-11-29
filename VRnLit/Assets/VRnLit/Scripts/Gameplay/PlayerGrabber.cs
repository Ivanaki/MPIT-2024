using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace VRnLit.Scripts.Gameplay
{
    public class PlayerGrabber : MonoBehaviour
    {
        //[SerializeField] private Vector3 _velocity = new Vector3(1, 0, 0);
        [SerializeField] private float _forwardCoof = 5f;
        [SerializeField] private float _upCoof = 5f;
        
        [SerializeField] private Transform _cameraTransform;
        [SerializeField] private Transform _grabParent;

        [SerializeField] private float _distnce = 2f;
        [SerializeField] private LayerMask _layerMask;
        
        private bool _isGrabbing = false;
        private Transform _cashedGrabObject = null;
        private ITake _cashedInterface = null;
        private IBook _cashedBook = null;
        
        public void OnTake(InputValue value)
        {
            if (value.isPressed)
            {
                //print("teke");
                Take();
            }
        }

        public void OnDrop(InputValue value)
        {
            if (value.isPressed)
            {
                Drop();
            }
        }
        
        public void OnLeft(InputValue value)
        {
            if (value.isPressed && _cashedBook != null)
            {
                _cashedBook.Left();
            }
        }
        
        public void OnRight(InputValue value)
        {
            if (value.isPressed && _cashedBook != null)
            {
                _cashedBook.Right();
            }
        }

        private void Take()
        {
            //Debug.DrawRay(_cameraTransform.position,_cameraTransform.forward);
            if (!_isGrabbing && Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out var hit, _distnce, _layerMask))
            {
                //print(1);
                if (hit.collider.TryGetComponent(out ITake take))
                {
                    //print(2);
                    _isGrabbing = true;
                    _cashedInterface = take;
                    _cashedGrabObject = hit.collider.transform;
                    take.Take();

                    _cashedGrabObject.parent = _grabParent;
                    _cashedGrabObject.localPosition = Vector3.zero;
                    _cashedGrabObject.localRotation = Quaternion.identity;

                    hit.collider.TryGetComponent(out _cashedBook);
                    
                    
                }
            }
        }

        private void Drop()
        {
            if (_isGrabbing)
            {
                _cashedInterface.Drop(); // kinematic
                StartCoroutine(DropEnumerator());
            }
        }
        
        private IEnumerator DropEnumerator()
        {
            yield return null;
            
            _cashedGrabObject.parent = null;
            _cashedInterface.AddVelocity(_cameraTransform.forward * _forwardCoof);
            _cashedInterface.AddVelocity(Vector3.up * _upCoof);
            
            _cashedBook = null;
            _isGrabbing = false;
            _cashedInterface = null;
            _cashedGrabObject = null;
        }
    }
}