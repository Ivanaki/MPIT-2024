namespace VRnLit.Scripts
{
    public class PlayerSave
    {
        private static PlayerSave instance;
        public static PlayerSave GetInstance()
        {
            return instance ??= new PlayerSave();
        }

        
        
        public void Save()
        {
            
        }
    }
}