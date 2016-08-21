using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Aplicacao_Banco.Mysl
{
    public class BaloonConnection
    {
        #region Attributes

        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader dr;

        public string strConnection
        {
            get
            {
                return "Server=localhost" +
                        ";Port=3306" +
                        ";Database=banco_aplicacao_eventos" +
                        ";Uid=root" +
                        ";Pwd=Gusta123vo";
            }
        }

        #endregion

        #region Constructors

        public BaloonConnection()
        {
            conn = new MySqlConnection(strConnection);
        }

        #endregion

        #region Methods

        public void connect()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
        }

        public void disconnect()
        {
            conn.Close();
        }

        public void executeCommand(MySqlCommand cmd)
        {
            connect();
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            disconnect();
        }

        public MySqlDataReader executeSqlReader(string pSql)
        {
            connect();
            cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = pSql;
            dr = cmd.ExecuteReader();

            return dr;
        }

        #endregion
    }
}
