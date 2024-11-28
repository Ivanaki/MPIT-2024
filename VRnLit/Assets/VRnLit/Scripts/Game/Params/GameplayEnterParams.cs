namespace VRnLit.Scripts.Game.Params
{
    public class GameplayEnterParams
    {
        public bool IsVR {get;} 

        public GameplayEnterParams(bool isVR)
        {
            IsVR = isVR;
        }
    }
}