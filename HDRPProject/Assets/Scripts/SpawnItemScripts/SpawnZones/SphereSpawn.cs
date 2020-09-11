using UnityEngine;
using UtilityScripts;

namespace SpawnItemScripts.SpawnZones
{
    public class SphereSpawn : SpawnZone
    {
        [SerializeField] private bool surfaceOnly;
        public static event AddToSpawnZone AddSpawn;

        private void OnEnable()
        {
            AddSpawn?.Invoke(this);
        }

        public override Vector3 SpawnPoint => transform.TransformPoint(surfaceOnly ? Random.onUnitSphere : Random.insideUnitSphere);

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawWireSphere(Vector3.zero, 1f);
        }
    }
}
