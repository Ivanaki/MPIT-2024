using BaCon;
using Electrical.Scripts._3MainMenu.Root;
using R3;
using UnityEngine;
using VRnLit.Scripts.Game.Params;
using VRnLit.Scripts.Utils;

namespace VRnLit.Scripts.MainMenu
{
    public class MainMenuEntryPoint : MonoBehaviour
    {
        [SerializeField] private UIMainMenuBinder _binder;
        [SerializeField] private Tick _isVr;
        
        public Observable<MainMenuExitParams> Run(DIContainer gameplayContainer)
        {
            //bind UI
            var exitToResultsSignalSubj = new Subject<Unit>();
            _binder.Bind(exitToResultsSignalSubj);
            
            Debug.Log($"GAMEPLAY ENTRY POINT: save file name = , level to load = ");
            
            var exit = exitToResultsSignalSubj.Select(_ => new MainMenuExitParams(new GameplayEnterParams(_isVr.Ticking)));
            
            return exit;
        }

    }
}