using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace importarFIPE._class
{
    [Serializable]
    public class ModVeiculo
    {
        private string id;

        [JsonProperty("id")]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string fipe_marca;

        [JsonProperty("fipe_marca")]
        public string Fipe_marca
        {
            get { return fipe_marca; }
            set { fipe_marca = value; }
        }

        private string fipe_codigo;

        [JsonProperty("fipe_codigo")]
        public string Fipe_codigo
        {
            get { return fipe_codigo; }
            set { fipe_codigo = value; }
        }

        private string name;

        [JsonProperty("name")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string marca;

        [JsonProperty("marca")]
        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }

        private string key;

        [JsonProperty("key")]
        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        private string veiculo;

        [JsonProperty("veiculo")]
        public string Veiculo
        {
            get { return veiculo; }
            set { veiculo = value; }
        }

        private int idmarca;
        public int Idmarca
        {
            get { return idmarca; }
            set { idmarca = value; }
        }

        private int idveiculomarca;
        public int Idveiculomarca
        {
            get { return idveiculomarca; }
            set { idveiculomarca = value; }
        }

        private int iddnew;
        public int Iddnew
        {
            get { return iddnew; }
            set { iddnew = value; }
        }
    }
}
