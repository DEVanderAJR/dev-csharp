            //BIBLIOTECA
            using System.Threading;
            using System.Data.Odbc;
            using System.Collections.Generic;
            using System.ComponentModel;
            using System.Data.SqlClient;
            using System.Data;
            using System.Runtime.CompilerServices;
            using MySql.Data.MySqlClient;
            using System.Drawing;
            using System.Linq;
            using System.Text;
            using System.Windows.Forms.PropertyGridInternal;
            using System.Data.Sql;
            using MySql.Data.MySqlClient.Properties;
            using MySql.Data.Types;
            using System.Data.ProviderBase;
            using System.Data.OleDb;
            using System.Windows.Forms;
            using System.IO.Ports;
            using System.Diagnostics;
            using System.Configuration;
            using System.Collections;
            using System;
            using System.IO;


            namespace Sistema_Hebe_Halsa
            {
            public partial class login : Form
            {
            bool fechar;
            public bool comp ;
            public string name;

            //DECLARAÇÃO DE VARIÁVEIS EM TERMO GLOBAL
            public string Name1
            {
            get { return name; }
            set { name = value; }
            }
            public bool Comp
            {
            get { return comp; }
            set { comp = value; }
            }
            public login()
            {

            InitializeComponent();
            fechar = false;

            }

            private void login_Load(object sender, EventArgs e)
            {            
            }

            //AUTENTICAR USUÁRIO
            private string autenticarUsuario(string login, string senha)
            {

            //string de conexão com o banco de dados
            string StrConn = "Persist Security Info=False; server=localhost; database=regougar; uid=root; pwd=admin";
           
            //PASSANDO A STRING DE CONEXÃO PARA A INSTANCIA DO OBJETO MYSQLCONNECTION
            MySqlConnection conn = new MySqlConnection(StrConn);

            //INSTANCIANDO UM OBJETO DO TIPO DATASET
            DataSet result = new DataSet();

            //QUERY PARA PESQUISA DE USUÁRIO
            string query = "Select login, senha From login  where login='" + login + "' and senha='" + senha + "'";
            string retorno;

            //TRATADOR DE ERROS
            try
            {

            //ABRE A CONEXÃO
            conn.Open();

            //PASSANDO A STRING DE CONEXÃO E A QUERY, COMO PARAMÊTRO PARA A INSTANCIA DO OBJETO MYSQLDATAADAPTER
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);

            //VERIFICA SE O USUÁRIO EXISTE
            adapter.Fill(result);
            if (result.Tables[0].Rows.Count > 0)
            {
            Name1 = login;
            //CASO EXISTA RETORNA 0K
            retorno = "ok";
            }
            //CASAO NÃO RETORNA NO
            else
            retorno = "no";

            //FIM DO TRATADOR DE ERRO
            }
            //CASO TENHA ALGUM ERRO NO TRY, É EXIBIDA UMA MENSAGEM DE ERRO
            catch (MySqlException erro)
            {
            retorno = erro.Message;
            }
            //VERIFICA SE A CONEXÃO AINDA ESTÁ ABERTA
            finally
            {
            //CASO NÃO, ELA É FECHADA
            conn.Close();
            }
            //RETORNA O VALOR DE RETORNO
            return retorno;
            }

            //METODO PARA A VERIFICAÇÃO DE REPETIÇÃO
            public string noRepeat(string login)
            {
            int x = 0;
      
            //STRING DE CONEXÃO
            string Strconn = "Persist Security Info=False; server=localhost; database=regougar; uid=root; pwd=admin";

            //PASSANDO A STRING DE CONEXÃO COMO PARAMETRO PARA A INSTANCIA DO OBJETO MYSQLCONNECTION
            MySqlConnection conn = new MySqlConnection(Strconn);
            
            //VERIFICA SE O USUÁRIO EXISTE
            string query = "Select login,Nome FROM login where login='" + login+ "'";

            //TRATADOR DE ERRO
            try
            { 

            //ABRE A CONEXÃO
            conn.Open();
            DataSet setdata = new DataSet();

            //PASSANDO A STRING DE CONEXÃO E A QUERY, COMO PARAMÊTRO PARA A INSTANCIA DO OBJETO MYSQLDATAADAPTER
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);


            adapter.Fill(setdata);

            //SE AFFECT ROWS FOR MAIOR QUE ZERO, USUÁRIO EXISTE
            if (setdata.Tables[0].Rows.Count>0)
            {
            x = 1;

            //RETORNA A STRING A BAIXO PARA VERIFICAÇÃO
            return "loginExiste";
            }

            //FIM TRY
            }

            //EXIBE MENSAGEM DE ERRO DO ESCOPO TRY
            catch (MySqlException ex)
            {

            MessageBox.Show(ex.Message);
            }

            //VERIFICA SE A CONEXÃO ESTÁ FECHADA
            finally
            {

            //CASO NÃO ELA É FECHADA
            conn.Close();
            }
            //RETORNA ERRO
            return "error";
            }

            //VERIFICAÇÃO DE LOGIN E SENHA
            public void button1_Click(object sender, EventArgs e)
            {

            //PASSAGEM DE PARAMETROS PARA O MÉTODO AUTENTICARUSUÁRIO
            string resultado = autenticarUsuario(textBox1.Text, textBox2.Text);

            //FAÇA ENQUANTO
            do
            {

            //SE O RESULTADO FOR OK
            if (resultado == "ok")
            {

            //A JANELA DE LOGIN É FINALIZADA, E O COMPONENTES RESTANTES DO SISTEMA SÃO INICIALIZADOS
            fechar = true;

            //FECHA JANELA
            Close();
            }

            //CASO O RESULSTADO SEJA NÃO
            else if (resultado == "no")
            {

            //EXIBE A MENSAGEM A BAIXO
            MessageBox.Show("O LOGIN INFORMADO NÃO ESTÁ CADASTRADO NA BASE DE DADOS!");

            //OS CAMPOS SE TORNAM VAZIOS
            textBox1.Text = null;
            textBox2.Text = null;
            textBox1.Focus();
            }

            //CASO ESTEJAM INCORRETOS
            else
            {

            //EXIBE A MENSAGEM DE ERRO A BAIXO
            MessageBox.Show("ERRO AO SE CONECTAR COM O BANCO DE DADOS: \n\nEROOR!" + resultado);

            //OS CAMPOS SE  TORNAM VAZIOS
            textBox1.Text = null;
            textBox2.Text = null;

            }
            //REPITA TODO O PROCESSO, ENQUANTO OS VALORES FOREM NULOS (VAZIOS)
            } while ((textBox1.Text ==null) &&( textBox2.Text== null));
            }

            //SAIR DO SISTEMA
            private void button2_Click(object sender, EventArgs e)
            {


            Environment.Exit(0);
            }

            private void textBox1_TextChanged(object sender, EventArgs e)
            {

            }

            private void textBox2_TextChanged(object sender, EventArgs e)
            {

            }

            //CONDIÇÃO PARA FECHAR TELA
            private void login_FormClosing(object sender, FormClosingEventArgs e)
            {
            if (!fechar)
            e.Cancel = true;
            }

            private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
            {

            }
            }
            }