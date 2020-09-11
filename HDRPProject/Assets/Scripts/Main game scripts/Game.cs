using System.Collections.Generic;
using System.IO;
using SaveSystemScripts;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Main_game_scripts
{
    public class Game : PersistantObject
    {
        [SerializeField] private PersistantObject prefab;
        [SerializeField] private PersistantStorage storage;

        private KeyBoardInputs _input;
        private List<PersistantObject> _objectsList;

        private void Awake()
        {
            _input = new KeyBoardInputs();
            _input.KeyBoard.Create.started += context => CreateObject();
            _input.KeyBoard.Load.started += context => LoadGame();
            _input.KeyBoard.Save.started += context => SaveGame();
            _input.KeyBoard.Quit.started += context => QuitGame();
            _objectsList = new List<PersistantObject>();

        }

        private void OnEnable()
        {
            _input.KeyBoard.Enable();

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
                Destroy(t.gameObject);
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
            storage.Save(this, 1);
        }

        private void CreateObject()
        {
            PersistantObject enemyObject = Instantiate(prefab);
            Transform t = enemyObject.transform;
            t.localPosition = Random.insideUnitSphere * 5f;
            _objectsList.Add(enemyObject);
        }

        public override void Save(GameDataWriter writer)
        {
            writer.Write(_objectsList.Count);
            foreach (var t in _objectsList)
            {
                t.Save(writer);
            }
        }
        
        public override void Load (GameDataReader reader) 
        {
            int count = reader.ReadInt();
            for (int i = 0; i < count; i++) 
            {
                PersistantObject o = Instantiate(prefab);
                o.Load(reader);
                _objectsList.Add(o);
            }
        }
    }
}
