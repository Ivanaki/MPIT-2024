using BaCon;
using MySteamVR;
using PogruzhickURP.Scripts.Gameplay.Root;
using R3;
using UnityEngine;
using Valve.VR;
using VRnLit.Scripts.Game.Params;

namespace VRnLit.Scripts.Gameplay
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [SerializeField] private UIGameplayRootBinder _binder;
        [SerializeField] private GameObject _firstPerson;
        
        private MyPlayer _player;
        
        public Observable<Unit> Run(DIContainer gameplayContainer, GameplayEnterParams enterParams)
        {
            //var cursorLocker = gameplayContainer.Resolve<CursorLocker>();
            
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
            
            Debug.Log($"GAMEPLAY ENTRY POINT: save file name = , level to load = ");
            
            return exitToResultsSignalSubj;
        }
    }
}