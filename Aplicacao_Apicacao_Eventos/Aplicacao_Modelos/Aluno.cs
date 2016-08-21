using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao_Modelos
{
    public class Aluno
    {
        public int cgu { get; set; }
        public string nome { get; set; }
        public DateTime dataNasc { get; set; }
        public string curso { get; set; }



        public Aluno()
        {

        }

        public Aluno(int pCgu,
                     string pNome,
                     DateTime pDataNasc,
                     string pCurso)
        {
            cgu = pCgu;
            nome = pNome;
            dataNasc = pDataNasc;
            curso = pCurso;
        }



    }
}
