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
    public partial class Form1 : Form
    {
       

        string resultado;
        int numResultado;
        string claveUsuario;
        string passUsuario;



        public Form1()
        {
            InitializeComponent();
            textBox2.PasswordChar = '\u25CF';
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public void ingresar()
        {
            

            claveUsuario = textBox1.Text;
            passUsuario = textBox2.Text;
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
            cmd.CommandText = "SELECT count(*) FROM USUARIOS WHERE CLAVE = '"+claveUsuario.ToUpper().Trim() + "' AND PASS = '"+ passUsuario.Trim() + "'";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            
            dr.Read();

            resultado = dr[0].ToString();
            

            numResultado = Int32.Parse(resultado.Trim());
            

            if (numResultado == 1)
            {
                Menu form = new Menu();
                form.Show();
                this.Hide();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("¡Error, las credenciales son incorrectas!");
            }

            conn.Dispose();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ingresar();
        }
    }
}
