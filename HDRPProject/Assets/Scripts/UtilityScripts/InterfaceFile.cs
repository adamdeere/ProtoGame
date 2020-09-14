using SpawnItemScripts.SpawnZones;
using UnityEngine;

namespace UtilityScripts
{
    public delegate void AddToSpawnZone(SpawnZone zone);
    public delegate GameObject ReturnPlayerFunction();
    
    public interface IKillableZombie
    {
        void DoDamage();
    }
    
    public interface IKillablePlayer
    {
        void DoDamage(float health);
    }
}