using SaveSystemScripts;
using UnityEngine;

namespace Main_game_scripts
{
    public class Game : PersistantObject
    {
        //used to create a shape. needs deleting when finished with
        

        [SerializeField] private Transform prefab;
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
