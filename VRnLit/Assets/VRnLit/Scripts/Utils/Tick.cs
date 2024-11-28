using UnityEngine;

namespace VRnLit.Scripts.Utils
{
    public class Tick : MonoBehaviour
    {
        [SerializeField] private GameObject _tickObject;
        public bool Ticking { get; private set; } = false;

        private void Awake()
        {
            _tickObject.SetActive(false);
        }
        
        public void Click()
        {
            Ticking = !Ticking;
            _tickObject.SetActive(Ticking);
        }
    }
}