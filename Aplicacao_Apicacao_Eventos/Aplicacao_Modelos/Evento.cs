using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao_Modelos
{
    public class Evento : TipoEvento
    {

        public int idEvento { get; set; }
        public int idAluno { get; set; }
        public int idTabelaHora { get; set; }
        public string descricaoEvento { get; set; }
        public string localEvento { get; set; }
        public DateTime dataEvento { get; set; }
        public int numeroHoras { get; set; }
        public DateTime dataCadastro { get; set; }


        public Evento()
        {

        }

        public Evento(int pId,
                      int pIdAluno,
                      int pIdTabelaHora,
                      string pDescricaoEvento,
                      string pLocalEvento,
                      DateTime pDataEvento,
                      int pNumeroHoras,
                      DateTime pDataCadastro
                      )
        {
            idEvento = pId;
            idAluno = pIdAluno;
            idTabelaHora = pIdTabelaHora;
            descricaoEvento = pDescricaoEvento;
            localEvento = pLocalEvento;
            dataEvento = pDataEvento;
            numeroHoras = pNumeroHoras;
            dataCadastro = pDataCadastro;
        }

        public Evento(int pId,
                      int pIdAluno,
                      int pIdTabelaHora,
                      string pDescricaoEvento,
                      string pLocalEvento,
                      DateTime pDataEvento,
                      int pNumeroHoras,
                      DateTime pDataCadastro,
                      int pIdTipoEvento,
                      string pDescricaoTipoEvento,
                      int pPerc,
                      int pIdTipo
                      )
        {
            idEvento = pId;
            idAluno = pIdAluno;
            idTabelaHora = pIdTabelaHora;
            descricaoEvento = pDescricaoEvento;
            localEvento = pLocalEvento;
            dataEvento = pDataEvento;
            numeroHoras = pNumeroHoras;
            dataCadastro = pDataCadastro;
            idTipoEvento = pIdTipoEvento;
            descricaoTipoEvento = pDescricaoTipoEvento;
            perc = pPerc;
            idTipo = pIdTipo;
            ;
        }

        public Evento(int pNumeroHoras, int pPerc, int pIdTipo)
        {
            numeroHoras = pNumeroHoras;
            perc = pPerc;
            idTipo = pIdTipo;
        }
    }
}
