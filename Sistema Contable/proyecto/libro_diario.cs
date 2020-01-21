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
    public partial class libro_diario : Form
    {
        int contador = 1;
        string detalle;
        string glosa;
        public libro_diario()
        {
            InitializeComponent();
        }

        private void libro_diario_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            glosa = textBox2.Text;
        }
        void grilla(DataGridView dgv)
        {
            dgv.ColumnCount = 5;
            dgv.RowCount = 1;
            dgv.RowHeadersVisible = false;
            //dgv.ColumnHeadersVisible = false;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        int tam = 0;
        void llenarCompra()
        {

            var o = DatosCompra.lista[contador];
            dataGridView1.RowCount += DatosCompra.lista.Count + 2;
            dataGridView1[0, 0 + tam].Value = dateTimePicker1.Value;
            dataGridView1[3, 0 + tam].Value = o.compra;
            dataGridView1[3, 1 + tam].Value = o.iva;
            dataGridView1[4, 2 + tam].Value = o.total;
            tam += 4;
            contador++;
        }

        void llenarVentas()
        {

            var o = DatosCompra.lista[0];
            dataGridView1.RowCount += DatosCompra.lista.Count;
            dataGridView1[0, 0].Value = dateTimePicker1.Value;
            //dataGridView1[3, 0].Value = o.compra;
            //dataGridView1[3, 1].Value = o.iva;
            //dataGridView1[4, 2].Value = o.total;

            for (int i = 0; i < DatosCompra.lista.Count; i++)
            {
                var q = DatosCompra.lista;
                if (q[i].estado)
                    dataGridView1[3, i].Value = q[i].compra;
                else
                    dataGridView1[4, i].Value = q[i].compra;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Egreso")
            {
                Compras c = new Compras();
                c.ShowDialog();
                /// vghvh llenarCompras();
            }
            if (comboBox1.Text == "Ingreso")
            {
                Ventas v = new Ventas();
                v.ShowDialog();
                llenarVentas();
            }
        }
    }
}
