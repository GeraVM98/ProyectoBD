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
    public partial class Login : Form
    {
        OdbcConnection conexionBD;
        string sql;
        OdbcCommand comandoSQl;

        public Login()
        {
            InitializeComponent();
            Form1 frm1 = new Form1();
            conexionBD = frm1.conexionBD;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string pass = GetMD5(textBox5.Text);
            sql = "SELECT * FROM `empleados` WHERE `user` = '" + user + "' AND `pass` = '" + pass + "'";
            comandoSQl = new OdbcCommand(sql, conexionBD);
            OdbcDataReader resultadosSQL = comandoSQl.ExecuteReader();
            if (resultadosSQL.Read())
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o Password Invalido");
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
