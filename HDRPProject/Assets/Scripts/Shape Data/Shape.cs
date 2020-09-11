using System;
using SaveSystemScripts;
using UnityEngine;
using UtilityScripts;

namespace Shape_Data
{
    public class Shape : PersistantObject, IKillable
    {
        private int shapeId = int.MinValue;
        private Color color;
        private MeshRenderer meshRenderer; 
        static int colorPropertyId = Shader.PropertyToID("_Color");
        static MaterialPropertyBlock sharedPropertyBlock;
        private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }

        public int MaterialId { get; private set; }

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
        public override void Save (GameDataWriter writer) 
        {
            base.Save(writer);
            writer.Write(color);
        }

        public override void Load (GameDataReader reader) 
        {
            base.Load(reader);
            SetColor(reader.Version > 0 ? reader.ReadColor() : Color.white);
        }
        public void SetMaterial (Material material, int materialId) 
        {
            meshRenderer.material = material;
            MaterialId = materialId;
        }
        
        public void SetColor (Color color) 
        {
            this.color = color;

            if (sharedPropertyBlock == null) 
            {
                sharedPropertyBlock = new MaterialPropertyBlock();
            }
            sharedPropertyBlock.SetColor(colorPropertyId, color);
            meshRenderer.SetPropertyBlock(sharedPropertyBlock);
        }
        public void DestroyShape()
        {
            throw new System.NotImplementedException();
        }
    }
}
