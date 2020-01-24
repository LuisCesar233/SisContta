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

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            decimal o;
            if (textBox1.Text.Contains(",,"))
            {
                o = Convert.ToDecimal(textBox1.Text = textBox1.Text.Replace(",,", ","));
                textBox1.Text = o.ToString("N2");
                textBox1.SelectionStart = textBox1.Text.Length - 2;
            }
            else if (textBox1.Text.Length > 2)
            {

                if (textBox1.SelectionStart == textBox1.Text.Length - 2)
                {
                    o = Convert.ToDecimal(textBox1.Text);
                    textBox1.Text = o.ToString("N2");
                    textBox1.SelectionStart = textBox1.Text.Length - 1;
                }
                else if (textBox1.SelectionStart == textBox1.Text.Length - 1)
                {
                    textBox1.SelectionStart = textBox1.Text.Length - 1;
                }
                else
                {
                    o = Convert.ToDecimal(textBox1.Text);
                    textBox1.Text = o.ToString("N2");
                    textBox1.SelectionStart = textBox1.Text.Length - 3;
                }
            }
        }

        string[] nombre = { "compra", "C.F. IVA", "total" };
        void llenarCompra(double a, double b, double c)
        {
            DatosCompra d = new DatosCompra();
            p
            DatosCompra.lista.Add(d);
        }
    }
}
