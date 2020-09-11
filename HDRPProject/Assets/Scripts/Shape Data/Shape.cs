using SaveSystemScripts;
using UnityEngine;
using UtilityScripts;

namespace Shape_Data
{
    public class Shape : PersistantObject, IKillable
    {
        private int shapeId = int.MinValue;

        public int ShapeId 
        {
            get => shapeId;
            set 
            {
                if (shapeId == int.MinValue && value != int.MinValue) 
                {
                    shapeId = value;
                }
                else 
                {
                    Debug.LogError("Not allowed to change shapeId.");
                }
            }
        }

        public void DestroyShape()
        {
            throw new System.NotImplementedException();
        }
    }
}
