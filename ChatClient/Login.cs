using ChatClient.ServiceLogin;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class Login : Form
    {
        ServiceLoginClient client;
        bool isConnected = false;
        int id;
        int type = 1;

        public Login()
        {
         
            InitializeComponent();
            this.Text = "Вход";
        }

        void ConnectUser()
        {
            if (!isConnected)
            {
                //  client = new ServiceChatClient(new System.ServiceModel.InstanceContext(this));
                client = new ServiceLoginClient();
                id = client.Connect(usernameBox.Text, passwordBox.Text);
                if (id == 0)
                {
                    MessageBox.Show("Введены невереные данные");
                    passwordBox.Text = "";
                }
                else
                {
                  
                    Form1 form = new Form1(id, usernameBox.Text, this);
                    form.Show();
                    this.Hide();
                    isConnected = true;
                 //   this.Close();
                }
              
            }
        }
        void RegistrationUser()
        {
            if (!isConnected)
            {
                //  client = new ServiceChatClient(new System.ServiceModel.InstanceContext(this));
                client = new ServiceLoginClient();
                id = client.Registration(usernameBox.Text, passwordBox.Text);
                if (id == 0)
                {
                    MessageBox.Show("Такой пользователь уже есть");
                    passwordBox.Text = "";
                    usernameBox.Text = "";
                }
                else
                {

                    Form1 form = new Form1(id, usernameBox.Text, this);
                    form.Show();
                    this.Hide();
                isConnected = true;
            }
              
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (type == 1)
            ConnectUser();
                else if (type == 2)
                    RegistrationUser();
            }
            catch { MessageBox.Show("Упс! Что-то с сервером"); }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (type == 1)
            {
                type = 2;
                label4.Visible = true;
                button1.Text = "Зарегистрироваться";
                label3.Text = "У меня уже есть аккаунт.";
                this.BackColor = SystemColors.ControlLightLight;
                button1.BackColor = SystemColors.ControlLightLight;
                this.Text = "Регистрация";
                passwordBox.UseSystemPasswordChar = false;
            }
            else if(type==2)
            {
                button1.BackColor = SystemColors.Control;
                this.BackColor = SystemColors.Control;
                type = 1;
                label4.Visible = false;
                button1.Text = "Войти";
                this.Text = "Вход";
                label3.Text = "Нет аккаунта? Зарегистрируйтесь!";
                passwordBox.UseSystemPasswordChar = true;
            }
        }
    }
}
