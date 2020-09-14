using System;
using SaveSystemScripts;
using UnityEngine;
using UtilityScripts;

namespace Shape_Data
{
    public class Shape : PersistantObject, IKillable
    {
       public int MaterialId { get; private set; } = int.MinValue;

        public int ShapeId 
        {
            get => MaterialId;
            set 
            {
                if (MaterialId == int.MinValue && value != int.MinValue) 
                {
                    MaterialId = value;
                }
                else 
                {
                    Debug.LogError("Not allowed to change shapeId.");
                }
            }
        }
        
        //keep here until we can find a use for it
        // public override void Save (GameDataWriter writer) 
        // {
        //     base.Save(writer);
        //
        // }
       
        // public override void Load (GameDataReader reader) 
        // {
        //     base.Load(reader);
        //  
        // }
        private void OnCollisionEnter(Collision other)
        {
            IKillable kill = other.collider.gameObject.GetComponent<IKillable>();
            kill?.DoDamage();
           // Destroy(gameObject);
        }

        public void DoDamage()
        {
           Destroy(gameObject);
        }
    }
}
