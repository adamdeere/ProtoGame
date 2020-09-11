using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        
    }
}
