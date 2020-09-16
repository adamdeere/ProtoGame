using System;
using Main_game_scripts;
using SaveSystemScripts;
using UnityEngine;
using UnityEngine.AI;
using UtilityScripts;

namespace Shape_Data
{
    public class Shape : PersistantObject, IZombie
    {
        private NavMeshAgent nma;
        public float ZombieHealth = 100;

        private void Awake()
        {
            nma = GetComponent<NavMeshAgent>();
        }

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
        public override void Save (GameDataWriter writer) 
        {
            base.Save(writer);
            writer.Write(MaterialId);
        
        }
       
        public override void Load (GameDataReader reader) 
        {
            base.Load(reader);
            MaterialId = reader.ReadInt();

        }
        /// <summary>
        /// this is a zombie attack
        /// </summary>
        /// <param name="other"></param>
        private void OnCollisionEnter(Collision other)
        {
            var kill = other.collider.gameObject.GetComponent<IPlayer>();
            kill?.DoDamage(10);
        }

        public void SetPosition(Vector3 position)
        {
            nma.Warp(position);
        }

        /// <summary>
        /// this is the damage for the zombie
        /// </summary>
        public void DoDamage(float damage, out bool isDead)
        {
            //reset the shapes original position and disable it
            //after a death animation, for which we may need to figure out a way of making it less 
            //read only (as its in this case I think we can do the old duplicate trick for for more animations
            //we will need a converter tool)
            ZombieHealth -= damage;
            if (ZombieHealth < 1)
            {
                var resetPos = Game.Instance.ResetPos();
                transform.localPosition = resetPos.localPosition;
                gameObject.SetActive(false);
                isDead = true;
            }
            else
            {
                isDead = false;
            }
        }
    }
}
