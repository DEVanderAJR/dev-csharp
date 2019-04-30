using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;


namespace Sistema_Hebe_Halsa
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            //INSTANCIA A TELA DE LOGIN
            login login = new login();
            login.ShowDialog();

            //INSTANCIA A LOGO HH
            vieww view = new vieww();
            view.Show();

            //ATRASA O PROCESSO DOIS SEGUNDOS NA LOGO
            System.Threading.Thread.Sleep(2000);
            view.Close();          
            
            InitializeComponent();
            
            //VERIFICAÇÃO DE QUAL USUARIO ENTRA NO SISTEMA
            if (login.Name1 != "admin")
            {
            button3.Enabled =  false;

            //STRING DE  CONEXÃO 
            string StrConn = "Persist Security Info=False; server=localhost; database=regougar; uid=root; pwd=admin";
           
             // PASSANDO A STRING DE CONEXÃO
            MySqlConnection conn = new MySqlConnection(StrConn);

            //QUERY DE CONSULTA NO BANCO
            string query= "select Nome from login where login="+login.Name1+"";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            DataSet set=new DataSet();          
            }}

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void atualizaHora(object sender, EventArgs e)
        {
        //    DateTime tempo = System.DateTime.Now;
        //    this.hora.Text = "Hora Atual:  " + tempo.Hour + ":" + tempo.Minute + ":" + tempo.Second;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Timer tempo = new Timer();
            //tempo.Interval = 1000;
            //EventHandler evento = new EventHandler(atualizaHora);
            //tempo.Tick += evento; 
            //tempo.Start();

            login acess = new login();

           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        //ABRE A TELA DE ESTOQUE
        public void button1_Click(object sender, EventArgs e)
        {
                      
            Form2 novo = new Form2();
            novo.Show();          
        }

        private void splitContainer1_Panel2_Paint_1(object sender, PaintEventArgs e)
        { 
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
         
        }

        private void splitContainer1_Panel2_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        //ABRE A TELA DE CADASTROS
        private void button2_Click(object sender, EventArgs e)
        {
          cadastros abrir = new cadastros();
            abrir.Show();
        }

        //ENCERRA O SISTEMA
        private void button5_Click(object sender, EventArgs e)
        {
            Close();

            //ABRE A LOGO HH
            vieww view = new vieww();
            view.Show();

            //ATRASA A PLICAÇÃO
            System.Threading.Thread.Sleep(2000);
            view.Close();
            Dispose();
        }
        //LOGO HH
        private void button7_Click(object sender, EventArgs e)
        {
            vieww view = new vieww();
           
            view.Show();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        //ABRE A TELA DE ACESSO
        private void button3_Click_1(object sender, EventArgs e)
        {
            Acesso abrir = new Acesso();
            abrir.Show();

        }

        private void hora_Click(object sender, EventArgs e)
        {

        }
    }
}
