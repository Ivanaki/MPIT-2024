using System;
using R3;
using TMPro;
using UnityEngine;
using VRnLit.Scripts.Game;

namespace VRnLit.Scripts.MainMenu
{
    public class ShowAccName : MonoBehaviour
    {
        [SerializeField] private TMP_Text accNameText;

        private IDisposable _subscription;
        
        private void Start()
        {
            _subscription = Account.UserDataProperty.Subscribe(userData =>
            {
                if (userData != null)
                {
                    accNameText.text = userData.Username;
                }
            });
        }

        private void OnDestroy()
        {
            _subscription?.Dispose();
        }
    }
}