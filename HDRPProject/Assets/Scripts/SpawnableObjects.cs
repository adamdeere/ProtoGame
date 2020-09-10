using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnableObject", order = 1)]
public class SpawnableObjects : ScriptableObject
{
    public GameObject entity;
    public Vector3 prefabPosition;

    public void Spawner(GameObject parentObject)
    {
        Instantiate(entity, prefabPosition, Quaternion.identity,parentObject.transform);
    }

    public void SpawnOne(Vector3 position)
    {
        Instantiate(entity, position, Quaternion.identity);
    }
}
