using BaCon;
using MySteamVR;
using PogruzhickURP.Scripts.Gameplay.Root;
using R3;
using UnityEngine;
using VRnLit.Scripts.Game.Params;

namespace VRnLit.Scripts.Gameplay
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [SerializeField] private UIGameplayRootBinder _binder;
        [SerializeField] private GameObject _firstPerson;
        
        public Observable<Unit> Run(DIContainer gameplayContainer, GameplayEnterParams enterParams)
        {
            var player = FindFirstObjectByType<MyPlayer>();
            
            _firstPerson.SetActive(!enterParams.IsVR);
            player.gameObject.SetActive(enterParams.IsVR);

            var exitToResultsSignalSubj = new Subject<Unit>();
            _binder.Bind(exitToResultsSignalSubj);
            
            Debug.Log($"GAMEPLAY ENTRY POINT: save file name = , level to load = ");
            
            return exitToResultsSignalSubj;
        }
    }
}