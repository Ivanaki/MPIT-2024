using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VRnLit.Scripts.MainMenu
{
    public class Authentication : MonoBehaviour
    {
        [SerializeField] private MainMenuCanvas _mainMenuCanvas;

        [SerializeField] private Button _loginButton;
        [SerializeField] private Button _registerButton;

        [SerializeField] private Enter _loginPanel;
        [SerializeField] private Register _registerPanel;
        
        [SerializeField] private List<UserData> _users = new List<UserData>();

        private void Awake()
        {
            _loginButton.onClick.AddListener(OpenLogin);
            _registerButton.onClick.AddListener(OpenRegister);
            
            _registerPanel.gameObject.SetActive(false);
            _loginPanel.gameObject.SetActive(false);
        }

        public void CloseAll()
        {
            _registerPanel.gameObject.SetActive(false);
            _loginPanel.gameObject.SetActive(false);
        }
        
        private void OpenRegister()
        {
            _registerPanel.gameObject.SetActive(true);
            _loginPanel.gameObject.SetActive(false);
            _registerPanel.ResetValues();
        }
        
        private void OpenLogin()
        {
            _loginPanel.gameObject.SetActive(true);
            _registerPanel.gameObject.SetActive(false);
            _loginPanel.ResetValues();
        }
        
        public void RegisterUser(UserData userData)
        {
            _users.Add(userData);
            OpenLogin();
        }
        
        public bool TryAuthenticate(string username, string password)
        {
            var flag = false;
            foreach (var t in _users)
            {
                if (t.Username == username || t.Email == username)
                {
                    if (t.Password == password)
                    {
                        flag = true;
                        break;
                    }
                }
            }

            if (flag)
            {
                AuthenticateAccess();
            }
            
            return flag;
        }

        private void AuthenticateAccess()
        {
            _mainMenuCanvas.EndAuthentication();
        }
    }
}