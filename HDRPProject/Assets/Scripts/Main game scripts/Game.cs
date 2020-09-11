using System;
using SaveSystemScripts;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Main_game_scripts
{
    public class Game : PersistantObject
    {
        private InputPrefs _input;
        [SerializeField] private Transform prefab;

        private void Awake()
        {
            _input = new InputPrefs();
        }

        private void OnEnable()
        {
            
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        void CreateObject () 
        {
            Transform t = Instantiate(prefab);
            t.localPosition = Random.insideUnitSphere * 5f;
        }
    }
}
