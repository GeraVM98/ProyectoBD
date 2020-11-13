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
    public partial class Form1 : Form
    {

        public OdbcConnection conexionBD;

        public Form1()
        {
            InitializeComponent();
            conexionBD = new OdbcConnection("Driver={MySQL ODBC 8.0 ANSI Driver};" +
                   "Server=localhost;" +
                   "Port=3306;Database=vet-soft;" +
                   "User=root;Password=;Option=3;");

            try
            {
                //se instancio el objeto para ser inicializado
                conexionBD.Open();
            }
            catch (OdbcException ex)
            {
                MessageBox.Show(ex.Message);
                //si hay algun error lo muestra en la pantalla
            }
        }

        private void insertarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Insertar_Cliente newMDIChild = new Insertar_Cliente();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void insertarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Insertar_Empleado newMDIChild = new Insertar_Empleado();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void insertarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Insertar_Producto newMDIChild = new Insertar_Producto();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void mostrarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mostrar_Cliente newMDIChild = new Mostrar_Cliente();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void mostrarTodosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Mostrar_Productos newMDIChild = new Mostrar_Productos();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void mostrarTodosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Mostrar_Empleados newMDIChild = new Mostrar_Empleados();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Buscar_Cliente newMDIChild = new Buscar_Cliente();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void buscarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Buscar_Producto newMDIChild = new Buscar_Producto();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void buscarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Buscar_Empleado newMDIChild = new Buscar_Empleado();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Insertar_Venta newMDIChild = new Insertar_Venta();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Buscar_Venta newMDIChild = new Buscar_Venta();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }
    }
}
