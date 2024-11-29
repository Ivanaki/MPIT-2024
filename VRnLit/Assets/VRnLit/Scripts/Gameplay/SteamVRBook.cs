using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

namespace VRnLit.Scripts.Gameplay
{
    [RequireComponent(typeof(Throwable), typeof(IBook))]
    public class SteamVRBook : MonoBehaviour
    {
        private Throwable _throwable;
        private IBook _book;

        private bool _isInHand = false;
        
        private SteamVR_Action_Boolean _left;
        private SteamVR_Action_Boolean _right;
        
        private void Awake()
        {
            _left = SteamVR_Actions._default.Left;
            _right = SteamVR_Actions._default.Right;
            
            _book = GetComponent<IBook>();
            
            _throwable = GetComponent<Throwable>();
            _throwable.onPickUp.AddListener(() =>
            {
                _isInHand = true;
            });
            _throwable.onDetachFromHand.AddListener(() =>
            {
                _isInHand = false;
            });
        }

        private void Update()
        {
            if (_isInHand && _left.stateDown)
            {
                _book.Left();
            }
            if (_isInHand && _right.stateDown)
            {
                _book.Right();
            }
        }
    }
}