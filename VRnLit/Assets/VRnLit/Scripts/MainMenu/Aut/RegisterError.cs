using System.Collections;
using TMPro;
using UnityEngine;

namespace VRnLit.Scripts.MainMenu
{
    public class RegisterError : MonoBehaviour
    {
        [SerializeField] private TMP_Text _errorText;

        public void ShowError(RegisterErrors registerErrors)
        {
            switch (registerErrors)
            {
                case RegisterErrors.FillInAllFills:
                    _errorText.text = "Заполните все поля";
                    break;
                case RegisterErrors.ThisNameOrEmailIsAlreadyRegistered:
                    _errorText.text = "Это имя или емаил адрес уже зарегестированы";
                    break;
            }

            StartCoroutine(ShowErrorEnum());
        }
        
        private IEnumerator ShowErrorEnum()
        {
            _errorText.gameObject.SetActive(true);
            yield return new WaitForSeconds(4f);
            _errorText.gameObject.SetActive(false);
        }
    }

    public enum RegisterErrors
    {
        FillInAllFills,
        ThisNameOrEmailIsAlreadyRegistered,
    }
}