using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class Buscar_Cliente : Form
    {

        OdbcConnection conexionBD;
        string sql;
        OdbcCommand comandoSQl;

        public Buscar_Cliente()
        {
            InitializeComponent();
            Form1 frm1 = new Form1();
            conexionBD = frm1.conexionBD;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string telefono = textBox6.Text;
            sql = "SELECT * FROM `clientes` WHERE `telefono` = '" + telefono + "'";
            comandoSQl = new OdbcCommand(sql, conexionBD);
            OdbcDataReader resultadosSQL = comandoSQl.ExecuteReader();
            if (resultadosSQL.Read())
            {
                textBox1.Text = resultadosSQL.GetString(0).ToString();
                textBox2.Text = resultadosSQL.GetString(1).ToString();
                textBox3.Text = resultadosSQL.GetString(2).ToString();
                textBox4.Text = resultadosSQL.GetString(3).ToString();
                textBox5.Text = resultadosSQL.GetString(4).ToString();
            }
            else
            {
                MessageBox.Show("Cliente no encontrado");
            }
        }
        
    }
}
