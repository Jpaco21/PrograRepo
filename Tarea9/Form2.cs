using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tarea9
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            string autor = textBox2.Text;
            string anioTexto = textBox3.Text;

            int anio;

            if (nombre == "" || autor == "" || anioTexto == "")
            {
                MessageBox.Show("Completa todos los campos.");
            }
            else if (!int.TryParse(anioTexto, out anio))
            {
                MessageBox.Show("Ingresa un año válido.");
            }
            else
            {
                Libro nuevoLibro = new Libro(nombre, autor, anio);

                DatosBiblioteca.Libros.Push(nuevoLibro);

                MessageBox.Show("Libro guardado correctamente.");

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 ventana = new Form3();
            ventana.Show();
        }
    }
}




