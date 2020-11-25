using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class Insertar_Empleado : Form
    {

        OdbcConnection conexionBD;
        OdbcCommand comandoSQl = new OdbcCommand();
        OdbcTransaction transaction = null;

        public Insertar_Empleado()
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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var rand = new Random();
            string pass = "";
            for (int ctr = 0; ctr <= 4; ctr++)
                pass += rand.Next(10).ToString();
            string md5 = GetMD5(pass);

            comandoSQl.Connection = conexionBD;
            try
            {
                transaction = conexionBD.BeginTransaction();
                comandoSQl.Connection = conexionBD;
                comandoSQl.Transaction = transaction;

                comandoSQl.CommandText =
                    "INSERT INTO `empleados`(`nombre`, `telefono`, `direccion`, `rfc`, `correo`, `puesto`, `supervisor`, `salario`,`User`, `Pass`) VALUES ('"
                  + textBox1.Text + "','" + textBox5.Text + "','" + textBox4.Text + "','" + textBox3.Text + "','" + textBox2.Text + "','"
                  + textBox6.Text + "','" + textBox8.Text + "','" + textBox7.Text + "','" + textBox9.Text + "','" + md5 + "')";
                comandoSQl.ExecuteNonQuery();

                transaction.Commit();
                MessageBox.Show("Empleado agregado");
                MessageBox.Show("Password: " + pass);
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

        public static string GetMD5(string str)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
        
    }
}
