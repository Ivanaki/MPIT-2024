using UnityEngine;

namespace VRnLit.Scripts.Gameplay
{
    public class MyPerson : MonoBehaviour
    {
        
        
        private void SetCursorState(bool newState)
        {
            Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }
}