using System;
using System.Collections.Generic;
using System.IO;
using SaveSystemScripts;
using Shape_Data;
using Shape_Data.ShapeFactory;
using SpawnItemScripts.SpawnZones;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Main_game_scripts
{
    public class Game : PersistantObject
    {
        private const int SaveVersion = 1;
        
        [SerializeField] private ShapeFactory _shapeFactory;
        [SerializeField] private PersistantStorage storage;

        public SpawnZone SpawnZoneOfLevel { get; set; }
        
        public static Game Instance { get; private set; }

        private KeyBoardInputs _input;
        private List<Shape> _objectsList;

        [SerializeField] private float CreationSpeed;
        private float creationProgress;


        private void Awake()
        {
            Instance = this;
            _input = new KeyBoardInputs();
            _input.KeyBoard.Create.started += context => CreateObject();
            _input.KeyBoard.Load.started += context => LoadGame();
            _input.KeyBoard.Save.started += context => SaveGame();
            _input.KeyBoard.Quit.started += context => QuitGame();
            _objectsList = new List<Shape>();

        }

        private void OnEnable()
        {
            _input.KeyBoard.Enable();
        }

        private void Start()
        {
           
        }

        public void Update () 
        {
            creationProgress += Time.deltaTime * CreationSpeed;
            while (creationProgress >= 1f) 
            {
                creationProgress -= 1f;
                CreateObject();
            }
        }
        private void OnDisable()
        {
            _input.KeyBoard.Disable();
            // ReSharper disable once EventUnsubscriptionViaAnonymousDelegate
            _input.KeyBoard.Create.started -= context => CreateObject();
            // ReSharper disable once EventUnsubscriptionViaAnonymousDelegate
            _input.KeyBoard.Load.started -= context => LoadGame();
            // ReSharper disable once EventUnsubscriptionViaAnonymousDelegate
            _input.KeyBoard.Save.started -= context => SaveGame();
            // ReSharper disable once EventUnsubscriptionViaAnonymousDelegate
            _input.KeyBoard.Quit.started -= context => QuitGame();
        }

        /// <summary>
        /// quit game is linked to a keyboard, new game acts as a clear scene
        /// </summary>
        private void QuitGame()
        {
            NewGame();
        }

        private void NewGame()
        {
            foreach (var t in _objectsList)
            {
                _shapeFactory.Reclaim(t);
            }

            _objectsList.Clear();
        }

        private void LoadGame()
        {
            NewGame();
            storage.Load(this);
        }

        private void SaveGame()
        {
            storage.Save(this, SaveVersion);
        }

        private void CreateObject()
        {
            Shape instance = _shapeFactory.GetRandom();
            Transform t = instance.transform;
            Vector3 pos = t.localPosition;
            pos = SpawnZoneOfLevel.SpawnPoint;
            pos.y = 10;
            t.localPosition = pos;
            t.rotation = SpawnZoneOfLevel.SpawnRotation;
            instance.SetColor(Random.ColorHSV(0f, 1f, 0.5f, 1f, 0.25f, 1f, 1f, 1f));
            _objectsList.Add(instance);
        }

        public override void Save(GameDataWriter writer)
        {
            writer.Write(_objectsList.Count);
            foreach (var t in _objectsList)
            {
                writer.Write(t.ShapeId);
                writer.Write(t.MaterialId);
                t.Save(writer);
            }
        }
        
        public override void Load (GameDataReader reader) 
        {
            int version = reader.Version;
            int count = version <= 0 ? -version : reader.ReadInt();
            if (version > SaveVersion) 
            {
                Debug.LogError("Unsupported future save version " + version);
                return;
            }
            for (int i = 0; i < count; i++) 
            {
                int shapeId = version > 0 ? reader.ReadInt() : 0;
                int materialId = version > 0 ? reader.ReadInt() : 0;
                Shape instance = _shapeFactory.Get(shapeId, materialId);
                instance.Load(reader);
                _objectsList.Add(instance);
            }
        }
        void DestroyShape () 
        {
            if (_objectsList.Count > 0) 
            {
                int index = Random.Range(0, _objectsList.Count);
                _shapeFactory.Reclaim(_objectsList[index]);
                int lastIndex = _objectsList.Count - 1;
                _objectsList[index] = _objectsList[lastIndex];
                _objectsList.RemoveAt(lastIndex);
            }
        }
    }
}
