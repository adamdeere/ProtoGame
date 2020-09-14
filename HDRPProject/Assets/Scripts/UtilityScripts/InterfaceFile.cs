using SpawnItemScripts.SpawnZones;

namespace UtilityScripts
{
    public delegate void AddToSpawnZone(SpawnZone zone);
    
    public interface IKillableZombie
    {
        void DoDamage();
    }
    
    public interface IKillablePlayer
    {
        void DoDamage();
    }
}