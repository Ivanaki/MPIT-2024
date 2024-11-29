using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VRnLit.Scripts.MainMenu.Aut;

namespace VRnLit.Scripts.MainMenu
{
    public class Register : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _name;
        [SerializeField] private TMP_InputField _email;
        [SerializeField] private TMP_InputField _password;
        [SerializeField] private Button _register;
        
        [SerializeField] private Authentication _auth;

        [SerializeField] private RegisterError _registerError;
        
        private void Awake()
        {
            _register.onClick.AddListener(() =>
            {
                if (_name.text == "" || _email.text == "" || _password.text == "")
                {
                    _registerError.ShowError(RegisterErrors.FillInAllFills);
                    return;
                }

                if (!_auth.RegisterUser(new UserData(_name.text, _email.text, _password.text)))
                {
                    _registerError.ShowError(RegisterErrors.ThisNameOrEmailIsAlreadyRegistered);
                }
            });
        }
        
        public void ResetValues()
        {
            _name.text = "";
            _email.text = "";
            _password.text = "";
        }
    }
}