using System;
using System.Collections.Generic;
using SaveSystemScripts;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SpawnItemScripts.SpawnZones
{
    public class CompositeSpawnZone : SpawnZone
    {
       // [SerializeField] private SpawnZone[] spawnZones;
        [SerializeField] private bool sequential;
        [SerializeField] private bool overrideConfig;
        private int _nextSequentialIndex;
        private List<SpawnZone> spawnZones;
        
        private void Awake()
        {
            spawnZones = new List<SpawnZone>();
            CubeSpawn.AddSpawn += AddSpawnZone;
            SphereSpawn.AddSpawn += AddSpawnZone;
        }

        private void Start()
        {
            int i = spawnZones.Count;
        }

        private void AddSpawnZone(SpawnZone zone)
        {
            spawnZones.Add(zone);
        }

        private void OnDestroy()
        {
            CubeSpawn.AddSpawn -= AddSpawnZone;
            SphereSpawn.AddSpawn -= AddSpawnZone;
        }

        public override Vector3 SpawnPoint 
        {
            get 
            {
                int index;
                if (sequential) 
                {
                    index = _nextSequentialIndex++;
                    if (_nextSequentialIndex >= spawnZones.Count) 
                    {
                        _nextSequentialIndex = 0;
                    }
                }
                else 
                {
                    index = Random.Range(0, spawnZones.Count);
                }
                return spawnZones[index].SpawnPoint;
            }
        }
        
        public override void SpawnShape () 
        {
            if (overrideConfig) 
                base.SpawnShape();
        
            else 
            {
                int index;
                if (sequential) 
                {
                    index = _nextSequentialIndex++;
                    if (_nextSequentialIndex >= spawnZones.Count) 
                    {
                        _nextSequentialIndex = 0;
                    }
                }
                else 
                { 
                    index = Random.Range(0, spawnZones.Count);
                }
                spawnZones[index].SpawnShape();
            }
        }
        public override void Save (GameDataWriter writer) 
        {
            base.Save(writer);
            writer.Write(_nextSequentialIndex);
        }
        
        public override void Load (GameDataReader reader) 
        {
            if (reader.Version >= 7)
            {
                base.Load(reader);
            }
            _nextSequentialIndex = reader.ReadInt();
        }
    }
}
