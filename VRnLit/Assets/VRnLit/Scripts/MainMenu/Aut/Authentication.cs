using System.Collections.Generic;
using PogruzhickURP.Scripts.SaveLaod;
using R3;
using UnityEngine;
using UnityEngine.UI;
using VRnLit.Scripts.Game;

namespace VRnLit.Scripts.MainMenu.Aut
{
    public class Authentication : MonoBehaviour
    {
        public const string SAVE_KEY = nameof(SAVE_KEY);
        
        [SerializeField] private MainMenuCanvas _mainMenuCanvas;

        [SerializeField] private Button _loginButton;
        [SerializeField] private Button _registerButton;

        [SerializeField] private Enter _loginPanel;
        [SerializeField] private Register _registerPanel;
        
        //[SerializeField] private List<UserData> _users = new List<UserData>();
        private Dictionary<string, UserData> _userData = new();
        
        private ILoadSaveService _saveService;
        private Account _account;

        private void Awake()
        {
            _loginButton.onClick.AddListener(OpenLogin);
            _registerButton.onClick.AddListener(OpenRegister);
            
            _registerPanel.gameObject.SetActive(false);
            _loginPanel.gameObject.SetActive(false);
            
            if (Account.UserDataProperty.CurrentValue != null)
            {
                Debug.Log("user is already logged in");
                CloseAll();
                _mainMenuCanvas.EndAuthentication();
            }
        }

        public void Initialize(ILoadSaveService saveService, Account account)
        {
            _saveService = saveService;
            _account = account;

            _saveService.Load<Dictionary<string, UserData>>(SAVE_KEY).Subscribe(loadCallback =>
            {
                if (loadCallback.Callback == SavesStateEnum.FileWithKeyDontExists)
                {
                    print("no load callback");
                }
                if (loadCallback.Callback == SavesStateEnum.Complete)
                {
                    _userData = (Dictionary<string, UserData>)loadCallback.Value;
                }
            });

            
        }

        public void ExitAccount()
        {
            _account.Unlogged();
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
        
        public bool RegisterUser(UserData userData)
        {
            if (!_userData.TryAdd(userData.Username, userData))
            {
                return false;
            }

            _saveService.Save(SAVE_KEY, _userData);
            OpenLogin();
            return true;
        }
        
        public bool TryAuthenticate(string username, string password)
        {
            if(_userData.TryGetValue(username, out var value))
            {
                if (value.Password == password)
                {
                    AuthenticateAccess(_userData[username]);
                    return true;
                }
            }
            
            return false;
        }

        private void AuthenticateAccess(UserData userData)
        {
            CloseAll();
            _account.UserLogged(userData);
            _mainMenuCanvas.EndAuthentication();
        }
    }
}