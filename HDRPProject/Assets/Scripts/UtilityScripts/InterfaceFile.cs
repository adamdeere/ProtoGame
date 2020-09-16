using SpawnItemScripts.SpawnZones;
using UnityEngine;

namespace UtilityScripts
{
    public delegate void AddToSpawnZone(SpawnZone zone);
    public delegate GameObject ReturnPlayerFunction();

    public delegate void IncreaseTheKill();

    public delegate void ResetTheLevel(bool active);

    public delegate void RepositionPlayer(Transform trans);
    public delegate void TurnPlayerOff();

    public interface IZombie
    {
        void DoDamage(float damage, out bool isDead);
    }
    
    public interface IPlayer
    {
        void DoDamage(float health);
    }
}