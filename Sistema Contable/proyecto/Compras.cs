using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto
{
    public partial class Compras : Form
    {
        double a, b, c;
        libro_diario l = new libro_diario();
        public Compras()
        {
            InitializeComponent();
            grilla(dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Compra sin Factura")
            {
                Compra_sin_factura c = new Compra_sin_factura();
                c.Show();
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Compra")
            {

                a = double.Parse(textBox1.Text);
                b = a * 0.87;
                c = a * 0.13;
                llenarCompra(a, b, c);
            }
            if (comboBox1.Text == "Compra Combustible")
            {

                a = double.Parse(textBox1.Text);
                double aux = a * 0.70;
                c = aux * 0.13;
                double aux1 = a - c;
                llenarCompraGaso(aux1, c, a);
            }
            if (comboBox1.Text == "Compra Biblioteca")
            {
                a = double.Parse(textBox1.Text);
                b = a;
                llenarCompraLibro(a, a);
            }
            if (comboBox1.Text == "Compra sin Factura por Servicios")
            {
                a = double.Parse(textBox1.Text);
                b = a * 0.125;
                c = a * 0.03;
            }
        }

        void grilla(DataGridView dgv)
        {
            dgv.ColumnCount = 3;
            dgv.RowCount = 1;
            dgv.RowHeadersVisible = false;
            //dgv.ColumnHeadersVisible = false;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        string[] nombre = { "compra", "C.F. IVA", "total" };
        void llenarCompra(double a, double b, double c)
        {
            DatosCompra d = new DatosCompra();
            d.total = a;
            d.compra = b;
            d.iva = c;
            DatosCompra.lista.Add(d);
            dataGridView1[0, 0].Value = b;
            dataGridView1[1, 0].Value = c;
            dataGridView1[2, 0].Value = a;
        }

        void llenarCompraLibro(double a, double b)
        {
            dataGridView1[0, 0].Value = a;
            dataGridView1[1, 0].Value = b;
            DatosCompra d = new DatosCompra();
            d.total = a;
            d.compra = b;
            DatosCompra.lista.Add(d);
        }

        void llenarCompraGaso(double aux, double c, double a)
        {
            dataGridView1[0, 0].Value = a;
            dataGridView1[1, 0].Value = aux;
            dataGridView1[2, 0].Value = c;
            DatosCompra d = new DatosCompra();
            d.total = a;
            d.compra = aux;
            d.iva = c;
            DatosCompra.lista.Add(d);
        }
    }
}
