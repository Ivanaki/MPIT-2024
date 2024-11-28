using R3;
using UnityEngine;

namespace PogruzhickURP.Scripts.Gameplay.Root
{
    public class UIGameplayRootBinder : MonoBehaviour
    {
        private Subject<Unit> _exitToResultsSignalSubj;

        public void Bind(Subject<Unit> exitToResultsSignalSubj)
        {
            _exitToResultsSignalSubj = exitToResultsSignalSubj;
        }
        
        public void HandleGoToResultButtonClick()
        {
            _exitToResultsSignalSubj?.OnNext(Unit.Default);
        }
    }
}
