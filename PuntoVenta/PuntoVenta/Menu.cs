using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoVenta
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            busqueda.KeyDown += new KeyEventHandler(tb_KeyDown);
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void agregarProducto(string clave)
        {
            Conexion con = new Conexion();
            string nombreProducto = con.excecuteQuery("SELECT NOMBRE FROM ARTICULOS WHERE CLAVE = '"+ clave +"'");
            string descProducto = con.excecuteQuery("SELECT DESCRIPCION FROM ARTICULOS WHERE CLAVE = '" + clave + "'");
            string precioProducto = con.excecuteQuery("SELECT PRECIO FROM ARTICULOS WHERE CLAVE = '" + clave + "'");

            listView1.Items.Add(nombreProducto);
            listView2.Items.Add(descProducto);
            listView3.Items.Add(precioProducto);

        }
        //event listener del textob de busqueda, al presionar enter
        public void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string busqueda = this.busqueda.Text;
                agregarProducto(busqueda);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("C:/Users/asortega/source/repos/PuntoVenta/PuntoVenta/barcode.png");
        }
    }
}
