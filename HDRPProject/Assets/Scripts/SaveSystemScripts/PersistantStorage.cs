using System.IO;
using UnityEngine;

namespace SaveSystemScripts
{
   
    public sealed class PersistantStorage : MonoBehaviour
    {
        string _savePath;

        public void Awake () 
        {
            _savePath = Path.Combine(Application.persistentDataPath, "saveFile");
        }

        public void Save (PersistantObject o, int version) 
        {
            using (var writer = new BinaryWriter(File.Open(_savePath, FileMode.Create))) 
            {
                writer.Write(-version);
                o.Save(new GameDataWriter(writer));
            }
        }

        public void Load (PersistantObject o) 
        {
            var data = File.ReadAllBytes(_savePath);
            var reader = new BinaryReader(new MemoryStream(data));
            o.Load(new GameDataReader(reader, -reader.ReadInt32()));
        }
    }
}
