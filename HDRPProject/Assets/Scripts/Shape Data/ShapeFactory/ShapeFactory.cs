using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace Shape_Data.ShapeFactory
{
    [CreateAssetMenu]
    public class ShapeFactory : ScriptableObject
    {
        [SerializeField] private Shape[] prefabs;
       
        [SerializeField] private bool recycle;
      
        private List<Shape>[] _pools;
        private Scene _poolScene;
        [NonSerialized] private int factoryId = int.MinValue;
        
        public Shape GetRandom () 
        {
            return Get(Random.Range(0, prefabs.Length));
        }
        public void Reclaim (Shape shapeToRecycle) 
        {
            if (recycle) 
            {
                if (_pools == null) 
                {
                    CreatePools();
                }
                _pools[shapeToRecycle.ShapeId].Add(shapeToRecycle);
                shapeToRecycle.gameObject.SetActive(false);
            }
            else
            {
                Destroy(shapeToRecycle.gameObject);
            }
        }
        public Shape Get (int shapeId = 0) 
        {
            Shape instance;
            if (recycle) 
            {
                if (_pools == null) 
                {
                    CreatePools();
                }
                List<Shape> pool = _pools[shapeId];
                int lastIndex = pool.Count - 1;
                if (lastIndex >= 0) 
                {
                    instance = pool[lastIndex];
                    instance.gameObject.SetActive(true);
                    pool.RemoveAt(lastIndex);
                }
                else 
                {
                    instance = Instantiate(prefabs[shapeId]);
                    instance.ShapeId = shapeId;
                    SceneManager.MoveGameObjectToScene(instance.gameObject, _poolScene);
                }
            }
            else
            {
                instance = Instantiate(prefabs[shapeId]);
                instance.ShapeId = shapeId;
            }
            return instance;
        }
        
        void CreatePools () 
        {
            _pools = new List<Shape>[prefabs.Length];
            for (int i = 0; i < _pools.Length; i++) 
            {
                _pools[i] = new List<Shape>();
            }
            if (Application.isEditor) 
            {
                _poolScene = SceneManager.GetSceneByName(name);
                if (_poolScene.isLoaded)
                {
                    GameObject[] rootObjects = _poolScene.GetRootGameObjects();
                    foreach (var t in rootObjects)
                    {
                        Shape pooledShape = t.GetComponent<Shape>();
                        if (!pooledShape.gameObject.activeSelf) 
                        {
                            _pools[pooledShape.ShapeId].Add(pooledShape);
                        }
                    }
                    return;
                }
            }
            _poolScene = SceneManager.CreateScene(name);
        }
    }
}
