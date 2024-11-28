namespace VRnLit.Scripts.MainMenu
{
    [System.Serializable]
    public class UserData
    {
        public string Username;
        public string Email;
        public string Password;

        public int Points;

        public UserData(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }
    }
}