using UnityEngine;
using UnityEngine.PlayerLoop;
using VRnLit.Scripts.Game;

namespace VRnLit.Scripts.Gameplay.Tasks
{
    public class TaskSystem : MonoBehaviour
    {
        [SerializeField] private GameObject _tsk1;
        [SerializeField] private GameObject _tsk2;
        //[SerializeField] private GameObject _tsk3;

        private Account _account;
        public void Initialization(Account account)
        {
            _account = account;
        }

        private bool flag1 = true;
        public void End1()
        {
            if (flag1)
            {
                flag1 = false;
                _tsk1.SetActive(false);
                Account.UserDataProperty.CurrentValue.Points++;
                _account.Save();
            }
        }
        
        private bool flag2 = true;
        public void End2()
        {
            if (flag2)
            {
                flag2 = false;
                _tsk2.SetActive(false);
                Account.UserDataProperty.CurrentValue.Points++;
                _account.Save();
            }
        }
        
        /*public void End3()
        {
            _tsk3.SetActive(false);
        }*/
    }
}