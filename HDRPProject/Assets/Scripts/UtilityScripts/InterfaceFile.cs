using SpawnItemScripts.SpawnZones;
using UnityEngine;

namespace UtilityScripts
{
    public delegate void AddToSpawnZone(SpawnZone zone);
    public delegate GameObject ReturnPlayerFunction();

    public delegate void IncreaseTheKill();

    public delegate void ResetTheLevel(bool active); 

    public interface IKillableZombie
    {
        void DoDamage();
    }
    
    public interface IKillablePlayer
    {
        void DoDamage(float health);
    }
}