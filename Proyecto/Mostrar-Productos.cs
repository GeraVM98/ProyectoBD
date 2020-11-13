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
    public partial class Mostrar_Productos : Form
    {

        OdbcConnection conexionBD;
        string sql;
        OdbcCommand comandoSQl;

        public Mostrar_Productos()
        {
            InitializeComponent();
            Form1 frm1 = new Form1();
            conexionBD = frm1.conexionBD;
        }

        private void Mostrar_Productos_Load(object sender, EventArgs e)
        {
            sql = "SELECT * FROM `productos` WHERE 1";
            comandoSQl = new OdbcCommand(sql, conexionBD);
            OdbcDataReader resultadosSQL = comandoSQl.ExecuteReader();
            while (resultadosSQL.Read())
            {
                dataGridView1.Rows.Add(resultadosSQL.GetString(0).ToString(), resultadosSQL.GetString(1).ToString(),
                                       resultadosSQL.GetString(2).ToString(), resultadosSQL.GetString(4).ToString(),
                                       resultadosSQL.GetString(3).ToString(), resultadosSQL.GetString(10).ToString(),
                                       resultadosSQL.GetString(5).ToString(), resultadosSQL.GetInt32(6).ToString(),
                                       resultadosSQL.GetInt32(7).ToString(), "$"+resultadosSQL.GetFloat(8).ToString(),
                                       "$" + resultadosSQL.GetFloat(9).ToString());
            }
        }
    }
}
