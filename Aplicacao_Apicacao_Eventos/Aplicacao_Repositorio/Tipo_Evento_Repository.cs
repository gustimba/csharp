using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacao_Modelos;
using Aplicacao_Repositorio;
using Aplicacao_Banco.Mysl;
using MySql.Data.MySqlClient;
namespace Aplicacao_Repositorio
{
    public class Tipo_Evento_Repository
    {
        BaloonConnection conn = new BaloonConnection();

        public void Create(TipoEvento tipoEvento)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO ");
            sql.Append("tipo_evento(descricao, porcentagem, id_tipo) ");

            sql.Append(" VALUES (@descricao, @perc, @idTipo)");

            MySqlCommand cmd = new MySqlCommand();

            cmd.Parameters.AddWithValue("@descricao", tipoEvento.descricaoTipoEvento);
            cmd.Parameters.AddWithValue("@perc", tipoEvento.perc);
            cmd.Parameters.AddWithValue("@idTipo", tipoEvento.idTipo);

            cmd.CommandText = sql.ToString();
            conn.executeCommand(cmd);
        }

        public IEnumerable<TipoEvento> GetAll()
        {
            List<TipoEvento> tipoEvento = new List<TipoEvento>();
            StringBuilder sql = new StringBuilder();
            sql.Append("Select * from tipo_evento ");

            MySqlDataReader dr = conn.executeSqlReader(sql.ToString());


            while (dr.Read())
            {
                tipoEvento.Add(new TipoEvento
                                (
                                    (int)dr["id_tipo_evento"],
                                    (string)dr["descricao"],
                                    (int)dr["porcentagem"],
                                    (int)dr["id_tipo"]

                                    )
                                    );
            }
            return tipoEvento;
        }

        public void delete(int id)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("DELETE from tipo_evento where id_tipo_evento=@id");

            MySqlCommand cmd = new MySqlCommand();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandText = sql.ToString();
            conn.executeCommand(cmd);
        }

        public void update(TipoEvento tipoEvento)
        {
            //UPDATE `professores` SET `nome_professor` = 'WillyFernando', `telefone_professor` = '992122321', `valor_hora_aula_professor` = '25' WHERE `professores`.`id_professor` = 1;
            StringBuilder sql = new StringBuilder();

            sql.Append("UPDATE tipo_evento SET ");
            sql.Append("descricao = @descricao, ");
            sql.Append("porcentagem = @perc ");
            sql.Append("WHERE id_tipo_evento = @id; ");


            MySqlCommand cmd = new MySqlCommand();
            Aluno aluno = new Aluno();

            cmd.Parameters.AddWithValue("@descricao", tipoEvento.descricaoTipoEvento);
            cmd.Parameters.AddWithValue("@perc", tipoEvento.perc);
            cmd.Parameters.AddWithValue("@id", tipoEvento.idTipoEvento);


            cmd.CommandText = sql.ToString();
            conn.executeCommand(cmd);


        }

        public List<TipoEvento> GetTipoEvento()
        {
            StringBuilder sql = new StringBuilder();
            List<TipoEvento> tipos = new List<TipoEvento>();

            sql.Append("Select * from tipo_evento ");

            MySqlDataReader dr = conn.executeSqlReader(sql.ToString());

            while (dr.Read())
            {
                tipos.Add(new TipoEvento
                {

                    idTipoEvento = dr.GetInt16(dr.GetOrdinal("id_tipo_evento")),
                    descricaoTipoEvento = dr.GetString(dr.GetOrdinal("descricao")),
                    perc = dr.GetInt16(dr.GetOrdinal("porcentagem"))


                });
            }
            dr.Dispose();
            return tipos;
        }

        public TipoEvento getTipoEvento(int id)
        {
            StringBuilder sql = new StringBuilder();
            TipoEvento tipoEvento = new TipoEvento();

            sql.Append("Select * from tipo_evento WHERE id_tipo_evento =" + id + " ;");

            MySqlDataReader dr = conn.executeSqlReader(sql.ToString());



            while (dr.Read())
            {
                tipoEvento.idTipoEvento = dr.GetInt16(dr.GetOrdinal("id_tipo_evento"));
                tipoEvento.descricaoTipoEvento = dr.GetString(dr.GetOrdinal("descricao"));
                tipoEvento.perc = dr.GetInt16(dr.GetOrdinal("porcentagem"));

            }
            dr.Dispose();

            return tipoEvento;

        }

    }
}
