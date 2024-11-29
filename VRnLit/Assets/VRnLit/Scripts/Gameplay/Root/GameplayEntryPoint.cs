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
        
        public Observable<Unit> Run(DIContainer gameplayContainer, GameplayEnterParams enterParams)
        {
            //var cursorLocker = gameplayContainer.Resolve<CursorLocker>();
            MyPlayer myPlayer = null;
            
            if (enterParams.IsVR)
            {
                myPlayer = FindFirstObjectByType<MyPlayer>();
                _firstPerson.SetActive(false);
            }
            else
            {
                if (SteamVR.active)
                {
                    myPlayer = FindFirstObjectByType<MyPlayer>();
                    myPlayer.gameObject.SetActive(false);
                }
                _firstPerson.SetActive(true);
            }
            
            
            
            
            
            _firstPerson.SetActive(!enterParams.IsVR);
            //player.gameObject.SetActive(enterParams.IsVR);

            var exitToResultsSignalSubj = new Subject<Unit>();
            _binder.Bind(exitToResultsSignalSubj);
            
            Debug.Log($"GAMEPLAY ENTRY POINT: save file name = , level to load = ");
            
            return exitToResultsSignalSubj;
        }
    }
}