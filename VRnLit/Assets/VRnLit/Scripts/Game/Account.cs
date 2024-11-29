using System.Collections.Generic;
using PogruzhickURP.Scripts.SaveLaod;
using R3;
using VRnLit.Scripts.MainMenu;
using VRnLit.Scripts.MainMenu.Aut;

namespace VRnLit.Scripts.Game
{
    public class Account
    {
        //public static UserData UserData { get; private set; } = null;
        
        private static ReactiveProperty<UserData> _userDataProperty { get; } = new();
        public static ReadOnlyReactiveProperty<UserData> UserDataProperty => _userDataProperty;

        private ILoadSaveService _loadSaveService;
        
        public Account(ILoadSaveService loadSaveService)
        {
            _loadSaveService = loadSaveService;
        }
        
        public void UserLogged(UserData userData)
        {
            _userDataProperty.Value = userData;  
        }

        public void Unlogged()
        {
            _userDataProperty.Value = null;  
        }

        public void Save()
        {
            _loadSaveService.Load<Dictionary<string, UserData>>(Authentication.SAVE_KEY).Subscribe(call =>
            {
                var o = (Dictionary<string, UserData>)call.Value;
                o[UserDataProperty.CurrentValue.Username] = UserDataProperty.CurrentValue;
                _loadSaveService.Save(Authentication.SAVE_KEY, o);
            });
        }
    }
}