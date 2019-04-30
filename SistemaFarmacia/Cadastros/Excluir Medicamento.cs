            //BIBLIOTECA
            using System;
            using System.Collections.Generic;
            using System.ComponentModel;
            using System.Data;
            using System.Drawing;
            using System.Linq;
            using System.Text;
            using System.Windows.Forms;
            using MySql.Data.MySqlClient;

            namespace Sistema_Hebe_Halsa
            {
            public partial class Excluir_Medicamento : Form
            {
            public Excluir_Medicamento()
            {
            InitializeComponent();
            }

            private void label2_Click(object sender, EventArgs e)
            {

            }

            private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
            {

            }

            private void label1_Click(object sender, EventArgs e)
            {

            }

            private void textBox2_TextChanged(object sender, EventArgs e)
            {

            }


            //OBJETOS DATAGRID, COM INFORMAÇÕES DOS MEDICAMENTOS, CLIENTES E FORNECEDORES
            private void Excluir_Medicamento_Load(object sender, EventArgs e)
            {
            // TODO: This line of code loads data into the 'regougarDataSet25.fornecedor' table. You can move, or remove it, as needed.
            this.fornecedorTableAdapter3.Fill(this.regougarDataSet25.fornecedor);
            // TODO: This line of code loads data into the 'regougarDataSet24.medicamento' table. You can move, or remove it, as needed.
            this.medicamentoTableAdapter4.Fill(this.regougarDataSet24.medicamento);
            // TODO: This line of code loads data into the 'regougarDataSet22.fornecedor' table. You can move, or remove it, as needed.
            this.fornecedorTableAdapter2.Fill(this.regougarDataSet22.fornecedor);
            // TODO: This line of code loads data into the 'regougarDataSet17.medicamento' table. You can move, or remove it, as needed.
            this.medicamentoTableAdapter3.Fill(this.regougarDataSet17.medicamento);
            // TODO: This line of code loads data into the 'regougarDataSet16.cliente' table. You can move, or remove it, as needed.
            this.clienteTableAdapter1.Fill(this.regougarDataSet16.cliente);

            }

            //FECHA A TELA ATUAL
            private void button3_Click(object sender, EventArgs e)
            {
            Dispose();
            }

            private void label10_Click(object sender, EventArgs e)
            {

            }

            private void richTextBox1_TextChanged(object sender, EventArgs e)
            {

            }


            //EXCLUSÃO DE CADASTROS
            private void button4_Click(object sender, EventArgs e)
            {

            //DECLARAÇÃO DE USUÁRIO
            int w=0, ww=0;

            //VERIFICA SE AS CAIXAS BOX ESTÃO CHECADAS
            if ((checkBox1.Checked && checkBox2.Checked && checkBox3.Checked == false))
            { 

            //MENSAGEM EXIBIDA
            MessageBox.Show("Selecione uma Categoria!");
            }
            // DESMARCA AS CAIXAS ENQUANTO DUAS OU MAIS CAIXAS DE CHECAGEM ESTÃO CHECADAS
            while((checkBox1.Checked && checkBox2.Checked && checkBox3.Checked) || (checkBox1.Checked && checkBox2.Checked) || (checkBox1.Checked && checkBox3.Checked) ||(checkBox2.Checked && checkBox3.Checked)== true )
            {

            //MENSAGEM EXIBIDA
            MessageBox.Show("Escolha apenas uma Categoria!");

            //TODAS AS CAIXAS SÃO DESMARCADAS
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox1.Checked = false;
            }

            //INSTANCIANDO OBJETOS DO TIPO MYSQLCONNECTION E COMMAND    
            MySqlConnection conn = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();

            //TRATADOR DE ERRO
            try
            {
            //STRING DE CONEXÃO
            conn.ConnectionString = "Persist Security Info=False; server=localhost; database=regougar; uid=root; pwd=admin";

            //CASO A CHECBOX MEDICAMENTO (CAIXA) SEJA MARCADA (TRUE)
            if (checkBox1.Checked)
            {

            //VERIFICA SE O CODIGO FOI DIGITADO
            if (textBox2.Text == "")
            {
            w = 1;
            ww = 1;
            }    

            //ENQUANTO O CAMPO ESTIVER VAZIO REPITA O ESCOPO DO WHILE
            while (textBox2.Text == "" && w == 1)
            {
            //MENSAGEM EXIBIDA
            MessageBox.Show("Digite o Código a ser Excluído!");
            w = 0;
            ww = 2;
            }
            //VERIFICA SE O CÓDIGO DO MEDICAMENTO DIGITADO EXISTE
            cmd.CommandText = "Select count(*) From medicamento where idmedicamento='" + textBox2.Text + "'";

            //DECLARAÇÃO DA VARIÁVEL COUNT DA QUERY ACIMA
            cmd.Connection = conn;
            int count = Convert.ToInt16( cmd.ExecuteScalar());

            //ABRE A CONEXÃO
            conn.Open();

            //CASO SEJA MAIOR QUE ZERO ELE EXISTE E PODE SER EXCLUIDO    
            if (count > 0)
            {

            //DELETA O MEDICAMENTO COM O CODIGO DIGITADO
            cmd.CommandText = "Delete from medicamento where idMedicamento = @idMedicamento";
            cmd.Parameters.Add("@idMedicamento", Convert.ToInt64(textBox2.Text));

            //EXECUTA A OPERAÇÃO NO BANCO
            cmd.ExecuteNonQuery();

            //FECHA A CONEXÃO
            conn.Close();
            MessageBox.Show("Medicamento Excluído");
            }

            //CASO SEJA ZERO, EXIBE A MENSAGEM A BAIXO
            else MessageBox.Show("Inexistente!");
            }
            //CASO A CHECBOX CLIENTE (CAIXA) SEJA MARCADA (TRUE)
            if (checkBox3.Checked)
            {
            //SE O CAMPO ESTIVER DIGITADO
            if (textBox2.Text == "")
            {
            //ATRIBUI OS VALORES
            w = 1;
            ww = 1;
            }
            //ENQUANTO O CAMPO ESTIVER VAZIO
            while (textBox2.Text == "" && w == 1)
            {
            MessageBox.Show("Digite o Código a ser Excluído!");
            w = 0;
            ww = 2;

            }
            //VERIFICA SE O CÓDIGO DO CLIENTE DIGITADO EXISTE
            cmd.CommandText = "Select count(*) From cliente where idCliente='" + textBox2.Text + "'";

            //DECLARAÇÃO DA VARIÁVEL COUNT DA QUERY ACIMA
            cmd.Connection = conn;

            //ABRE A CONEXÃO
            conn.Open();
            int count = Convert.ToInt16( cmd.ExecuteScalar());

            //CASO SEJA MAIOR QUE ZERO ELE EXISTE E PODE SER EXCLUIDO 
            if (count > 0)
            {
            //TRATADOR DE ERRO
            try
            {
            //ATRIBUIÇÃO DO CÓDIGO DIGITADO A SER DELETADO DO BANCO
            cmd.CommandText = "Delete from cliente where idCliente = @idCliente";
            cmd.Parameters.Add("@idCliente", Convert.ToInt64(textBox2.Text));

            //EXECUTA A OPERAÇÃO DE DELETAR NO BANCO
            cmd.ExecuteNonQuery();

            //FECHA A CONEXÃO
            conn.Close();
            MessageBox.Show("Cliente Excluído");

            //FIM TRY
            }
            //EXIBE UMA MENSAGEM DE ERRO ENCONTRADO NO TRY
            catch (MySqlException ex)
            {
            MessageBox.Show("O Preenchimento do Campo está Incorreto!\n", ex.Message, MessageBoxButtons.OK);
            }
            }
            else MessageBox.Show("Inexistente");
            }

            //CASO A CHECBOX FORNECEDOR (CAIXA) SEJA MARCADA (TRUE)
            if (checkBox2.Checked)
            {
            if (textBox2.Text == "")
            {   w = 1;
            ww = 1;
            }

            while (textBox2.Text == "" && w == 1)
            {
            MessageBox.Show("Digite o Código a ser Excluído!");
            w = 0;
            ww = 2;

            }
            cmd.CommandText = "Select count(*) From fornecedor where idFornecedor='" + textBox2.Text + "'";

            cmd.Connection = conn;

            conn.Open();
            int count = Convert.ToInt16( cmd.ExecuteScalar());

            if (count > 0)
            {


            try
            {
            cmd.CommandText = "Delete from fornecedor where idFornecedor = @idFornecedor";
            cmd.Parameters.Add("@idFornecedor", Convert.ToInt64(textBox2.Text));


            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Fornecedor Excluído");
            }

            catch (MySqlException ex)
            {

            MessageBox.Show("O Preenchimento do Campo está Incorreto!\n", ex.Message, MessageBoxButtons.OK);
            }
            }
            else MessageBox.Show("Inexistente!");
            }


            }
            catch (MySqlException ex)
            {

            MessageBox.Show("O Preenchimento do Campo está Incorreto!\n", ex.Message, MessageBoxButtons.OK);
            }

            textBox2.Text = null;

            }

            private void checkBox1_CheckedChanged(object sender, EventArgs e)
            {

            }

            private void label12_Click(object sender, EventArgs e)
            {

            }

            private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
            {

            }

            //OBJETOS DO TIPO DATAGRID, PARA EXIBIÇÃO DAS INFORMAÇÕES DO MEDICAMENTO DO CLIENTE E FORNECEDOR
            private void button1_Click(object sender, EventArgs e)
            {

            //INSTANCIANDO OBJETOS DO TIPO DATASET
            DataSet ds = new DataSet();//PARA MEDICAMENTO
            DataSet dcc = new DataSet();//PARA CLIENTE
            DataSet dff= new DataSet();//PARA FORNECEDOR

            //STRING DE CONEXÃO
            string strConn = "Persist Security Info=False; server=localhost; database=REGOUGAR; uid=root; pwd=admin";

            //INTANCIANDO OBJETOS DO TIPO MYSQLCONNECTION E DATAADAPTER
            MySqlConnection conn = new MySqlConnection(strConn);
            MySqlDataAdapter dm = new MySqlDataAdapter("Select * from medicamento", conn);//PARA MEDICAMENTO
            MySqlDataAdapter dc = new MySqlDataAdapter("Select *from cliente", conn);//CLIENTE
            MySqlDataAdapter df = new MySqlDataAdapter("Select *from fornecedor", conn);//FORNECEDOR
            dm.Fill(ds);
            dc.Fill(dcc);
            df.Fill(dff);

            //INFORMAÇÕES ATUALIZADAS E EXIBITADAS POR OBJETOS DATAGRID
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView2.DataSource = dcc.Tables[0];
            dataGridView3.DataSource = dff.Tables[0];
            }

            private void checkBox2_CheckedChanged(object sender, EventArgs e)
            {

            }

            private void checkBox3_CheckedChanged(object sender, EventArgs e)
            {

            }

            private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {

            }

            private void textBox1_TextChanged(object sender, EventArgs e)
            {

            }
            //PESQUISA DE MEDICAMENTO, CLIENTE FORNECEDOR POR NOME
            private void button6_Click(object sender, EventArgs e)
            {
            DataSet dataset = new DataSet();

            label7.Text = null;
            MySqlConnection conn = new MySqlConnection();
            MySqlCommand sqlComand = new MySqlCommand();


            //STRING DE CONEXÃO
            conn.ConnectionString = "Persist Security Info=False; server=localhost; database=regougar; uid=root; pwd=admin";
            sqlComand.Connection = conn;

            //VERIFICA SE DUAS OU MAIS CAIXAS ESTÃO CHECADAS
            if(!(checkBox1.Checked || checkBox2.Checked || checkBox3.Checked)){
            MessageBox.Show("Escolha uma das Categorias de Exclusão à baixo!");
            }

            //ENQUANTO TIVER MAIS DE UMA CHECADA REPITA
            while ((checkBox1.Checked && checkBox2.Checked && checkBox3.Checked) || (checkBox1.Checked && checkBox2.Checked) || (checkBox1.Checked && checkBox3.Checked) || (checkBox2.Checked && checkBox3.Checked) == true)
            {
            MessageBox.Show("Escolha apenas uma Categoria!");

            //AS CAIXAS RECEBEM VALOR NULO, FALSE
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox1.Checked = false;
            }

            //SE VERDADEIRO EXIBE OS MEDICAMENTOS DE ACORDO COM O DESEJADO
            if (checkBox1.Checked == true)
            {
            //PASSAGEM DA QUERY PARA A CONSULTA NO BANCO
            sqlComand.CommandText = "select idMedicamento,Nome,Vencimento,Uso,Preço from medicamento where Nome like'%" + textBox1.Text + "%'";
            DataSet ds = new DataSet();
            MySqlDataAdapter madpt = new MySqlDataAdapter(sqlComand);
            madpt.Fill(dataset, "medicamento");
            dataGridView1.DataSource = dataset.Tables[0];//SERÁ EXIBDIO NO OBJETO DATAGRID AS INFORMAÇÕES MEDICAMENTO
            }

            //SE VERDADEIRO EXIBE OS CLIENTE DE ACORDO COMO DIGITADO
            if (checkBox3.Checked==true)
            {
            //PASSAGEM DA QUERY PRA A CONSULTA NO BANCO
            sqlComand.CommandText = "select idCliente,Nome,Telefone,Celular from cliente where Nome like'%" + textBox1.Text + "%'";

            DataSet ds = new DataSet();
            MySqlDataAdapter madpt = new MySqlDataAdapter(sqlComand);
            madpt.Fill(dataset, "cliente");
            dataGridView2.DataSource = dataset.Tables[0];//SERÁ EXIBIDO NO OBJETO DATAGRID AS INFORMAÇOES DO CLIENTE
            }
            //SE VERDADEIRO EXIBE OS FORNECEDORES DE ACORDO COMO DIGITADO
            if (checkBox2.Checked == true)
            {
            //PASSAGEM DA QUERY PARA A CONSULTA NO BANCO
            sqlComand.CommandText = "select idFornecedor,Nome,Telefone,Celular from fornecedor where Nome like'%" + textBox1.Text + "%'";
            DataSet ds = new DataSet();
            MySqlDataAdapter madpt = new MySqlDataAdapter(sqlComand);
            madpt.Fill(dataset, "fornecedor");
            dataGridView3.DataSource = dataset.Tables[0];//SERÁ EXIBIDO NO OBJETO DATAGRID AS INFORMAÇÕES DO FORNECEDOR
            }

            }

            private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {

            }

            //PESQUISA DE MEDICAMENTO CLIENTE E FORNECEDOR POR CÓDIGO
            private void button7_Click(object sender, EventArgs e)
            {
            DataSet dataset = new DataSet();

            MySqlConnection conn = new MySqlConnection();
            MySqlCommand sqlComand = new MySqlCommand();


            //STRING DE CONEXÃO
            conn.ConnectionString = "Persist Security Info=False; server=localhost; database=regougar; uid=root; pwd=admin";
            sqlComand.Connection = conn;

            //VERIFICA SE HÁ MAIS DE UMA CAIXA CHEGADA
            while ((checkBox1.Checked && checkBox2.Checked && checkBox3.Checked) || (checkBox1.Checked && checkBox2.Checked) || (checkBox1.Checked && checkBox3.Checked) || (checkBox2.Checked && checkBox3.Checked) == true)
            {

            //EXIBE A MENSAGEM DE ADVERTÊNCIA
            MessageBox.Show("Escolha apenas uma Categoria!");

            //CASO TENHA MAIS DE UMA MARCADA, TODAS SÃO DESMARCADAS
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox1.Checked = false;

            }

            //SE MEDICAMENTO ESCOLHIDO FAÇA;
            if (checkBox1.Checked == true)
            {
            sqlComand.CommandText = "select idMedicamento,Nome,Vencimento,Uso,Preço from medicamento where idMedicamento=@idMedicamento";

            sqlComand.Parameters.Clear();
            MySqlParameter param;

            param = new MySqlParameter();
            param.ParameterName = "idMedicamento";//declaro qual e o paramentro do sql
            param.DbType = DbType.String;
            sqlComand.Parameters.Add(param);//passa o parametro
            sqlComand.Parameters["idMedicamento"].Value = textBox3.Text;

            DataSet ds = new DataSet();
            MySqlDataAdapter madpt = new MySqlDataAdapter(sqlComand);
            madpt.Fill(dataset, "medicamento");
            dataGridView1.DataSource = dataset.Tables[0];
            }

            //SE CLIENTE ESCOLHIDO FAÇA;
            if (checkBox3.Checked == true)
            {
            sqlComand.CommandText = "select idCliente,Nome,Telefone,Celular from cliente where idCliente=@idCliente";

            sqlComand.Parameters.Clear();
            MySqlParameter param;

            param = new MySqlParameter();
            param.ParameterName = "idCliente";//declaro qual e o paramentro do sql
            param.DbType = DbType.String;
            sqlComand.Parameters.Add(param);//passa o parametro
            sqlComand.Parameters["idCliente"].Value = textBox3.Text;

            DataSet ds = new DataSet();
            MySqlDataAdapter madpt = new MySqlDataAdapter(sqlComand);
            madpt.Fill(dataset, "cliente");
            dataGridView2.DataSource = dataset.Tables[0];
            }

            //SE FORNECEDOR ESCOLHIDO FAÇA;
            if (checkBox2.Checked == true)
            {
            sqlComand.CommandText = "select idFornecedor,Nome,Telefone,Celular from fornecedor where idFornecedor=@idFornecedor";

            sqlComand.Parameters.Clear();
            MySqlParameter param;

            param = new MySqlParameter();
            param.ParameterName = "idFornecedor";//declaro qual e o paramentro do sql
            param.DbType = DbType.String;
            sqlComand.Parameters.Add(param);//passa o parametro
            sqlComand.Parameters["idFornecedor"].Value = textBox3.Text;

            DataSet ds = new DataSet();
            MySqlDataAdapter madpt = new MySqlDataAdapter(sqlComand);
            madpt.Fill(dataset, "fornecedor");
            dataGridView3.DataSource = dataset.Tables[0];
            }
            }
            }
            }

