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
    public partial class Insertar_Cliente : Form
    {

        OdbcConnection conexionBD;
        OdbcCommand comandoSQl = new OdbcCommand();
        OdbcTransaction transaction = null;


        public Insertar_Cliente()
        {
            InitializeComponent();
            Form1 frm1 = new Form1();
            conexionBD = frm1.conexionBD;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comandoSQl.Connection = conexionBD;
            try
            {
                transaction = conexionBD.BeginTransaction();
                comandoSQl.Connection = conexionBD;
                comandoSQl.Transaction = transaction;
                
                comandoSQl.CommandText =
                    "INSERT INTO `clientes`(`nombre`, `telefono`, `direccion`, `rfc`, `correo`) VALUES ('"
                  + textBox1.Text + "','" + textBox5.Text + "','" + textBox4.Text + "','" + textBox3.Text + "','"
                  + textBox2.Text + "')";
                comandoSQl.ExecuteNonQuery();
                
                transaction.Commit();
                MessageBox.Show("Cliente agregado");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                }
            }
        }
    }
}
