using UnityEngine;
using UnityEngine.InputSystem;

namespace VRnLit.Scripts.Gameplay
{
    public class PlayerGrabber : MonoBehaviour
    {
        public void OnTake(InputValue value)
        {
            if (value.isPressed)
            {
                print("Take");
            }
        }
    }
}