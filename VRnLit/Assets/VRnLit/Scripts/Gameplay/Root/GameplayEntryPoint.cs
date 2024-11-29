using BaCon;
using MySteamVR;
using PogruzhickURP.Scripts.Gameplay.Root;
using R3;
using UnityEngine;
using Valve.VR;
using VRnLit.Scripts.Game;
using VRnLit.Scripts.Game.Params;
using VRnLit.Scripts.Gameplay.Tasks;

namespace VRnLit.Scripts.Gameplay
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [SerializeField] private UIGameplayRootBinder _binder;
        [SerializeField] private GameObject _firstPerson;

        [SerializeField] private TaskSystem _taskSystem;
        
        private MyPlayer _player;
        
        public Observable<Unit> Run(DIContainer gameplayContainer, GameplayEnterParams enterParams)
        {
            //var cursorLocker = gameplayContainer.Resolve<CursorLocker>();
            
            _taskSystem.Initialization(gameplayContainer.Resolve<Account>());
            
            if (SteamVR.active)
            {
                _player = FindFirstObjectByType<MyPlayer>();
                if (enterParams.IsVR)
                {
                    _player.gameObject.SetActive(true);
                    _firstPerson.SetActive(false);
                }
                else
                {
                    _player.gameObject.SetActive(false);
                    _firstPerson.SetActive(true);
                }
            }
            else
            {
                _firstPerson.SetActive(true);
            }
            
            
            _firstPerson.SetActive(!enterParams.IsVR);
            //player.gameObject.SetActive(enterParams.IsVR);

            var exitToResultsSignalSubj = new Subject<Unit>();
            _binder.Bind(exitToResultsSignalSubj);

            exitToResultsSignalSubj.Subscribe(_ =>
            {
                _player.gameObject.SetActive(true);
            });
            
            Debug.Log($"GAMEPLAY ENTRY POINT: vr is {enterParams.IsVR}");
            
            return exitToResultsSignalSubj;
        }
    }
}