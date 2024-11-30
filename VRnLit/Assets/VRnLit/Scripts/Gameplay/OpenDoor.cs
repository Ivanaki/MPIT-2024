using UnityEngine;
using Valve.VR.InteractionSystem;

namespace VRnLit.Scripts.Gameplay
{
    [RequireComponent(typeof(MyCircularDrive))]
    public class OpenDoor : MonoBehaviour, IOpenDoor
    {
        [SerializeField] private float _openAngle;
        [SerializeField] private float _closeAngle;
        
        private MyCircularDrive _circularDrive;
        private void Awake()
        {
            _circularDrive = GetComponent<MyCircularDrive>();
        }
        
        private bool _isOpen = false;
        public void DoAction()
        {
            _isOpen = !_isOpen;
            if (_isOpen)
                Open();
            else
                Close();
            
        }

        private void Open()
        {
            _circularDrive.SetAngle(_openAngle);
        }

        private void Close()
        {
            _circularDrive.SetAngle(_closeAngle);
        }
    }
}