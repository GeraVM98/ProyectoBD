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
    public partial class Mostrar_Cliente : Form
    {

        OdbcConnection conexionBD;
        string sql;
        OdbcCommand comandoSQl;

        public Mostrar_Cliente()
        {
            InitializeComponent();
            Form1 frm1 = new Form1();
            conexionBD = frm1.conexionBD;
        }

        private void Mostrar_Cliente_Load(object sender, EventArgs e)
        {
            sql = "SELECT * FROM `clientes` WHERE 1";
            comandoSQl = new OdbcCommand(sql, conexionBD);
            OdbcDataReader resultadosSQL = comandoSQl.ExecuteReader();
            while (resultadosSQL.Read())
            {
                dataGridView1.Rows.Add(resultadosSQL.GetString(0).ToString(), resultadosSQL.GetString(1).ToString(),
                                       resultadosSQL.GetString(2).ToString(), resultadosSQL.GetString(3).ToString(), 
                                       resultadosSQL.GetString(4).ToString());
            }
        }
    }
}
