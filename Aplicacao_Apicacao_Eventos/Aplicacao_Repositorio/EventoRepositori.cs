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
    public class EventoRepositori
    {
        BaloonConnection conn = new BaloonConnection();
        Tipo_Evento_Repository tipoEventoRepository = new Tipo_Evento_Repository();

        public void Create(Evento evento)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO ");
            sql.Append("eventos(id_aluno, id_tipo_evento, descricao_evento, local_evento, numero_horas, data_evento, data_cadastro) ");

            sql.Append(" VALUES (@idAluno, @idTipoEvento, @descricao, @local, @numeroHoras, @dataEvento, @dataCadastro)");

            MySqlCommand cmd = new MySqlCommand();

            cmd.Parameters.AddWithValue("@idAluno", evento.idAluno);
            cmd.Parameters.AddWithValue("@idTipoEvento", evento.idTabelaHora);
            cmd.Parameters.AddWithValue("@descricao", evento.descricaoEvento);
            cmd.Parameters.AddWithValue("@numeroHoras", evento.numeroHoras);
            cmd.Parameters.AddWithValue("@local", evento.localEvento);
            cmd.Parameters.AddWithValue("@dataCadastro", DateTime.Now);
            cmd.Parameters.AddWithValue("@dataEvento", evento.dataEvento);


            cmd.CommandText = sql.ToString();
            conn.executeCommand(cmd);



        }

        public void delete(int id)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("DELETE from eventos where id_evento = @id");

            MySqlCommand cmd = new MySqlCommand();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandText = sql.ToString();
            conn.executeCommand(cmd);
        }

        public void update(Evento evento)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("UPDATE eventos SET ");
            sql.Append("descricao_evento = @descricao, ");
            sql.Append("local_evento = @localEvento, ");
            sql.Append("numero_horas = @numeroHoras, ");
            sql.Append("data_cadastro = @dataCadastro, ");
            sql.Append("data_evento = @dataEvento, ");
            sql.Append("id_tipo_evento = @idTipoEvento ");
            sql.Append("WHERE id_evento = @idEvento ; ");



            MySqlCommand cmd = new MySqlCommand();
            Aluno aluno = new Aluno();

            cmd.Parameters.AddWithValue("@descricao", evento.descricaoEvento);
            cmd.Parameters.AddWithValue("@localEvento", evento.localEvento);
            cmd.Parameters.AddWithValue("@numeroHoras", evento.numeroHoras);
            cmd.Parameters.AddWithValue("@dataCadastro", DateTime.Now);
            cmd.Parameters.AddWithValue("@dataEvento", evento.dataEvento);
            cmd.Parameters.AddWithValue("@idTipoEvento", evento.idTabelaHora);
            cmd.Parameters.AddWithValue("@idEvento", evento.idEvento);


            cmd.CommandText = sql.ToString();
            conn.executeCommand(cmd);
        }

        public IEnumerable<Evento> GetAll(int id)
        {
            List<Evento> evento = new List<Evento>();
            StringBuilder sql = new StringBuilder();

            sql.Append(" Select e.id_evento, e.descricao_evento, e.local_evento, e.numero_horas, e.data_cadastro, e.data_evento, t.id_tipo, t.id_tipo_evento, t.descricao, t.porcentagem, p.id, p.tipo");
            sql.Append(" FROM eventos e INNER JOIN tipo_evento t on ");
            sql.Append("e.id_tipo_evento = t.id_tipo_evento ");
            sql.Append(" INNER JOIN tipos p on");
            sql.Append(" t.id_tipo = p.id ");
            sql.Append("WHERE e.id_aluno = " + id + "");


            MySqlDataReader dr = conn.executeSqlReader(sql.ToString());


            while (dr.Read())
            {
                evento.Add(new Evento
                                (
                                    (int)dr["id_evento"],
                                    id,
                                    (int)dr["id_tipo_evento"],
                                    (string)dr["descricao_evento"],
                                    (string)dr["local_evento"],
                                    (DateTime)dr["data_evento"],
                                    (int)dr["numero_horas"],
                                    (DateTime)dr["data_cadastro"],
                                    (int)dr["id_tipo_evento"],
                                    (string)dr["descricao"],
                                    (int)dr["porcentagem"],
                                    (int)dr["id_tipo"]

                                    )
                                    );


            }


            return evento;
        }

        public decimal GetHoras(int id)
        {

            List<Evento> evento = new List<Evento>();

            StringBuilder sql = new StringBuilder();

            sql.Append("Select e.numero_horas, t.porcentagem, p.id, e.id_tipo_evento, t.id_tipo_evento");
            sql.Append(" FROM eventos e INNER JOIN tipo_evento t ON ");
            sql.Append(" e.id_tipo_evento = t.id_tipo_evento ");
            sql.Append(" INNER JOIN tipos p ON");
            sql.Append(" t.id_tipo = p.id ");
            sql.Append(" WHERE e.id_aluno = " + id + "");

            MySqlDataReader dr = conn.executeSqlReader(sql.ToString());

            while (dr.Read())
            {
                evento.Add(new Evento
                                (
                                    (int)dr["numero_horas"],
                                    (int)dr["porcentagem"],
                                    (int)dr["id"]
                                    )
                                    );


            }

            conn.disconnect();
            decimal horasCurso = 0;
            decimal horasAtividades = 0;
            decimal aux;
            for (int i = 0; i < evento.Count; i++)
            {
                aux = (decimal)(evento.ElementAt(i).numeroHoras * evento.ElementAt(i).perc) / 100;

                if (evento.ElementAt(i).idTipo == 1)
                {
                    horasCurso = horasCurso + aux;
                }
                else if (horasAtividades <= 16)
                {
                    horasAtividades = horasAtividades + aux;
                }


            }

            decimal horas = horasCurso + horasAtividades;
            decimal minutos = horas % 1;
            horas = (horas - (horas % 1)) + minutos;

            return horas;
        }

        public Evento getEvento(int id)
        {
            StringBuilder sql = new StringBuilder();
            Evento evento = new Evento();

            sql.Append("Select * from eventos WHERE id_evento =" + id + " ;");

            MySqlDataReader dr = conn.executeSqlReader(sql.ToString());



            while (dr.Read())
            {
                evento.idEvento = (int)dr["id_evento"];
                evento.idAluno = (int)dr["id_evento"];
                evento.idTabelaHora = (int)dr["id_tipo_evento"];
                evento.descricaoEvento = (string)dr["descricao_evento"];
                evento.localEvento = (string)dr["local_evento"];
                evento.dataEvento = (DateTime)dr["data_evento"];
                evento.numeroHoras = (int)dr["numero_horas"];
                evento.dataCadastro = (DateTime)dr["data_cadastro"];


            }
            dr.Dispose();

            return evento;

        }





    }
}
