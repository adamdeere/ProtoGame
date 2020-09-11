using UnityEngine;
using UtilityScripts;

namespace SpawnItemScripts.SpawnZones
{
    public class SphereSpawn : SpawnZone
    {
        [SerializeField] private bool surfaceOnly;
        [SerializeField] private Transform spawnPoint;
        public static event AddToSpawnZone AddSpawn;

        private void OnEnable()
        {
            AddSpawn?.Invoke(this);
        }

        public override Vector3 SpawnPoint => spawnPoint.transform.TransformPoint(surfaceOnly ? Random.onUnitSphere : Random.insideUnitSphere);
        public override Quaternion SpawnRotation => transform.rotation;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.matrix = spawnPoint.transform.localToWorldMatrix;
            Gizmos.DrawWireSphere(Vector3.zero, 1f);
        }
    }
}
