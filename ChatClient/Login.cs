using ChatClient.ServiceLogin;
using System;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class Login : Form
    {
        ServiceLoginClient client;
        bool isConnected = false;
        int id;
        int msg;

        public Login()
        {
            InitializeComponent();
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

                }
                else
                {
                  
                    Form1 form = new Form1(id, usernameBox.Text, this);
                    form.Show();
                    this.Hide();
                 //   this.Close();
                }
                isConnected = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectUser();

        }
    }
}
