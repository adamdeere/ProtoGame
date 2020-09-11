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
        [NonSerialized]
        int factoryId = int.MinValue;

        public Shape Get(int shapeId)
        {
            Shape instance = Instantiate(prefabs[shapeId]);
            instance.ShapeId = shapeId;
            return instance;
        }
        public Shape GetRandom () 
        {
            return Get(Random.Range(0, prefabs.Length));
        }
    }
}
