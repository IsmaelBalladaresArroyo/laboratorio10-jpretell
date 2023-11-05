using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listaClientes(txtBuscar.Text);
            listaPedidos(txtBuscar.Text);
            buscarFechas(time1.Text, time2.Text);
        }

        private void listaClientes(string data)
        {
            using (NegociosEntities BD = new NegociosEntities())
            {
                var sql = from p in BD.CLIENTE
                          where p.NombreCia.Contains(data)
                          select new 
                          {
                              p.IdCliente,
                              p.NombreCia,
                              p.Direccion, 
                              p.idpais, 
                              p.Telefono,
                              p.Estado };
                this.dataGridView1.DataSource = sql.ToList();
            }
        }

        private void listaPedidos(string data)
        {
            using (NegociosEntities BD = new NegociosEntities())
            {
                var sql = from p in BD.PEDIDO
                          where p.CLIENTE.NombreCia.Contains(data)
                          select new
                          {
                              p.CLIENTE.NombreCia,
                              p.IdPedido,
                              p.IdEmpleado,
                              p.IdCliente,
                              p.FechaPedido,
                              p.FechaEntrega,
                              p.Envio,
                              p.Cargo
                          };
                this.dataGridView2.DataSource = sql.ToList();
            }
        }
        private void buscarFechas(string fecha1, string fecha2) 
        {
            
            
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            listaClientes(txtBuscar.Text);
            listaPedidos(txtBuscar.Text);
            buscarFechas(time1.Text, time2.Text);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
