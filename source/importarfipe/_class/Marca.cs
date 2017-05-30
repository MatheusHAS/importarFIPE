using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace importarFIPE._class
{
    [Serializable]
    public class Marca
    {
        private string name;
        [JsonProperty("name")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string fipe_name;

        [JsonProperty("fipe_name")]
        public string Fipe_name
        {
            get { return fipe_name; }
            set { fipe_name = value; }
        }

        private int number;

        [JsonProperty("number")]
        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        private string key;

        [JsonProperty("key")]
        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        private int id;

        [JsonProperty("id")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
