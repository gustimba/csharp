using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao_Modelos
{
    public class Tipo
    {
        public int id { get; set; }
        public string tipo { get; set; }

        public Tipo()
        {

        }

        public Tipo(int pId, string pTipo)
        {
            id = pId;
            tipo = pTipo;
        }

    }

}
