using UnityEngine;

namespace VRnLit.Scripts.Gameplay
{
    public interface ITake
    {
        void Take();
        void Drop();
        void AddVelocity(Vector3 velocity);
    }
}