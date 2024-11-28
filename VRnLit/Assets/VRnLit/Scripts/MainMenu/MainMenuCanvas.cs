using UnityEngine;

namespace VRnLit.Scripts.MainMenu
{
    public class MainMenuCanvas : MonoBehaviour
    {
        [SerializeField] private GameObject _authenticationPanel;
        [SerializeField] private GameObject _mainPanel;

        private void Start()
        {
            _mainPanel.SetActive(false);
            _authenticationPanel.SetActive(true);
        }

        public void EndAuthentication()
        {
            _authenticationPanel.SetActive(false);
            _mainPanel.SetActive(true);
        }
    }
}