using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacao_Modelos;
using Aplicacao_Banco.Mysl;
using MySql.Data.MySqlClient;
namespace Aplicacao_Repositorio
{
    public class TipoRepositoriu
    {
        BaloonConnection conn = new BaloonConnection();
        public IEnumerable<Tipo> GetAll()
        {
            List<Tipo> tipo = new List<Tipo>();
            StringBuilder sql = new StringBuilder();
            sql.Append("Select * from tipos ");

            MySqlDataReader dr = conn.executeSqlReader(sql.ToString());


            while (dr.Read())
            {
                tipo.Add(new Tipo
                                (
                                    (int)dr["id"],
                                    (string)dr["tipo"]

                                    )
                                    );
            }
            return tipo;
        }

        public List<Tipo> GetTipo()
        {
            StringBuilder sql = new StringBuilder();
            List<Tipo> tipos = new List<Tipo>();

            sql.Append("Select * from tipos ");

            MySqlDataReader dr = conn.executeSqlReader(sql.ToString());

            while (dr.Read())
            {
                tipos.Add(new Tipo
                {

                    id = dr.GetInt16(dr.GetOrdinal("id")),
                    tipo = dr.GetString(dr.GetOrdinal("tipo"))


                });
            }
            dr.Dispose();
            return tipos;
        }

    }
}

