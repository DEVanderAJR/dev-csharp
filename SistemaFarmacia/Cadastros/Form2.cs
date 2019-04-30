//BIBLIOTECA
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Sistema_Hebe_Halsa
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }
        private static DataSet dataset = new DataSet("DataSet");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        //ABRE A TELA DE CADASTRO
        private void button1_Click(object sender, EventArgs e)
        {
           
            Cadastro_de_Produtos abrir = new Cadastro_de_Produtos();
            abrir.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {


        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        //DATAGRID VAZIA
        private void button5_Click(object sender, EventArgs e)
        { 
            dataGridView1 = null;
            Dispose();
           
        }

        private void hEBEHALSADataSet1BindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            }

            //EXIBE AS INFORMAÇÕES DOS MEDICAMENTOS
            private void button3_Click_1(object sender, EventArgs e)
            {
            //TEXTO INICIAL IGUAL A ZERO
            label7.Text = null;
            DataSet ds = new DataSet();

            //STRING DE CONEXÃO
            string strConn = "Persist Security Info=False; server=localhost; database=REGOUGAR; uid=root; pwd=admin";

            //PASSAGEM DA STRING PARA A INSTANCIA DO OBJETO MYSQLCONNECTION
            MySqlConnection conn = new MySqlConnection(strConn);

            //PASANGEM DA QUERY DE CONSULTA PARA A INSTANCIA DO OBJETO MYSQLDATAADAPTER
            MySqlDataAdapter da = new MySqlDataAdapter("Select * from medicamento", conn);
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];//SERÁ EXIBIDO AS INFORMAÇÕES DOS MEDICAMENTOS NO DATAGRID
        }
        //ABRE A TELA DE EXCLUSÃO DE CADASTROS
        private void button2_Click(object sender, EventArgs e)
        {
            Excluir_Medicamento mostrar = new Excluir_Medicamento();
            mostrar.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            vieww mostrar = new vieww();
            mostrar.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }
        //PESQUISA DE MEDICAMENTO POR NOME
        private void button6_Click(object sender, EventArgs e)
        {
            label7.Text = null;

            //INSTANCIANDO OS OBJETOS TIPO CONNECTION E MYSQLCOMMAND
            MySqlConnection conn = new MySqlConnection();
            MySqlCommand sqlComand = new MySqlCommand();

            //STRING DE CONEXÇÃO COM O BANCO
            conn.ConnectionString = "Persist Security Info=False; server=localhost; database=regougar; uid=root; pwd=admin";

            //PASSAGEM DA STRING
            sqlComand.Connection = conn;

            //PASSAGEM DA QUERY
            sqlComand.CommandText = "select idMedicamento,Nome,Preço from medicamento where Nome like'%" + textBox1.Text + "%'";

            //LIMPANDO OS PARAMETROS PASSADOS
            sqlComand.Parameters.Clear();
          
            DataSet ds = new DataSet();

            //PASSAGEM DA STRING PARA DATAADAPTER
            MySqlDataAdapter madpt = new MySqlDataAdapter(sqlComand);
            madpt.Fill(dataset,"medicamento");
            dataGridView1.DataSource = dataset.Tables[0]; //EXIBIÇÃO DAS INFORMAÇÕES DO MEDICAMENTO DIGITADO EM UM OBJETO DATAGRID
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //PESQUISA DE MEDICAMENTO POR CÓDIGO
        private void button7_Click(object sender, EventArgs e)
        {
            label7.Text = null;
            MySqlConnection conn = new MySqlConnection();
            MySqlCommand sqlComand = new MySqlCommand();

            //STRING DE CONEXÃO COM O BANCO
            conn.ConnectionString = "Persist Security Info=False; server=localhost; database=regougar; uid=root; pwd=admin";

            //PASSAGEM DA STRING
            sqlComand.Connection = conn;

            //PASSAGEM DA QUERY DE CONSULTA PARA SQLCOMMAND
            sqlComand.CommandText = "select idMedicamento,Nome,Preço from medicamento where idMedicamento=@idMedicamento";

            //LIMPANDO OS PARAMETROS PASSADOS
            sqlComand.Parameters.Clear();

            //ATRIBUINDO O CODIGO DIGITADO PARA A PESQUISA NO BANCO
            MySqlParameter param;
            param = new MySqlParameter();
            param.ParameterName = "idMedicamento";//declaro qual e o paramentro do sql
            param.DbType = DbType.String;
            sqlComand.Parameters.Add(param);//passa o parametro
            sqlComand.Parameters["idMedicamento"].Value = textBox3.Text;//VALOR DIGITADO


            MySqlDataAdapter madpt = new MySqlDataAdapter(sqlComand);
            madpt.Fill(dataset,"medicamento");
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dataset.Tables[0];//EXIBIÇÃO DAS INFORMAÇÕES DO MEDICAMENTO DIGITADO EM UM OBJETO DATAGRID
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}