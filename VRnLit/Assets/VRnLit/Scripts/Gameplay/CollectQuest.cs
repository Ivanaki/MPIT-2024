using Unity.VisualScripting;
using UnityEngine;

namespace VRnLit.Scripts.Gameplay
{
    public class CollectQuest : MonoBehaviour
    {
        [SerializeField] private GameObject[] _collectObjects;

        private void Find(GameObject obj)
        {
            bool flag = false;
            foreach (var collectObject in _collectObjects)
            {
                if (collectObject == obj)
                {
                    flag = true;
                }
            }

            if (flag)
            {
                
            }
        }
    }
}