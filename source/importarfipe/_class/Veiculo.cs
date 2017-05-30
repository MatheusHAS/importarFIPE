using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace importarFIPE._class
{
    [Serializable]
    public class Veiculo
    {
        
        private string key;

        [JsonProperty("key")]
        public string Key
        {
            get { return key; }
            set { key = value; }
        }
        private string name;

        [JsonProperty("name")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string id;

        [JsonProperty("id")]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string marca;

        [JsonProperty("marca")]
        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }

        private string fipe_marca;

        [JsonProperty("fipe_marca")]
        public string Fipe_marca
        {
            get { return fipe_marca; }
            set { fipe_marca = value; }
        }
        
        private string fipe_name;

        [JsonProperty("fipe_name")]
        public string Fipe_name
        {
            get { return fipe_name; }
            set { fipe_name = value; }
        }

        private int refmarca;

        public int Refmarca
        {
            get { return refmarca; }
            set { refmarca = value; }
        }


    }
}
