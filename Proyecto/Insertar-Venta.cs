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
    public partial class Insertar_Venta : Form
    {

        OdbcConnection conexionBD;
        string sql;
        OdbcCommand comandoSQl;
        bool encontrado = false;
        float precio;
        int stock;
        double subtotal=0, iva=0, total=0;

        public Insertar_Venta()
        {
            InitializeComponent();
            Form1 frm1 = new Form1();
            conexionBD = frm1.conexionBD;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool agregado = false;
            if (encontrado)
            {
                if(textBox6.Text != ""){
                    int cantidad = Convert.ToInt32(textBox6.Text);
                    if (cantidad <= stock)
                    {
                        for (int i = 0; i < listView1.Items.Count; i++)
                        {
                            if (listView1.Items[i].SubItems[0].Text == textBox2.Text)
                            {
                                listView1.Items[i].SubItems[2].Text = (Convert.ToInt32(listView1.Items[i].SubItems[2].Text) + cantidad).ToString();
                                listView1.Items[i].SubItems[4].Text = (precio * (Convert.ToInt32(listView1.Items[i].SubItems[2].Text))).ToString();
                                agregado = true;
                            }
                        }

                        if (!agregado)
                        {
                            ListViewItem lvi = new ListViewItem(textBox2.Text);
                            lvi.SubItems.Add(textBox8.Text);
                            lvi.SubItems.Add(textBox6.Text);
                            lvi.SubItems.Add(precio.ToString());
                            lvi.SubItems.Add((precio * cantidad).ToString());
                            listView1.Items.Add(lvi);
                        }

                        subtotal += precio * cantidad;
                        iva = subtotal * 0.16;
                        total = subtotal + iva;

                        textBox9.Text = subtotal.ToString();
                        textBox10.Text = iva.ToString();
                        textBox5.Text = total.ToString();

                        textBox2.Text = "";
                        textBox8.Text = "";
                        textBox6.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("La cantidad es mayor a la existencia del producto" + Environment.NewLine
                                   + "El stock del producto es: " + stock);
                    }
                }
                else
                {
                    MessageBox.Show("Ingresa una cantidad valida");
                }
            }
            else
            {
                MessageBox.Show("Ingresa un codigo de producto valido");
            }
            
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

        private void Insertar_Venta_Load(object sender, EventArgs e)
        {

            DateTime localDate = DateTime.Now;
            textBox3.Text = localDate.ToString("yyyy-MM-dd");

            sql = "SELECT IFNULL(MAX(CAST(folio AS UNSIGNED)),0) maximo FROM ventas";
            comandoSQl = new OdbcCommand(sql, conexionBD);
            OdbcDataReader resultadosSQL = comandoSQl.ExecuteReader();
            resultadosSQL.Read();
            int folio = Convert.ToInt32(resultadosSQL.GetString(0)) + 1;
            textBox4.Text = Convert.ToString(folio);
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            string id = textBox12.Text;
            sql = "SELECT * FROM `empleados` WHERE `id_empleado` = '" + id + "'";
            comandoSQl = new OdbcCommand(sql, conexionBD);
            OdbcDataReader resultadosSQL = comandoSQl.ExecuteReader();
            if (resultadosSQL.Read())
            {
                textBox11.Text = resultadosSQL.GetString(1).ToString();
            }
            else
            {
                textBox11.Text = "No encontrado";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox7.Text != "" && textBox7.Text != "No encontrado")
            {
                if (textBox11.Text != "" && textBox11.Text != "No encontrado")
                {
                    if (textBox5.Text != "")
                    {
                        sql = "INSERT INTO `ventas`(`folio`, `fecha`, `telefono`, `id_empleado`) VALUES ('"
                              + textBox4.Text + "','" + textBox3.Text + "','" + textBox1.Text + "','" + textBox12.Text + "')";
                        comandoSQl = new OdbcCommand(sql, conexionBD);
                        comandoSQl.ExecuteNonQuery();

                        for (int i = 0; i < listView1.Items.Count; i++)
                        {
                            if (listView1.Items[i].SubItems[0].Text != "")
                            {
                                sql = "INSERT INTO `detallev`(`folio`, `id producto`, `cantidad`, `precio`) VALUES ('"
                                       + textBox4.Text + "','" + listView1.Items[i].SubItems[0].Text + "','"
                                       + listView1.Items[i].SubItems[2].Text + "','" + listView1.Items[i].SubItems[3].Text + "')";
                                comandoSQl = new OdbcCommand(sql, conexionBD);
                                comandoSQl.ExecuteNonQuery();

                                if (Convert.ToInt32(listView1.Items[i].SubItems[0].Text) < 1000)
                                {
                                    sql = "UPDATE `productos` SET `stock`=`stock`-" + Convert.ToInt32(listView1.Items[i].SubItems[2].Text)
                                           + " WHERE `id_producto` = '" + listView1.Items[i].SubItems[0].Text + "'";
                                    comandoSQl = new OdbcCommand(sql, conexionBD);
                                    comandoSQl.ExecuteNonQuery();
                                }
                                else
                                {
                                    sql = "UPDATE `bonos` SET `status` ='1' WHERE `id_bono` = '" + listView1.Items[i].SubItems[0].Text + "'";
                                    comandoSQl = new OdbcCommand(sql, conexionBD);
                                    comandoSQl.ExecuteNonQuery();
                                }
                            }
                        }

                        string telefono = textBox1.Text;
                        double acumulado;
                        bool acumula = false;
                        sql = "SELECT * FROM `clientes` WHERE `telefono` = '" + telefono + "'";
                        comandoSQl = new OdbcCommand(sql, conexionBD);
                        OdbcDataReader resultadosSQL = comandoSQl.ExecuteReader();
                        resultadosSQL.Read();
                        acumulado = resultadosSQL.GetFloat(5);
                        acumulado = acumulado + total;

                        while (acumulado >= 1000)
                        {
                            acumulado = acumulado - 1000;
                            sql = "UPDATE `clientes` SET `acumulado` ='" + acumulado + "' WHERE `telefono` = '" + telefono + "'";
                            comandoSQl = new OdbcCommand(sql, conexionBD);
                            comandoSQl.ExecuteNonQuery();

                            sql = "INSERT INTO `bonos`(`telefono`, `status`) VALUES ('" + telefono + "', '0')";
                            comandoSQl = new OdbcCommand(sql, conexionBD);
                            comandoSQl.ExecuteNonQuery();

                            acumula = true;
                        }
                        if (acumula)
                        {
                            MessageBox.Show("El cliente obtuvo un bono");
                        }
                        else
                        {
                            sql = "UPDATE `clientes` SET `acumulado` ='" + acumulado + "' WHERE `telefono` = '" + telefono + "'";
                            comandoSQl = new OdbcCommand(sql, conexionBD);
                            comandoSQl.ExecuteNonQuery();
                        }

                        MessageBox.Show("Venta agregada");
                    }
                    else
                    {
                        MessageBox.Show("Ingresa productos a la venta");
                    }
                }
                else
                {
                    MessageBox.Show("Ingresa un empleado valido");
                }
            }
            else
            {
                MessageBox.Show("Ingresa un cliente valido");
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string bonos = "Codigos disponibles:" + Environment.NewLine, telefono = textBox1.Text;
            bool encontrado = false;
            sql = "SELECT * FROM `bonos` WHERE `telefono` = '" + telefono + "' && `status` = 0";
            comandoSQl = new OdbcCommand(sql, conexionBD);
            OdbcDataReader resultadosSQL = comandoSQl.ExecuteReader();
            while (resultadosSQL.Read())
            {
                bonos += resultadosSQL.GetString(0).ToString() + Environment.NewLine;
                encontrado = true;
            }
            if (!encontrado)
            {
                bonos += "No hay codigos disponibles";
            }
            MessageBox.Show(bonos);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string telefono = textBox1.Text;
            string codigobono = textBox13.Text;
            sql = "SELECT * FROM `bonos` WHERE `id_bono` = '" + codigobono + "' && `telefono` = '" + telefono + "'";
            comandoSQl = new OdbcCommand(sql, conexionBD);
            OdbcDataReader resultadosSQL = comandoSQl.ExecuteReader();
            if (resultadosSQL.Read())
            {
                if((subtotal - 50) < 0)
                {
                    MessageBox.Show("El descuento no puede ser mayor al precio de la compra");
                }
                else
                {
                    ListViewItem lvi = new ListViewItem(textBox13.Text);
                    lvi.SubItems.Add("Descuento por bono");
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

                    textBox13.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Ingresa un codigo valido");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string codigo = textBox2.Text;
            sql = "SELECT * FROM `productos` WHERE `id_producto` = '" + codigo + "'";
            comandoSQl = new OdbcCommand(sql, conexionBD);
            OdbcDataReader resultadosSQL = comandoSQl.ExecuteReader();
            if (resultadosSQL.Read())
            {
                textBox8.Text = resultadosSQL.GetString(1).ToString();
                precio = resultadosSQL.GetFloat(8);
                stock = resultadosSQL.GetInt32(10);
                encontrado = true;
            }
            else
            {
                textBox8.Text = "No encontrado";
                encontrado = false;
            }
        }
    }
}
