using System.Collections;
using UnityEngine;

namespace VRnLit.Scripts.Gameplay
{
    [RequireComponent(typeof(Rigidbody))]
    public class GrabObject : MonoBehaviour, ITake
    {
        //[SerializeField] private Vector3 velocity = new(1,0,0);
        
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        
        public void Take()
        {
            _rigidbody.isKinematic = true;
        }

        public void Drop()
        {
            _rigidbody.isKinematic = false;
        }

        public void AddVelocity(Vector3 velocity)
        {
            _rigidbody.AddForce(velocity, ForceMode.Impulse);
        }
    }
}