using BaCon;
using Electrical.Scripts._3MainMenu.Root;
using MySteamVR;
using PogruzhickURP.Scripts.SaveLaod;
using R3;
using UnityEngine;
using VRnLit.Scripts.Game;
using VRnLit.Scripts.Game.Params;
using VRnLit.Scripts.MainMenu.Aut;
using VRnLit.Scripts.Utils;

namespace VRnLit.Scripts.MainMenu
{
    public class MainMenuEntryPoint : MonoBehaviour
    {
        [SerializeField] private UIMainMenuBinder _binder;
        [SerializeField] private Tick _isVr;

        [SerializeField] private Authentication _auth;

        [SerializeField] private GameObject _eventSystem;
        
        public Observable<MainMenuExitParams> Run(DIContainer gameplayContainer)
        {
            _auth.Initialize(gameplayContainer.Resolve<ILoadSaveService>(), gameplayContainer.Resolve<Account>());

            if (FindFirstObjectByType<MyPlayer>() != null)
            {
                _eventSystem.SetActive(false);
            }
            
            //bind UI
            var exitToResultsSignalSubj = new Subject<Unit>();
            _binder.Bind(exitToResultsSignalSubj);
            
            Debug.Log($"MainMenu ENTRY POINT: save file name = , level to load = ");
            
            var exit = exitToResultsSignalSubj.Select(_ => new MainMenuExitParams(new GameplayEnterParams(_isVr.Ticking)));
            
            return exit;
        }

    }
}