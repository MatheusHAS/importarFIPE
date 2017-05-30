using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace importarFIPE._class
{
    [Serializable]
    public class Detalhe
    {

        private int id;
        [JsonProperty("id")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int ano_modelo;
        [JsonProperty("ano_modelo")]
        public int Ano_modelo
        {
            get { return ano_modelo; }
            set { ano_modelo = value; }
        }

        private string marca;
        [JsonProperty("marca")]
        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }

        private string name;
        [JsonProperty("name")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string veiculo;
        [JsonProperty("veiculo")]
        public string Veiculo
        {
            get { return veiculo; }
            set { veiculo = value; }
        }

        private string preco;
        [JsonProperty("preco")]
        public string Preco
        {
            get { return preco; }
            set { preco = value; }
        }

        private string combustivel;
        [JsonProperty("combustivel")]
        public string Combustivel
        {
            get { return combustivel; }
            set { combustivel = value; }
        }

        private string referencia;
        [JsonProperty("referencia")]
        public string Referencia
        {
            get { return referencia; }
            set { referencia = value; }
        }

        private string fipe_codigo;
        [JsonProperty("fipe_codigo")]
        public string Fipe_codigo
        {
            get { return fipe_codigo; }
            set { fipe_codigo = value; }
        }

        private string key;
        [JsonProperty("key")]
        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        private int idmarca;
        public int Idmarca
        {
            get { return idmarca; }
            set { idmarca = value; }
        }

        private int idveiculo_marca;
        public int Idveiculo_marca
        {
            get { return idveiculo_marca; }
            set { idveiculo_marca = value; }
        }

        private int idmodelo;
        public int Idmodelo
        {
            get { return idmodelo; }
            set { idmodelo = value; }
        }
    }
}
