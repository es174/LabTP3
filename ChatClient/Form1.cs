using ChatClient.ServiceChat;
using System;
using System.Windows.Forms;

namespace ChatClient
{

    public partial class Form1 : Form, IServiceChatCallback
    {
        ServiceChatClient client;
        bool isConnected = false;
        int id;
        Login login;
        string username;
        public Form1(int id, string username, Login login)
        {   
            
            InitializeComponent();
            this.login = login;
            this.id = id;
            this.username = username;
            this.Text = username + "("+id+")";
            ConnectUser();

        }
        void ConnectUser()
        {
            if (!isConnected)
            {
                client = new ServiceChatClient(new System.ServiceModel.InstanceContext(this));
                id = client.Connect(username, id);
                if (id != 0)
                    isConnected = true;
                else
                {
                    MessageBox.Show("Пользователь уже на сервере");
                    login.Close();
                    
                }
               }
        }

        void DisconnectUser()
        {
            if (isConnected)
            {
                client.Disconnect(id);
                isConnected = false;
            }
        }
        public void MsgCallBack(string msg, string[] users)
        {
            listBox2.Items.Clear();
            listBox1.Items.Add(msg);
            foreach (string user in users)
            {
                listBox2.Items.Add(user);            
            }

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            DisconnectUser();
            // Close();
            login.Close();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                client.SendMsg(textBox2.Text, id);
                textBox2.Text = "";

            }
        }
    }
}
