using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;


namespace PuntoVenta
{
    public class Conexion : Menu
    {
        public Conexion()
        {
            
        }


        public string excecuteQuery(string query)
        {
            string host = "localhost";
            string port = "1521";
            string sid = "pdborcl";
            string password = "hr";
            string user = "hr";
            string oradb = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = "
                 + host + ")(PORT = " + port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = "
                  + sid + ")));Password=" + password + ";User ID=" + user;

            OracleConnection conn = new OracleConnection(oradb);
            //se abre la conexion a la bd
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();

            dr.Read();

            string resultado = dr[0].ToString();

            return resultado;
        }

    }
}