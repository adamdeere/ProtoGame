using System;
using SpawnItemScripts.SpawnZones;
using UnityEngine;

namespace Main_game_scripts
{
    public class GameLevel : MonoBehaviour
    {
        [SerializeField] private SpawnZone spawnZone;

        public void Start () 
        {
            Game.Instance.SpawnZoneOfLevel = spawnZone;
        }
    }
}
