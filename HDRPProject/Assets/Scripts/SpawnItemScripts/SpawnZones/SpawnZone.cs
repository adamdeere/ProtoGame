using JetBrains.Annotations;
using SaveSystemScripts;
using Shape_Data;
using UnityEngine;

namespace SpawnItemScripts.SpawnZones
{
    public abstract class SpawnZone : PersistantObject
    {
        public abstract Vector3 SpawnPoint { get; }
        
        private float _spawnProgress;
        
        
        // public override void Save (GameDataWriter writer) 
        // {
        //     writer.Write(_spawnProgress);
        // }
        //
        // public override void Load (GameDataReader reader) 
        // {
        //     _spawnProgress = reader.ReadFloat();
        // }

        public virtual void SpawnShape()
        {
            
        }

        private void SetupOscillation(Shape shape)
        {
            
        }

        private void CreateSatelliteFor([NotNull] Shape focalShape, Vector3 durations)
        {
            
        }

        void SetupColor(Shape shape)
        {
            
        }

        void SetupLifecycle(Shape shape, Vector3 durations)
        {
            
        }
        
    }
}
