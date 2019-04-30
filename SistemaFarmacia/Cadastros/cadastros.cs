using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sistema_Hebe_Halsa
{
    public partial class cadastros : Form
    {
        public cadastros()
        {
            InitializeComponent();
        }

        private void cadastros_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'regougarDataSet26.fornecedor' table. You can move, or remove it, as needed.
            this.fornecedorTableAdapter3.Fill(this.regougarDataSet26.fornecedor);
           
            // TODO: This line of code loads data into the 'regougarDataSet18.cliente' table. You can move, or remove it, as needed.
            this.clienteTableAdapter.Fill(this.regougarDataSet18.cliente);

        } 

        //ABRIR NOVA TELA
        private void button8_Click(object sender, EventArgs e)
        {
            Cadastro_de_Produtos abrir = new Cadastro_de_Produtos();
            abrir.Show();
        }
        //FECHAR A TELA
        private void button4_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
