using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Aplicacao_Modelos;
using Aplicacao_Banco.Mysl;
namespace Aplicacao_Repositorio
{
  public   class AlunoRepository
    {
        BaloonConnection conn = new BaloonConnection();

        public void Create(Aluno aluno)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO ");
            sql.Append("alunos(cgu, data_nasc, nome_aluno, curso) ");

            sql.Append(" VALUES (@cgu, @dataNasc, @nome, @curso)");

            MySqlCommand cmd = new MySqlCommand();

            cmd.Parameters.AddWithValue("@cgu", aluno.cgu);
            cmd.Parameters.AddWithValue("@dataNasc", aluno.dataNasc);
            cmd.Parameters.AddWithValue("@nome", aluno.nome);
            cmd.Parameters.AddWithValue("@curso", aluno.curso);


            cmd.CommandText = sql.ToString();
            conn.executeCommand(cmd);
        }

        public IEnumerable<Aluno> GetAll()
        {
            List<Aluno> aluno = new List<Aluno>();
            StringBuilder sql = new StringBuilder();
            sql.Append("Select * from alunos ");

            MySqlDataReader dr = conn.executeSqlReader(sql.ToString());


            while (dr.Read())
            {
                aluno.Add(new Aluno
                                (
                                    (int)dr["cgu"],
                                    (string)dr["nome_aluno"],
                                    (DateTime)dr["data_nasc"],
                                    (string)dr["curso"]

                                    )
                                    );
            }
            return aluno;
        }

        public void delete(int pCgu)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("DELETE from alunos where cgu=@cgu");

            MySqlCommand cmd = new MySqlCommand();
            cmd.Parameters.AddWithValue("@cgu", pCgu);
            cmd.CommandText = sql.ToString();
            conn.executeCommand(cmd);
        }

        public void update(Aluno pAluno)
        {
            //UPDATE `professores` SET `nome_professor` = 'WillyFernando', `telefone_professor` = '992122321', `valor_hora_aula_professor` = '25' WHERE `professores`.`id_professor` = 1;
            StringBuilder sql = new StringBuilder();

            sql.Append("UPDATE alunos SET ");
            sql.Append("nome_aluno = @nome, ");
            sql.Append("data_nasc = @dataNasc, ");
            sql.Append("curso = @curso ");
            sql.Append("WHERE cgu = @cgu ; ");


            MySqlCommand cmd = new MySqlCommand();
            Aluno aluno = new Aluno();

            cmd.Parameters.AddWithValue("@nome", pAluno.nome);
            cmd.Parameters.AddWithValue("@dataNasc", pAluno.dataNasc);
            cmd.Parameters.AddWithValue("@curso", pAluno.curso);
            cmd.Parameters.AddWithValue("@cgu", pAluno.cgu);

            cmd.CommandText = sql.ToString();
            conn.executeCommand(cmd);
        }

        public Aluno getAluno(int cgu)
        {
            StringBuilder sql = new StringBuilder();
            Aluno aluno = new Aluno();

            sql.Append("Select * from alunos WHERE cgu =" + cgu + " ;");

            MySqlDataReader dr = conn.executeSqlReader(sql.ToString());



            while (dr.Read())
            {
                aluno.cgu = (int)dr["cgu"];
                aluno.nome = (string)dr["nome_aluno"];
                aluno.dataNasc = (DateTime)dr["data_nasc"];
                aluno.curso = (string)dr["curso"];

            }
            dr.Dispose();

            return aluno;

        }


    }
}
