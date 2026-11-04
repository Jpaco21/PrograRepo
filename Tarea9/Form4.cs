using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;

namespace Tarea9
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            int cantidad = DatosBiblioteca.Libros.Count;

            listBox1.Items.Add("Cantidad de libros registrados: " + cantidad);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DatosBiblioteca.Libros.Count > 0)
            {
                Libro eliminado = DatosBiblioteca.Libros.Pop();

                listBox1.Items.Clear();

                listBox1.Items.Add("Libro eliminado correctamente:");
                listBox1.Items.Add("Nombre: " + eliminado.Nombre);
                listBox1.Items.Add("Autor: " + eliminado.Autor);
                listBox1.Items.Add("Año: " + eliminado.Anio);
                listBox1.Items.Add("Libros restantes: " + DatosBiblioteca.Libros.Count);
            }
            else
            {
                MessageBox.Show("No hay libros para eliminar.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
