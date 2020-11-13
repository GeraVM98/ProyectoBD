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
    public partial class Buscar_Empleado : Form
    {

        OdbcConnection conexionBD;
        string sql;
        OdbcCommand comandoSQl;

        public Buscar_Empleado()
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
            string id = textBox11.Text;
            sql = "SELECT * FROM `empleados` WHERE `id_empleado` = '" + id + "'";
            comandoSQl = new OdbcCommand(sql, conexionBD);
            OdbcDataReader resultadosSQL = comandoSQl.ExecuteReader();
            if (resultadosSQL.Read())
            {
                textBox9.Text = resultadosSQL.GetString(0).ToString();
                textBox1.Text = resultadosSQL.GetString(1).ToString();
                textBox5.Text = resultadosSQL.GetString(2).ToString();
                textBox4.Text = resultadosSQL.GetString(3).ToString();
                textBox3.Text = resultadosSQL.GetString(4).ToString();
                textBox2.Text = resultadosSQL.GetString(5).ToString();
                textBox6.Text = resultadosSQL.GetString(6).ToString();
                textBox8.Text = resultadosSQL.GetString(7).ToString();
                textBox7.Text = resultadosSQL.GetString(8).ToString();
            }
            else
            {
                MessageBox.Show("Empleado no encontrado");
            }
        }
        
    }
}
