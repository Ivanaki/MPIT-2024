using System;
using R3;
using TMPro;
using UnityEngine;
using VRnLit.Scripts.Game;

namespace VRnLit.Scripts.MainMenu
{
    public class ShowAccName : MonoBehaviour
    {
        [SerializeField] private TMP_Text _accNameText;
        [SerializeField] private TMP_Text _pointsText;

        private IDisposable _subscription;
        private IDisposable _subscription2;
        
        private void Start()
        {
            _subscription = Account.UserDataProperty.Subscribe(userData =>
            {
                if (userData != null)
                {
                    _accNameText.text = userData.Username;
                }
            });
            _subscription2 = Account.UserDataProperty.Subscribe(userData =>
            {
                if (userData != null)
                {
                    _pointsText.text = userData.Points.ToString();
                }
            });
        }

        private void OnDestroy()
        {
            _subscription?.Dispose();
            _subscription2?.Dispose();
        }
    }
}