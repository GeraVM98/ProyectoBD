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
    public partial class Buscar_Venta : Form
    {

        OdbcConnection conexionBD;
        string sql;
        OdbcCommand comandoSQl;
        double subtotal = 0, iva = 0, total = 0;

        public Buscar_Venta()
        {
            InitializeComponent();
            Form1 frm1 = new Form1();
            conexionBD = frm1.conexionBD;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string folio = textBox2.Text;
            sql = "SELECT * FROM `ventas` WHERE `folio` = '" + folio + "'";
            comandoSQl = new OdbcCommand(sql, conexionBD);
            OdbcDataReader resultadosSQL = comandoSQl.ExecuteReader();
            if (resultadosSQL.Read())
            {
                textBox4.Text = resultadosSQL.GetString(0).ToString();
                textBox3.Text = resultadosSQL.GetString(1).ToString();
                textBox1.Text = resultadosSQL.GetString(2).ToString();
                textBox8.Text = resultadosSQL.GetString(3).ToString();

                sql = "SELECT * FROM `detallev` WHERE `folio` = '" + folio + "'";
                comandoSQl = new OdbcCommand(sql, conexionBD);
                resultadosSQL = comandoSQl.ExecuteReader();
                while (resultadosSQL.Read())
                {
                    string desc;
                    string codigo = resultadosSQL.GetString(1).ToString();
                    if (Convert.ToInt32(codigo) < 1000)
                    {
                        sql = "SELECT * FROM `productos` WHERE `id_producto` = '" + codigo + "'";
                        comandoSQl = new OdbcCommand(sql, conexionBD);
                        OdbcDataReader resultadosSQL2 = comandoSQl.ExecuteReader();
                        if (resultadosSQL2.Read())
                        {
                            desc = resultadosSQL2.GetString(1).ToString();
                        }
                        else
                        {
                            desc = "";
                        }

                        float precio = resultadosSQL.GetFloat(3);
                        int cantidad = resultadosSQL.GetInt32(2);
                        ListViewItem lvi = new ListViewItem(codigo);
                        lvi.SubItems.Add(desc);
                        lvi.SubItems.Add(cantidad.ToString());
                        lvi.SubItems.Add(precio.ToString());
                        lvi.SubItems.Add((precio * cantidad).ToString());
                        listView1.Items.Add(lvi);

                        subtotal += precio * cantidad;
                        iva = subtotal * 0.16;
                        total = subtotal + iva;

                        textBox9.Text = subtotal.ToString();
                        textBox10.Text = iva.ToString();
                        textBox5.Text = total.ToString();
                    }
                    else
                    {
                        sql = "SELECT * FROM `bonos` WHERE `id_bono` = '" + codigo + "'";
                        comandoSQl = new OdbcCommand(sql, conexionBD);
                        OdbcDataReader resultadosSQL2 = comandoSQl.ExecuteReader();
                        if (resultadosSQL2.Read())
                        {
                            desc = "Descuento por bono";
                        }
                        else
                        {
                            desc = "";
                        }
                        ListViewItem lvi = new ListViewItem(codigo);
                        lvi.SubItems.Add(desc);
                        lvi.SubItems.Add("1");
                        lvi.SubItems.Add("-50");
                        lvi.SubItems.Add("-50");
                        listView1.Items.Add(lvi);

                        subtotal -= 50;
                        iva = subtotal * 0.16;
                        total = subtotal + iva;

                        textBox9.Text = subtotal.ToString();
                        textBox10.Text = iva.ToString();
                        textBox5.Text = total.ToString();
                    }
                }
            }
            else
            {
                MessageBox.Show("No encontrado");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string telefono = textBox1.Text;
            sql = "SELECT * FROM `clientes` WHERE `telefono` = '" + telefono + "'";
            comandoSQl = new OdbcCommand(sql, conexionBD);
            OdbcDataReader resultadosSQL = comandoSQl.ExecuteReader();
            if (resultadosSQL.Read())
            {
                textBox7.Text = resultadosSQL.GetString(0).ToString();
            }
            else
            {
                textBox7.Text = "No encontrado";
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            string id = textBox8.Text;
            sql = "SELECT * FROM `empleados` WHERE `id_empleado` = '" + id + "'";
            comandoSQl = new OdbcCommand(sql, conexionBD);
            OdbcDataReader resultadosSQL = comandoSQl.ExecuteReader();
            if (resultadosSQL.Read())
            {
                textBox6.Text = resultadosSQL.GetString(1).ToString();
            }
            else
            {
                textBox6.Text = "No encontrado";
            }
        }
    }
}
