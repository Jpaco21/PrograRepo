using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tarea9
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void CargarLibros()
        {
            dataGridView1.Rows.Clear();

            foreach (Libro libro in DatosBiblioteca.Libros)
            {
                dataGridView1.Rows.Add(
                    libro.Nombre,
                    libro.Autor,
                    libro.Anio
                );
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource =
                DatosBiblioteca.Libros.ToArray();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 ventana = new Form4();
            ventana.Show();
        }
    }
}
