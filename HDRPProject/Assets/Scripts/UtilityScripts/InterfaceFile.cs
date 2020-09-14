using SpawnItemScripts.SpawnZones;

namespace UtilityScripts
{
    public delegate void AddToSpawnZone(SpawnZone zone);
    
    public interface IKillable
    {
        void DoDamage();
       // void DamagePlayer();
    }
}