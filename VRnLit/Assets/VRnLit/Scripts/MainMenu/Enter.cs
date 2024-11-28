using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VRnLit.Scripts.MainMenu
{
    public class Enter : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _name;
        [SerializeField] private TMP_InputField _password;
        [SerializeField] private Button _enter;

        [SerializeField] private Authentication _auth;

        [SerializeField] private GameObject _errorPanel;

        private void Awake()
        {
            _errorPanel.SetActive(false);
            
            _enter.onClick.AddListener(() =>
            {
                if (!_auth.TryAuthenticate(_name.text, _password.text))
                {
                    StartCoroutine(ShowError());
                }
            });
        }

        private IEnumerator ShowError()
        {
            _errorPanel.SetActive(true);
            yield return new WaitForSeconds(4f);
            _errorPanel.SetActive(false);
        }
        
        public void ResetValues()
        {
            _name.text = "";
            _password.text = "";
        }
    }
}