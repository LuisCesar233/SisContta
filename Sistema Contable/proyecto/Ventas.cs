﻿using System;
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
    public partial class Ventas : Form
    {
        public Ventas()
        {
            InitializeComponent();
            grilla(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            Datos();
        }

        double[] datos = new double[6];
        void grilla(DataGridView dgv)
        {
            dgv.ColumnCount = 3;
            dgv.RowCount = 6;
            dgv.RowHeadersVisible = false;
            //dgv.ColumnHeadersVisible = false;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        void Datos()
        {
            if (comboBox1.Text == "Venta")
            {
                double dat = Convert.ToDouble(textBox1.Text);
                double aux = 0, aux2;
                aux = dat;
                aux2 = dat;
                for (int i = 0; i < 6; i++)
                {
                    if (i <= 1)
                    {
                        datos[i] = dat;
                        dat = dat * 0.03;
                    }
                    else if (i == 4)
                        datos[i] = datos[1];
                    else
                    {
                        datos[i] = aux * 0.87;
                        aux = aux2 * 0.13;
                    }
                }
            }
            VentaNormal();
        }

        string[] nombre = { "caja m/n", "IT", "Venta", "D.F IVA", "IT por pagar" };
        void VentaNormal()
        {
            string ap;
            if (comboBox1.Text == "Venta")
            {
                for (int i = 0; i < 5; i++)
                {
                    DatosCompra o = new DatosCompra();
                    dataGridView1[0, i].Value = nombre[i];
                    if (i < 2)
                    {
                        dataGridView1[1, i].Value = string.Format("{0:C2}.",datos[i]);
                        o.compra =Convert.ToInt32( string.Format("{0:C2}.", datos[i]));
                        o.estado = true;
                    }
                    else
                    {
                        dataGridView1[2, i].Value = string.Format("{0:C2}.", datos[i]);
                        o.compra = Convert.ToInt32(string.Format("{0:C2}.", datos[i]));
                        o.estado = false;
                    }
                    DatosCompra.lista.Add(o);
                }
            }
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
    }
}
