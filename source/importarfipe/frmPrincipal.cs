using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace importarFIPE
{
    public partial class frmPrincipal : Form
    {
        int erros;
        private bool proxy = false;
        private string proxy_user = "";
        private string proxy_pass = "192837";
        private string BASE_URL_API = "http://fipeapi.appspot.com/api";

        bool autodown = false;
        bool erro = false;

        List<_class.Marca> listMarcas;
        List<_class.Veiculo> listVeiculos;
        List<_class.ModVeiculo> listModVeiculos;
        List<_class.Detalhe> listDetalhesMod;


        public frmPrincipal()
        {
            InitializeComponent();
            erros = 0;

            // Executado da primeira vez

            // Carrega as Marcas
            FileInfo fi = new FileInfo("cfg/ListaMarcas.serializer");
            if (fi.Exists)
            {
                FileStream fs = new FileStream("cfg/ListaMarcas.serializer", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                listMarcas = (List<_class.Marca>)bf.Deserialize(fs);
                fs.Close();
            }

            // Carrega Veiculos
            fi = new FileInfo("cfg/ListaVeiculos.serializer");
            if(fi.Exists)
            {
                FileStream fs = new FileStream("cfg/ListaVeiculos.serializer", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                listVeiculos = (List<_class.Veiculo>)bf.Deserialize(fs);
                fs.Close();
            }

            // Carrega Modelo de Veiculos
            fi = new FileInfo("cfg/ListaModVeiculos.serializer");
            if (fi.Exists)
            {
                FileStream fs = new FileStream("cfg/ListaModVeiculos.serializer", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                listModVeiculos = (List<_class.ModVeiculo>)bf.Deserialize(fs);
                fs.Close();
            }

            fi = new FileInfo("cfg/ListaDetalhesVeiculos.serializer");
            if(fi.Exists)
            {
                FileStream fs = new FileStream("cfg/ListaDetalhesVeiculos.serializer", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                listDetalhesMod = (List<_class.Detalhe>)bf.Deserialize(fs);
                fs.Close();
            }

            if (listDetalhesMod != null)
                tssDetalhes.Text = "Detalhes>Modelo: " + listDetalhesMod.Count;
            if(listMarcas != null)
                tssMarcas.Text = "Marcas: " + listMarcas.Count;
            if(listVeiculos != null)
                tssVeiculos.Text = "Veiculos: " + listVeiculos.Count;
            if(listModVeiculos != null)
                tssModVei.Text = "Modelos->Veiculos: " + listModVeiculos.Count;

        }

        private void iniciarPbar(int maxValue)
        {
            progBar.Maximum = maxValue;
            progBar.Step = 1;
            progBar.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string json = getResponse(BASE_URL_API + "/1/carros/marcas.json");

            // Gera uma lista de Objetos MARCA
            listMarcas = (List<_class.Marca>)JsonConvert.DeserializeObject<IEnumerable<_class.Marca>>(json);
            
            
            // exportar serialização;
            if (listMarcas != null && listMarcas.Count > 0)
            {
                // Conf Prog Bar
                iniciarPbar(listMarcas.Count);
                serializarObj(listMarcas);

                try
                {
                    using (StreamWriter sw = new StreamWriter(@"sql_marcas.txt"))
                    {
                        foreach (_class.Marca m in listMarcas)
                        {
                            progBar.PerformStep();
                            sw.WriteLine(string.Format("INSERT INTO marca ({0},'{1}','{2}','{3}');", m.Id, m.Name, m.Fipe_name, m.Key));
                        }
                        progBar.Value = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                    erro = true;
                }
            }
            else
            {
                MessageBox.Show("Erro, dados não recebidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                erro = true;
            }
            
            if (autodown == false && erro == false)
                MessageBox.Show("Marcas Importadas com sucesso!","Sucesso",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            erro = false;
        }

        private void btnImportaVeiculos_Click(object sender, EventArgs e)
        {
            List<string> jsons = new List<string>();

            if (listMarcas == null || listMarcas.Count == 0)
            {
                erro = true;
                MessageBox.Show("É necessário antes importar as Marcas.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Conf Prog Bar
                iniciarPbar(listMarcas.Count);
                foreach (_class.Marca m in listMarcas)
                {
                    jsons.Add(getResponse(string.Format(BASE_URL_API + "/1/carros/veiculos/{0}.json", m.Id)));
                    progBar.PerformStep();
                }

                listVeiculos = new List<_class.Veiculo>();
                int codMarca = 0;

                if (jsons.Count == 0)
                {
                    erro = true;
                    MessageBox.Show("Erro, dados não recebidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(@"sql_veiculos.txt"))
                        {
                            foreach (string j in jsons)
                            {
                                List<_class.Veiculo> listNewVeiculos = (List<_class.Veiculo>)JsonConvert.DeserializeObject<IEnumerable<_class.Veiculo>>(j);


                                foreach (_class.Veiculo v in listNewVeiculos)
                                {
                                    foreach (_class.Marca m in listMarcas)
                                    {
                                        if (m.Name.ToUpper() == v.Marca.ToUpper())
                                        {
                                            codMarca = m.Id;
                                            break;
                                        }
                                    }
                                    break;
                                }


                                foreach (_class.Veiculo v in listNewVeiculos)
                                {
                                    v.Refmarca = codMarca;
                                }

                                listVeiculos = listVeiculos.Union(listNewVeiculos).ToList();
                            }

                            // Salva serialização
                            if (listVeiculos.Count > 0)
                                serializarObj(listVeiculos);
                            else
                            {
                                MessageBox.Show("Erro, dados não recebidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                erro = true;
                            }

                            foreach (_class.Veiculo v in listVeiculos)
                            {
                                sw.WriteLine(string.Format("INSERT INTO veiculo_marca VALUES('{0}','{1}','{2}','{3}',{4},'{5}',{6});", v.Fipe_marca, v.Fipe_name, v.Marca, v.Key, v.Id, v.Name, v.Refmarca));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        erro = true;
                    }
                }
            }

            if (autodown == false && erro == false)
                MessageBox.Show("Veiculos Importados com Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            erro = false;
            progBar.Value = 0;
        }

        private void btnImpModVeiMarca_Click(object sender, EventArgs e)
        {
            List<string> jsons = new List<string>();

            string[,] arrModRef = new string[50000, 2];

            int l=0;

            if (listVeiculos == null || listVeiculos.Count == 0)
            {
                erro = true;
                MessageBox.Show("É necessário antes importar os Veiculos.","Erro",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                // Config do ProgBar
                iniciarPbar(listVeiculos.Count);
                foreach (_class.Veiculo v in listVeiculos)
                {
                    jsons.Add(getResponse(string.Format(BASE_URL_API + "/1/carros/veiculo/{0}/{1}.json", v.Refmarca, v.Id)));
                    arrModRef[l, 0] = v.Refmarca.ToString();
                    arrModRef[l, 1] = v.Id;
                    l++;
                    progBar.PerformStep();
                }

                l = -1;


                listModVeiculos = new List<_class.ModVeiculo>();

                try
                {
                    int n = 0;
                    using (StreamWriter sw = new StreamWriter(@"sql_modveiculos.txt"))
                    {
                        foreach (string j in jsons)
                        {
                            l = l + 1;

                            List<_class.ModVeiculo> listNewModVeiculos = (List<_class.ModVeiculo>)JsonConvert.DeserializeObject<IEnumerable<_class.ModVeiculo>>(j);
                            
                            foreach (_class.ModVeiculo mv in listNewModVeiculos)
                            {
                                n = n + 1;
                                mv.Iddnew = n;
                                mv.Idmarca = int.Parse(arrModRef[l, 0]);
                                mv.Idveiculomarca = int.Parse(arrModRef[l, 1]);
                            }

                            listModVeiculos = listModVeiculos.Union(listNewModVeiculos).ToList();
                        }

                        // Salva serialização
                        if (listModVeiculos.Count > 0)
                            serializarObj(listModVeiculos);
                        else
                        {
                            MessageBox.Show("Erro, dados não recebidos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            erro = true;
                        }

                        foreach (_class.ModVeiculo mv in listModVeiculos)
                        {
                            /*
                             * 0 = id           str
                             * 1 = fipe_marca   str
                             * 2 = fipe_codigo  str
                             * 3 = name         str
                             * 4 = marca        str
                             * 5 = key          str
                             * 6 = veiculo      str
                             * 7 = idmarca          INT
                             * 8 = idveiculomarca   INT
                             */
                            sw.WriteLine(string.Format("INSERT INTO modvei_marca VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}',{7},{8});",
                                mv.Id,
                                mv.Fipe_marca,
                                mv.Fipe_codigo,
                                mv.Name,
                                mv.Marca,
                                mv.Key,
                                mv.Veiculo,
                                mv.Idmarca,
                                mv.Idveiculomarca));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    erro = true;
                }
            }

            if (autodown == false && erro == false)
                MessageBox.Show("Modelos de Veiculos Importados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            erro = false;
            progBar.Value = 0;
        }
        
        private void btnImpDetalhesMod_Click(object sender, EventArgs e)
        {
            listDetalhesMod = new List<_class.Detalhe>();

            List<string> jsons = new List<string>();

            /* 
             *  0 = ID marca
             *  1 = ID veiculo
             *  2 = ID Modelo
             */
            int[,] arrModRef = new int[30000, 3];
            int l = 0;

            if (listModVeiculos == null || listModVeiculos.Count == 0)
            {
                MessageBox.Show("É Necessário importar primeiro os Modelos de Veiculos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                erro = true;
            }
            else
            {
                // Ok Existe Modelos
                // Conf Prog Bar
                iniciarPbar(listModVeiculos.Count);
                try
                {
                    foreach (_class.ModVeiculo mv in listModVeiculos)
                    {
                        jsons.Add(getResponse(
                            string.Format(BASE_URL_API + "/1/carros/veiculo/{0}/{1}/{2}.json",
                            mv.Idmarca,
                            mv.Idveiculomarca,
                            mv.Id))
                        );

                        arrModRef[l, 0] = mv.Iddnew;
                        l++;
                        if(l == 100)
                        {
                            break;
                        }
                        progBar.PerformStep();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }

                if (jsons.Count == 0)
                {                    
                    MessageBox.Show("Erro, dados não recebidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    erro = true;
                }
                else
                {
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(@"sql_detalhesmod.txt"))
                        {
                            foreach (string j in jsons)
                            {
                                _class.Detalhe detalheItem = (_class.Detalhe)JsonConvert.DeserializeObject<_class.Detalhe>(j);
                                detalheItem.Idmodelo = arrModRef[l, 0];

                                // ADICIONA A LISTA PRINCIPAL
                                listDetalhesMod.Add(detalheItem);

                                l++;
                            }

                            // Serializar Detalhes
                            serializarObj(listDetalhesMod);

                            foreach (_class.Detalhe d in listDetalhesMod)
                            {
                                /*
                                 * 0 = ID                   INT
                                 * 1 = AnoModelo            INT
                                 * 2 = marca   
                                 * 3 = name
                                 * 4 = veiculo
                                 * 5 = preco
                                 * 6 = combustivel
                                 * 7 = referencia
                                 * 8 = fipe_codigo
                                 * 9 = key
                                 * 10 = idMarca             INT
                                 * 11 = idveiculo_marca     INT
                                 * 12 = idveiculo_key
                                 */

                                /*sw.WriteLine(string.Format("INSERT INTO detalhes_veiculo VALUES({0},{1},'{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}',{10},{11},'{12}');",
                                    d.Id,
                                    d.Ano_modelo,
                                    d.Marca,
                                    d.Name,
                                    d.Veiculo,
                                    d.Preco,
                                    d.Combustivel,
                                    d.Referencia,
                                    d.Fipe_codigo,
                                    d.Key,
                                    d.Idmarca,
                                    d.Idveiculo_marca,
                                    d.Idmodelo
                                ));*/
                                sw.WriteLine(string.Format("INSERT INTO detalhes_veiculo VALUES({0},{1},'{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}',{10});",
                                    d.Id,
                                    d.Ano_modelo,
                                    d.Marca,
                                    d.Name,
                                    d.Veiculo,
                                    d.Preco,
                                    d.Combustivel,
                                    d.Referencia,
                                    d.Fipe_codigo,
                                    d.Key,
                                    d.Idmodelo
                                ));
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        erro = true;
                    }
                }
            }

            if (autodown == false && erro == false)
                MessageBox.Show("Detalhes Importados!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            erro = false;
            progBar.Value = 0;
        }


        /* Funções */
        public string getResponse(string url)
        {
            string resp = "";

            Uri uri = new Uri(url);

            var req = (HttpWebRequest)WebRequest.Create(uri);
            if (proxy)
            {
                req.Proxy = WebRequest.DefaultWebProxy;
                req.Proxy.Credentials = new NetworkCredential(proxy_user, proxy_pass);
            }
            req.Method = "GET";
            req.ContentType = "application/text";

            try
            {
                using (var response = req.GetResponse())
                {
                    using (Stream respStr = response.GetResponseStream())
                    {
                        using (StreamReader sReader = new StreamReader(respStr, Encoding.UTF8))
                        {
                            resp = sReader.ReadToEnd();
                        }
                    }
                }
            }
            catch
            {
                erros++;
            }

            return resp;
        }

        public void serializarObj(List<_class.Marca> lista)
        {
            FileStream fs = new FileStream("cfg/ListaMarcas.serializer", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, lista);
            fs.Close();
        }

        public void serializarObj(List<_class.Veiculo> lista)
        {
            FileStream fs = new FileStream("cfg/ListaVeiculos.serializer", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, lista);
            fs.Close();
        }

        public void serializarObj(List<_class.ModVeiculo> lista)
        {
            FileStream fs = new FileStream("cfg/ListaModVeiculos.serializer", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, lista);
            fs.Close();
        }

        public void serializarObj(List<_class.Detalhe> lista)
        {
            FileStream fs = new FileStream("cfg/ListaDetalhesVeiculos.serializer", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, lista);
            fs.Close();
        }


        /* Exibir Arquivos */
        private void btnSqlMarcas_Click(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo("sql_marcas.txt");
            if(fi.Exists)
                System.Diagnostics.Process.Start("sql_marcas.txt");
            else
                MessageBox.Show("Arquivo não gerado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSqlVeiculos_Click(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo("sql_veiculos.txt");
            if (fi.Exists)
                System.Diagnostics.Process.Start("sql_veiculos.txt");
            else
                MessageBox.Show("Arquivo não gerado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSqlModVei_Click(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo("sql_modveiculos.txt");
            if (fi.Exists)
                System.Diagnostics.Process.Start("sql_modveiculos.txt");
            else
                MessageBox.Show("Arquivo não gerado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSqlBaseTabelas_Click(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo("SQL_base.txt");
            if (fi.Exists)
                System.Diagnostics.Process.Start("SQL_base.txt");
            else
                MessageBox.Show("Arquivo não Encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            autodown = !autodown;
            btnImportaMarcas.PerformClick();
            btnImportaVeiculos.PerformClick();
            btnImpModVeiMarca.PerformClick();
            btnImpDetalhesMod.PerformClick();
        }

        private void btnSqlDetalhes_Click(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo("sql_detalhesmod.txt");
            if (fi.Exists)
                System.Diagnostics.Process.Start("sql_detalhesmod.txt");
            else
                MessageBox.Show("Arquivo não gerado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }




    }
}
