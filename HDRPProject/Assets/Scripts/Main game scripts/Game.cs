using System;
using System.Collections.Generic;
using SaveSystemScripts;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Main_game_scripts
{
    public class Game : PersistantObject
    {
        private KeyBoardInputs _input;
        [SerializeField] private Transform prefab;
        private List<Transform> _objectsList;
        private string savePath;
        private void Awake()
        {
            _input = new KeyBoardInputs();
            _input.KeyBoard.Create.started += context => CreateObject();
            _input.KeyBoard.Load.started += context => LoadGame();
            _input.KeyBoard.Save.started += context => SaveGame();
            _input.KeyBoard.Quit.started += context => QuitGame();
            _objectsList = new List<Transform>();
            savePath = Application.persistentDataPath;
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

        private void QuitGame()
        {
            foreach (var t in _objectsList)
            {
                Destroy(t.gameObject);
            }

            _objectsList.Clear();
        }

        private void SaveGame()
        {
            
        }

        private void LoadGame()
        {
            
        }

        private void CreateObject () 
        {
            Transform t = Instantiate(prefab);
            t.localPosition = Random.insideUnitSphere * 5f;
            _objectsList.Add(t);
        }
    }
}
