namespace Tarea9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" &&
        textBox2.Text == "1234")
            {
                Form2 ventana = new Form2();
                ventana.Show();
            }
            else
            {
                MessageBox.Show("error");
            }
        }
    }
}
