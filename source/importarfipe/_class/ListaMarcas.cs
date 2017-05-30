using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace importarFIPE._class
{
    public class ListaMarcas
    {
        private IEnumerable<Marca> marcas;
        public IEnumerable<Marca> Marcas
        {
            get { return marcas; }
            set { marcas = value; }
        }
    }
}
