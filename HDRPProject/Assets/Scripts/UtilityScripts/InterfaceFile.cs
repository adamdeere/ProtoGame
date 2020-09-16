using SpawnItemScripts.SpawnZones;
using UnityEngine;

namespace UtilityScripts
{
    public delegate void AddToSpawnZone(SpawnZone zone);
    public delegate GameObject ReturnPlayerFunction();

    public delegate void IncreaseTheKill();

    public delegate void ResetTheLevel(bool active); 

    public interface IZombie
    {
        void DoDamage();
    }
    
    public interface IPlayer
    {
        void DoDamage(float health);
    }
}