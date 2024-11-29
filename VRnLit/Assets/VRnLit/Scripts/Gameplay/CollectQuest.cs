using UnityEngine;
using VRnLit.Scripts.Gameplay.Tasks;

namespace VRnLit.Scripts.Gameplay
{
    public class CollectQuest : MonoBehaviour
    {
        [SerializeField] private GameObject[] _collectObjects;
        [SerializeField]private int _count = 0;

        [SerializeField] private TaskSystem _taskSystem;

        private void OnTriggerEnter(Collider other)
        {
            if (Find(other.gameObject))
            {
                if (_count < _collectObjects.Length)
                {
                    _count++;
                    if (_count == _collectObjects.Length)
                    {
                        _taskSystem.End1();   
                    }
                }
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (Find(other.gameObject))
            {
                if (_count > 0)
                {
                    _count--;
                }
            }
        }

        private bool Find(GameObject obj)
        {
            bool flag = false;
            foreach (var collectObject in _collectObjects)
            {
                if (collectObject == obj)
                {
                    flag = true;
                }
            }

            return flag;
        }
    }
}