using R3;
using VRnLit.Scripts.MainMenu;

namespace VRnLit.Scripts.Game
{
    public class Account
    {
        //public static UserData UserData { get; private set; } = null;
        
        private static ReactiveProperty<UserData> _userDataProperty { get; } = new();
        public static ReadOnlyReactiveProperty<UserData> UserDataProperty => _userDataProperty;
        
        public void UserLogged(UserData userData)
        {
            _userDataProperty.Value = userData;  
        }

        public void Unlogged()
        {
            _userDataProperty.Value = null;  
        }
    }
}