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
    public partial class Insertar_Producto : Form
    {

        OdbcConnection conexionBD;
        OdbcCommand comandoSQl = new OdbcCommand();
        OdbcTransaction transaction = null;

        public Insertar_Producto()
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
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
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
                    "INSERT INTO `productos`(`nombre`, `descripcion`, `marca`, `categoria`, `ubicacion`, `cant_max`, `cant_min`, `precioV`, `precioC`, `stock`, `venta`) VALUES ('"
                  + textBox1.Text + "','" + textBox5.Text + "','" + textBox4.Text + "','" + textBox8.Text + "','"
                  + textBox7.Text + "','" + textBox3.Text + "','" + textBox9.Text + "','" + textBox2.Text + "','"
                  + textBox10.Text + "','" + textBox6.Text + "','" + comboBox1.SelectedIndex + "')";
                comandoSQl.ExecuteNonQuery();

                transaction.Commit();
                MessageBox.Show("Producto agregado");
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
