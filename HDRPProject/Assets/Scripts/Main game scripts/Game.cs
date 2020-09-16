using System;
using System.Collections.Generic;
using SaveSystemScripts;
using Shape_Data;
using Shape_Data.ShapeFactory;
using SpawnItemScripts.SpawnZones;
using UnityEngine;
using UnityEngine.Serialization;
using UtilityScripts;
using Random = UnityEngine.Random;

namespace Main_game_scripts
{
    public class Game : PersistantObject
    {
        private const int SaveVersion = 1;
        
        [SerializeField] private ShapeFactory _shapeFactory;
        [SerializeField] private PersistantStorage storage;
        [FormerlySerializedAs("_shapeCount")] [SerializeField] private int shapeCount = 30;
        [FormerlySerializedAs("_resetPosition")] [SerializeField] private Transform resetPosition; 
        public SpawnZone SpawnZoneOfLevel { get; set; }
        
        public static Game Instance { get; private set; }

        private KeyBoardInputs _input;
        private List<Shape> _objectsList;

        [FormerlySerializedAs("CreationSpeed")] [SerializeField] private float creationSpeed;
        private float _creationProgress;

        private bool _levelActive = true;

        public Transform ResetPos()
        {
            return resetPosition;
        }
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
            NextSceneScript.ResetLevel += ResetGameLevel;
        }

        private void Start()
        { 
            InitiateShapes(shapeCount);
        }
        public void Update () 
        {
            _creationProgress += Time.deltaTime * creationSpeed;
            while (_creationProgress >= 1f) 
            {
                _creationProgress -= 1f;
                if (_levelActive)
                {
                    ActivateObject();
                }
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
            NextSceneScript.ResetLevel -= ResetGameLevel;
        }

        private void ResetGameLevel(bool active)
        {
            _levelActive = active;
            foreach (var t in _objectsList)
            {
                t.DoDamage();
            }
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

        private Shape GetRandom ()
        {
            foreach (var t in _objectsList)
            {
                var index = (Random.Range(0, _objectsList.Count));
                if (!t.gameObject.activeSelf)
                {
                    _objectsList[index].transform.gameObject.SetActive(true);
                    return _objectsList[index];
                }
            }
            return null;
        }
        private void ActivateObject()
        {
            Shape instance = GetRandom();
            if (instance != null)
            {
                var t = instance.transform;
                var pos = SpawnZoneOfLevel.SpawnPoint;
                //we will need to find a better method of doing this. we may need to find a half way point of the mesh and add it to the Y value
                pos.y = 10f;
                t.transform.localPosition = pos;
            }
        }
        private void CreateObject()
        {
            var instance = _shapeFactory.GetRandom();
            var t = instance.transform;
            t.transform.localPosition = resetPosition.transform.localPosition;
            t.gameObject.SetActive(false);
            _objectsList.Add(instance);
        }
        public override void Save(GameDataWriter writer)
        {
            writer.Write(_objectsList.Count);
            foreach (var t in _objectsList)
            {
                writer.Write(t.ShapeId);
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
                Shape instance = _shapeFactory.Get(shapeId);
                instance.Load(reader);
                _objectsList.Add(instance);
            }
        }

        private void InitiateShapes(int count)
        {
            for (int i = 0; i < count; i++)
            {
                CreateObject();
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
