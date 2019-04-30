                //BIBLIOTECA
                using System;
                using System.Collections.Generic;
                using System.ComponentModel;
                using System.Data;
                using MySql.Data.MySqlClient;
                using System.Data.SqlClient;
                using System.Drawing;
                using System.Linq;
                using System.Text;
                using System.Windows.Forms;

                namespace Sistema_Hebe_Halsa
                {
                public partial class Acesso : Form
                {
                public Acesso()
                {
                InitializeComponent();
                }

                //INSERÇÃO DE USUÁRIO
                private void button2_Click(object sender, EventArgs e)
                {

                //DECLARAÇÃO DE VARIÁVESI
                int x = 0, y = 0, w = 0, ww = 0;

                //STRING DE CONEXÃO COM O BANCO
                string strConn = "Persist Security Info=False; server=localhost; database=regougar; uid=root; pwd=admin";

                //ATRIBUINDO NULO AOS OBJETOS
                label4.Text = null;
                label3.Text = null;
                label11.Text = null;
                MySqlConnection conn = null;

                //ATRIBUINDO A STRING DE CONEXÃO A UMA INSTANCIA DO OBJETO MYSQLCONNECTION
                conn = new MySqlConnection(strConn);
                
                //TRATADOR DE ERRO
                try
                {

                //PASSANDO OS VALORES A SEREM INSERIDOS NO BANCO
                string query = "INSERT INTO login(Nome,login,senha)values(@Nome,@login,@senha)";

                //PASSANDO A STRING DE CONEXÃO E A QUERY PARA INSERÇÃO DE DADOS NO BANCO
                MySqlCommand cmd = new MySqlCommand(query, conn);

                //RECEBENDO OS VALORES NECESSÁRIOS PARA IDENTIFICAÇÃO DO USUÁRIO
                cmd.Parameters.AddWithValue("@Nome", Convert.ToString(textBox3.Text));
                cmd.Parameters.AddWithValue("@login", Convert.ToString(textBox4.Text));

                //VERIFICA SE OS VALORES ESTÃO VAZIOS
                if (textBox3.Text == "" && textBox4.Text == "" ||textBox3.Text=="" || textBox4.Text=="")
                {
                w = 1;
                ww = 1;
                }

                //VERIFICA SE O VALOR ESTA VAZIO
                cmd.Parameters.AddWithValue("@senha", Convert.ToString(textBox5.Text));

                //NÃO SERÁ VERIFICADO A EXISTENCIA DO USUÁRIO ENQUANTO OS VALORES ESTIVEREM VAZIOS
                while (textBox5.Text == ""&& w==1 || textBox5.Text!="" && w==1)
                {
                //MENSAGEM DE ADVERTÊNCIA
                MessageBox.Show("Digite todas as Informações!");
                w = 0;
                }

                //CRIANDO UMA NOVA INSTANCIA DO OBJETO LOGIN();
                login acesso = new login();

                //NÃO É POSSIVEL ARMAZENAR UM USUÁRIO COM O MESMO LOGIN
                while (acesso.noRepeat(textBox4.Text) == "loginExiste")
                {
                //MENSAGEM DE ADVERTENCIA
                MessageBox.Show("Login Já existe!\n Use outro login!");

                //CASO JÁ EXISTA, OS VALORES TORNAM SE VAZIOS
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                //O CURSOR TORNA-SE FOCADO 
                textBox4.Focus();
                }

                string get;
                get = Convert.ToString(textBox6.Text);

                //SE AS SENHAS DIGITAS FOREM VAZIAS
                if(textBox5.Text=="" && textBox6.Text==""){

                //SERÁ MOSTRADO A MENSAGEM INVÁLIDO
                label3.Text="Inválido";
                }

                //SE AS SENHAS FOREM DIGITADAS CORRETAMENTE
                if (textBox5.Text == get &&(textBox5.Text!="")&&ww!=1)
                {

                //SERÁ MOSTRADO A MENSAGEM SENHAS IGUAIS
                label3.Text ="Senhas\nIguais!";

                x = 2;
                //ABRE A CONEXÃO COM O BANCO
                conn.Open();

                //FAZ A OPERAÇÃO DE INSERÇÃO DE DADOS NO BANCO
                cmd.ExecuteNonQuery();

                //FECHA A CONEXÃO
                conn.Close();
                }

                //SE AS SENHAS FOREM DIFERENTES
                else if(textBox5.Text != get)
                {

                //SERÁ MOSTRADA A MENSAGEM SENHAS DIFERENTES
                label3.Text = "Senhas\nDiferentes!"; 

                //O VALOR DA SENHA SE TORNA VAZIIO
                textBox6.Text = null;
                y = 2;
                }

                //SE OS DADOS REQUERIDOS FORAM DIGITADOS CORRETAMENTE É EXIBIDA A MENSAGEM:
                if (x == 2)
                {

                //VOCE POSSEU ACESSO AO SISTEMA, CASO ESTEJA DE ACORDO
                MessageBox.Show(textBox3.Text+",\nVocê possue Acesso ao Sistema!","ACESSO PERMITIDO");

                //OS CAMPOS SE TORNAM VAZIOS, DEPOIS DA INSERÇAO
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";

                //OCORRE UM ATRASO DE MILÉSIMOS PARA OS CAMPOS SEREM CONVALIDADOS
                System.Threading.Thread.Sleep(100);
                x = 0;
                }

                //FIM DO TRATADOR DE ERRO
                }

                //CASO TENHA ALGUM PROBLEMA DENTRO DO ESCOPO DO TRY, É EXIBIDA UMA MENSAGEM NESTE
                //TRECHO DO SISTEMA
                catch (MySqlException ex)
                {
                MessageBox.Show("O Preenchimento dos Campos está Incorreto!\n",ex.Message,MessageBoxButtons.OK);
                }
                }

                private void textBox3_TextChanged(object sender, EventArgs e)
                {

                }

                private void textBox4_TextChanged(object sender, EventArgs e)
                {

                }

                private void textBox6_TextChanged(object sender, EventArgs e)
                {

                }

                private void Acesso_Load(object sender, EventArgs e)
                {

                }

                private void textBox5_TextChanged(object sender, EventArgs e)
                {

                }

                private void label3_Click(object sender, EventArgs e)
                {

                }

                //FECHA A TELA
                private void button1_Click(object sender, EventArgs e)
                {
                Close();
                }

                //EXCLUSÃO DE USUÁRIO
                private void button3_Click(object sender, EventArgs e)
                {
                int xx = 0;

                //TRATADOR DE ERRO
                try
                {

                //PASSANDO A STRING DE CONEXÃO PARA A INSTANCIA DO OBJETO MYSQLCONNECTION
                MySqlConnection conn = new MySqlConnection("Persist Security Info=False; server=localhost; database=regougar; uid=root; pwd=admin");

                //VERIFICANDO SE LOGIN EXISTE
                string query = "select Nome,senha from login where Nome='" +textBox7.Text+ "' and senha='" +textBox8.Text+"'";
                  
                //QUERY PARA DELETAR O USUÁRIO DESEJADO POR NOME E SENHA
                string query1 = "delete from login where Nome='" + textBox7.Text + "' and senha='" + textBox8.Text + "'";

                //VERIFICANDO SE USUÁRIO COM O LOGIN EXISTE
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataSet set = new DataSet();
                adapter.Fill(set);

                //SE EXISTIR COUNT SERÁ MAIOR QUE ZERO
                if (set.Tables[0].Rows.Count > 0)
                {

                //É PASSADO A QUERY PARA DELETAR O USUÁRIO, E A CONEXÃO COM O BANCO
                MySqlCommand cmd = new MySqlCommand(query1, conn);
                xx = 1;

                //ABRE A CONEXÃO
                conn.Open();

                //É EXECUTADA A OPERAÇÃO DE EXCLUSÃO DO BANCO 
                cmd.ExecuteNonQuery();

                //FECHA A CONEXÃO
                conn.Close();
                }
                //CASO NÃO EXISTA É EMITIDA A MENSAGEM  A SEGUIR
                else
                MessageBox.Show("Usuário Não existe!", "\n\n");
                }

                //EXIBIÇÃO DE MENSAGEM DE ERRO
                catch (MySqlException ex)
                {
                MessageBox.Show(ex.Message);
                }
                //É EXIBIDA A MENSAGEM DE A BAIXO
                //E OS CAMPOS SE TORNAM VAZIOS
                if(xx==1)
                MessageBox.Show("Usuário Excluído");
                textBox7.Text = "";
                textBox8.Text = "";
                textBox7.Focus();

                }

                private void textBox7_TextChanged(object sender, EventArgs e)
                {

                }

                private void textBox8_TextChanged(object sender, EventArgs e)
                {

                }

                private void label11_Click(object sender, EventArgs e)
                {

                }

                private void label4_Click(object sender, EventArgs e)
                {

                }
                }
                }
