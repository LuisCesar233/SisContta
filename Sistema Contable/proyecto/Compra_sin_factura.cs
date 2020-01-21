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
    public partial class Compra_sin_factura : Form
    {
        public Compra_sin_factura()
        {
            InitializeComponent();
            grilla(dataGridView1);
        }
        string[] nombre = { "Servicios", "IUE", "IT retencion", "Caja M/N" };
        int[] datos = new int[4];
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Recibo")
            {
                if (comboBox2.Text == "Bienes")
                {
                    double a = double.Parse(textBox1.Text);
                    double iue5 = a * 0.05;
                    double it = a * 0.03;
                    double caja = a - (iue5 + it);
                    llenarRecibo(a, iue5, it, caja);
                }
            }
        }

        void grilla(DataGridView dgv)
        {
            dgv.ColumnCount = 3;
            dgv.RowCount = 4;
            dgv.RowHeadersVisible = false;
            //dgv.ColumnHeadersVisible = false;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        void llenarRecibo(double a, double b, double c, double d)
        {

            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    datos[i] = Convert.ToInt32(a);
                }
                if (i == 1)
                {
                    datos[i] = Convert.ToInt32(b);
                }
                if (i == 2)
                    datos[i] = Convert.ToInt32(c);
                if (i == 3)
                    datos[i] = Convert.ToInt32(d);
                DatosCompra o = new DatosCompra();
                dataGridView1[0, i].Value = nombre[i];
                if (i < 1)
                {
                    dataGridView1[1, i].Value = datos[i];
                }
                else
                {
                    dataGridView1[2, i].Value = datos[i];
                }
            }
        }
    }
}
