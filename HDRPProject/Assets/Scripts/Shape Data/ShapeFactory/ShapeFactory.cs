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
        [SerializeField] private Material[] materials;
        [SerializeField] private bool recycle;
      
        private List<Shape>[] _pools;
        private Scene _poolScene;
        [NonSerialized] private int factoryId = int.MinValue;
        
        public Shape GetRandom () 
        {
            return Get(Random.Range(0, prefabs.Length),Random.Range(0, materials.Length));
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
        public Shape Get (int shapeId = 0, int materialId = 0) 
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
                }
            }
            else
            {
                instance = Instantiate(prefabs[shapeId]);
                instance.ShapeId = shapeId;
            }
            
            instance.SetMaterial(materials[materialId], materialId);
            return instance;
        }
        
        void CreatePools () 
        {
            _pools = new List<Shape>[prefabs.Length];
            for (int i = 0; i < _pools.Length; i++) 
            {
                _pools[i] = new List<Shape>();
            }
        }
    }
}
