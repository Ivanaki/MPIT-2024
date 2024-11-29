using UnityEngine;
using UnityEngine.InputSystem;

namespace VRnLit.Scripts.Gameplay
{
    public class PlayerCursorLocker : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ChangeLock();
            }
        }
        
        private bool changeLock = true;
        private void ChangeLock()
        {
            changeLock = !changeLock;
            if(changeLock){CursorLocker.UnlockCursor();}
            else{CursorLocker.LockCursor();}
        }
    }
}