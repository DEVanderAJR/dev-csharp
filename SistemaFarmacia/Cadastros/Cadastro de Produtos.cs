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
    public partial class Cadastro_de_Produtos : Form
    {
        public Cadastro_de_Produtos()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //FECHA A TELA
        private void button4_Click(object sender, EventArgs e)
        {
        Dispose();
        }
       
        private void Cadastro_de_Produtos_Load(object sender, EventArgs e)
        {

        }

        //CANCELA O CADASTRO
        private void button3_Click(object sender, EventArgs e)
        {
        Dispose();
        }

        //LIMPA OS CAMPOS
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            maskedTextBox2.Text = null;
            textBox8.Text = null;
            textBox9.Text = null;
            textBox10.Text = null;
            textBox11.Text = null;
            textBox12.Text = null;
            textBox13.Text = null;
            textBox14.Text = null;
            textBox15.Text = null;
            maskedTextBox3.Text = null;
            textBox17.Text = null;
            textBox18.Text = null;
            maskedTextBox1.Text = null;
            textBox20.Text = null;
            textBox21.Text = null;
            textBox22.Text = null;
            textBox23.Text = null;
            textBox24.Text = null;
            textBox25.Text = null;
            textBox26.Text = null;
            textBox27.Text = null;
            richTextBox1.Text = null;

        }

        private void maskedTextBox7_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
              
        }

        //CADASTRAR MEDICAMENTO
        private void button1_Click(object sender, EventArgs e)
        {
         
            int x = 0, xx = 0;

            //STRING DE CONEXÃO COM O BANCO 
            string strConn = "Persist Security Info=False; server=localhost; database=regougar; uid=root; pwd=admin";

            //PASSANDO A STRING DE CONEXÃO PARA MYSQLCONNECTION
            MySqlConnection conn = null;
            conn = new MySqlConnection(strConn);

            //PASSANDO OS VALORES A SEREM INSERIDOS NO BANCO
            string query = "INSERT INTO medicamento(Nome,Vencimento,Uso,Fornecedor,Preço,CodigoBarras,Observacao)values(@Nome,@Vencimento,@Uso,@Fornecedor,@Preço,@CodigoBarras,@Observacao)";

            //TRATADOR DE ERRO
            try
            {

                //VERIFICANDO SE A CONEXÃO ESTÁ FECHADA
                if (conn.State == ConnectionState.Closed)
                {

                    //SE SIM, ABRE A CONEXÃO                                            
                    conn.Open();
                }

                //PASSANDO  A STRING DE CONEXÃO, E A QUERY(INSERT) PARA MYSQLCOMMAND
                MySqlCommand cmd = new MySqlCommand(query, conn);

                //RECEBENDO OS VALORES A SEREM INSERIDOS NO BANCO
                cmd.Parameters.AddWithValue("@Nome", Convert.ToString(textBox1.Text));
                cmd.Parameters.AddWithValue("@Vencimento", Convert.ToString(textBox2.Text));
                cmd.Parameters.AddWithValue("@Uso", Convert.ToString(textBox3.Text));
                cmd.Parameters.AddWithValue("@Fornecedor", Convert.ToString(textBox4.Text));
                cmd.Parameters.AddWithValue("@Preço", Convert.ToString(textBox5.Text));
                cmd.Parameters.AddWithValue("@CodigoBarras", Convert.ToString(textBox6.Text));
                cmd.Parameters.AddWithValue("@Observacao", Convert.ToString(richTextBox1.Text));

                //VERIFICA SE OS CAMPOS FORAM DIGITADOS
                if (textBox1.Text == "" || richTextBox1.Text == "")
                {
                    xx = 1;
                    x = 1;
                }

                //MOSTRA A MENSAGEM A BAIXO, ENQUANTO OS CAMPOS NÃO FOREM CORRETAMENTE PREENCHIDOS
                while (xx == 1)
                {
                    MessageBox.Show("Digite todas as Informações!");
                    xx = 0;
                }

                //SE OS CAMPOS FOREM PREENCHIDOS CORRETAMENTE, OS DADOS SERÃO ARMAZENADOS
                if (x == 0)
                {
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Medicamento Incluido com Sucesso!");
                    xx = 2;
                }

            }//FIM TRATADOR DE ERRO

            //EXIBIÇÃO DA MENSAGEM DE ERRO ENCONTRADA NO TRY
            catch (MySqlException ex)
            {
                x++;
                MessageBox.Show("O Preenchimento dos Campos está Incorreto!\n", ex.Message, MessageBoxButtons.OK);
            }

            //VERIFICA SE A CONEXÃO ESTÁ FECHADA
            finally
            {

                //SE NÃO, ELA É FECHADA
                if (conn != null)
                {

                    conn.Close();
                }
            }

            //DEPOIS DOS DADOS INSERIDOS, OS DADOS DIGITADOS SÃO APAGADOS
            if (xx == 2)
            {
                textBox1.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
                textBox4.Text = null;
                textBox5.Text = null;
                textBox6.Text = null;
                richTextBox1.Text = null;
            }
        }


        //CADASTRAR CLIENTE
        private void button5_Click(object sender, EventArgs e)
        {
                //DECLARAÇÃO DE VARIÁVEIS
                int x = 0,xx=0;
            
                //STRING DE CONEXÃO COM O BANCO
                string strConn = "Persist Security Info=False; server=localhost; database=regougar; uid=root; pwd=admin";

                //PASSANGEM DA STRING PARA MSQLCONNECTION                   
                MySqlConnection conn = null;
                conn = new MySqlConnection(strConn);

                //PASSANDO OS VALORES A SEREM INSERIDOS NO BANCO
                string query = "INSERT INTO cliente(Nome,Identidade,Cpf,Telefone,Celular,Email,Rua,Bairro,Numero,Cidade,Cep)values(@Nome,@Identidade,@Cpf,@Telefone,@Celular,@Email,@Rua,@Bairro,@Numero,@Cidade,@Cep)";

                //TRATADOR DE ERRO
                try
                {

                //VERIFICA SE A CONEXÃO ESTÁ FECHADA
                if (conn.State == ConnectionState.Closed)
                {

                //ABRE A CONEXÃO
                conn.Open();
                }

                //PASSANDO A STRING DE CONEXÃO E A QUERY PARA INSERSÃO(INSERT)
                MySqlCommand cmd = new MySqlCommand(query, conn);

                //RECEBENDO OS DADOS DIGITADOS PARA SEREM INSERIDOS
                cmd.Parameters.AddWithValue("@Nome", Convert.ToString(textBox12.Text));//CAMPO NOME
                cmd.Parameters.AddWithValue("@Identidade", Convert.ToString(maskedTextBox2.Text));//CAMPO IDENTIDADE
                cmd.Parameters.AddWithValue("@Cpf", Convert.ToString(maskedTextBox1.Text));//CAMPO CPF
                cmd.Parameters.AddWithValue("@Telefone", Convert.ToString(maskedTextBox3.Text));//CAMPO TELEFONE
                cmd.Parameters.AddWithValue("@Celular", Convert.ToString(textBox20.Text));//CAMPO CELULAR
                cmd.Parameters.AddWithValue("@Email", Convert.ToString(textBox26.Text));//CAMPO EMAIL
                cmd.Parameters.AddWithValue("@Rua", Convert.ToString(textBox10.Text));//CAMPO RUA
                cmd.Parameters.AddWithValue("@Bairro", Convert.ToString(textBox9.Text));//CAMPO BAIRRO
                cmd.Parameters.AddWithValue("@Numero", Convert.ToString(textBox21.Text));//CAMPO NUMERO
                cmd.Parameters.AddWithValue("@Cidade", Convert.ToString(textBox8.Text));//CAMPO CIDADE 
                cmd.Parameters.AddWithValue("@Cep", Convert.ToString(textBox27.Text));//CAMPO CEP

                //VERIFICA SE OS DADOS FORAM DIGITADOS CORRETAMENTE
                if(textBox12.Text=="" || textBox10.Text =="" || maskedTextBox1.Text=="" || textBox21.Text=="" || textBox8.Text=="" || maskedTextBox2.Text=="")
                {
                xx=1;
                x = 1;
                }

                // EXECUTA A MENSAGEM A BAIXO SEMPRE, QUANDO OS DADOS NÃO FOREM PREENCHIDOS CORRETAMENTE
                while (xx==1)
                {
                MessageBox.Show("Digite todas as Informações!");
                xx = 0;
                }

                //SE TODOS FOREM DIGITADOS CORRETAMENTE INSERE OS DADOS NO BANCO
                if (x==0)
                {
                cmd.ExecuteNonQuery();

                //FECHA A CONEXÃO
                conn.Close();

                //MENSAGEM EXIBIDA
                MessageBox.Show("Cliente Incluido com Sucesso!");
                xx = 2;
                } 
                }

                //EXIBE A MENSAGEM DO TRATOR DE ERRO TRY;
                catch (MySqlException ex)
                {
                x++;

                //EXIBE A MENSAGEM  A BAIXO
                MessageBox.Show("O Preenchimento dos Campos está Incorreto!\n", ex.Message, MessageBoxButtons.OK);
                }

                finally
                {

                //VERIFICA SE A CONEXÃO ESTÁ ABERTA
                if (conn != null)
                {

                //SE ESTIVER ELA É FECHADA
                conn.Close();
                }
                }

                //SE TUDO FOR PREENCHIDO CORRETAMENTE É EXIBIDA A MENSAGEM A BAIXO
                if (x == 2)
                {
                MessageBox.Show("Cliente Cadastrado com Sucesso!");

                //LOGO, TODOS OS CAMPOS SE TORNAM VAZIOS
                textBox27.Text = null;
                maskedTextBox2.Text = null;
                textBox8.Text = null;
                maskedTextBox1.Text = null;
                textBox10.Text = null;
                textBox11.Text = null;
                textBox12.Text = null;
                textBox20.Text = null;
                textBox21.Text = null;
                maskedTextBox1.Text = null;
                textBox26.Text = null;


                }


        }
        /*CADASTRAR CLIENTE
        private void button5_Click(object sender, EventArgs e)
        {
            CLIENTEMODEL  cliente= new CLIENTEMODEL();
            try{

            cliente.Nome= Convert.ToString(textBox12.Text);//CAMPO NOME
            cliente.Identidade= Convert.ToString(maskedTextBox2.Text);//CAMPO IDENTIDADE
            cliente.CPF= Convert.ToString(maskedTextBox1.Text);//CAMPO CPF
            cliente.Telefone= Convert.ToString(maskedTextBox3.Text);//CAMPO TELEFONE
            cliente.Celular =Convert.ToString(textBox20.Text);//CAMPO CELULAR
            cliente.Email=Convert.ToString(textBox26.Text);//CAMPO EMAIL
            cliente.Rua=Convert.ToString(textBox10.Text);//CAMPO RUA
            cliente.Bairro= Convert.ToString(textBox9.Text);//CAMPO BAIRRO
            cliente.Numero=Convert.ToString(textBox21.Text);//CAMPO NUMERO
            cliente.Cidade=Convert.ToString(textBox8.Text);//CAMPO CIDADE 
            cliente.Cep=Convert.ToString(textBox27.Text);//CAMPO CEP

            CLIENTEBLL.Inserir(cliente);
            
            MessageBox.Show("Cadastro efetuado com sucesso");
        }
        catch(Exception erro)
        {
            
            MessageBox.Show( "Erro ao inserir Cliente, favor contactar o suporte." + "[" + erro.Message + "]");
        }        
        }

*/

        private void maskedTextBox8_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
           
        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Excluir_Medicamento abrir = new Excluir_Medicamento();
            abrir.Show();
        }
        
        //CADASTRAR FORNECEDOR
        private void button6_Click(object sender, EventArgs e)
        {

            int x = 0, xx = 0;
            //STRING DE CONEXÃO COM O BANCO
            string strConn = "Persist Security Info=False; server=localhost; database=regougar; uid=root; pwd=admin";

            MySqlConnection conn = null;
            conn = new MySqlConnection(strConn);

            string query = "INSERT INTO fornecedor(Nome,Telefone,Celular,Email,CNPJ,Rua,Bairro,Numero,Cidade,Cep)values(@Nome,@Telefone,@Celular,@Email,@CNPJ,@Rua,@Bairro,@Numero,@Cidade,@Cep)";
            try
            {

                if (conn.State == ConnectionState.Closed)
                {

                    conn.Open();
                }

                MySqlCommand cmd = new MySqlCommand(query, conn);


                cmd.Parameters.AddWithValue("@Nome", Convert.ToString(textBox24.Text));
                cmd.Parameters.AddWithValue("@Telefone", Convert.ToString(maskedTextBox3.Text));
                cmd.Parameters.AddWithValue("@Celular", Convert.ToString(textBox14.Text));
                cmd.Parameters.AddWithValue("@Email", Convert.ToString(textBox23.Text));
                cmd.Parameters.AddWithValue("@CNPJ", Convert.ToString(textBox15.Text));
                cmd.Parameters.AddWithValue("@Rua", Convert.ToString(textBox22.Text));
                cmd.Parameters.AddWithValue("@Bairro", Convert.ToString(textBox18.Text));
                cmd.Parameters.AddWithValue("@Numero", Convert.ToString(textBox13.Text));
                cmd.Parameters.AddWithValue("@Cidade", Convert.ToString(textBox17.Text));
                cmd.Parameters.AddWithValue("@Cep", Convert.ToString(textBox25.Text));


                if (textBox24.Text == "" || textBox22.Text == "" || textBox18.Text == "" || textBox13.Text == "" || textBox17.Text == "")
                {
                    xx = 1;
                    x = 1;
                }

                while (xx == 1)
                {
                    MessageBox.Show("Digite todas as Informações!");
                    xx = 0;
                }

                if (x == 0)
                {


                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Fornecedor Incluido com Sucesso!");
                    xx = 2;
                }


            }

            catch (MySqlException ex)
            {
                x++;
                MessageBox.Show("O Preenchimento dos Campos está Incorreto!\n", ex.Message, MessageBoxButtons.OK);

            }

            finally
            {


                if (conn != null)
                {

                    conn.Close();

                }

            }

            if (xx == 2)
            {
              

                textBox13.Text = null;
                textBox14.Text = null;
                textBox15.Text = null;
               maskedTextBox3.Text = null;
                textBox17.Text = null;
                textBox18.Text = null;
                maskedTextBox1 .Text = null;
                textBox22.Text = null;
                textBox23.Text = null;
                textBox24.Text = null;
                textBox25.Text = null;


            }

        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected_1(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
