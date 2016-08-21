using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao_Modelos
{
    public class TipoEvento
    {

        public int idTipoEvento { get; set; }
        public string descricaoTipoEvento { get; set; }
        public int perc { get; set; }
        public int idTipo { get; set; }



        public TipoEvento()
        {

        }

        public TipoEvento(int pId,
                           string pDescricao,
                           int pPerc,
                           int pIdTipo)
        {
            idTipoEvento = pId;
            descricaoTipoEvento = pDescricao;
            perc = pPerc;
            idTipo = pIdTipo;

        }

    }
}
