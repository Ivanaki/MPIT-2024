using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VRnLit.Scripts.MainMenu
{
    public class Register : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _name;
        [SerializeField] private TMP_InputField _email;
        [SerializeField] private TMP_InputField _password;
        [SerializeField] private Button _register;
        
        [SerializeField] private Authentication _auth;
        
        private void Awake()
        {
            _register.onClick.AddListener(() =>
            {
                _auth.RegisterUser(new UserData(_name.text, _email.text, _password.text));
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