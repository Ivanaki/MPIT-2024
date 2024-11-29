using UnityEngine;

namespace VRnLit.Scripts.Gameplay.Tasks
{
    public class TaskSystem : MonoBehaviour
    {
        [SerializeField] private GameObject _tsk1;
        [SerializeField] private GameObject _tsk2;
        [SerializeField] private GameObject _tsk3;
        
        public void End1()
        {
            _tsk1.SetActive(false);
        }
        
        public void End2()
        {
            _tsk2.SetActive(false);
        }
        
        public void End3()
        {
            _tsk3.SetActive(false);
        }
    }
}