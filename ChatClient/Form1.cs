using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatClient.ServiceChat;

namespace ChatClient
{
    
    public partial class Form1 : Form,IServiceChatCallback
    {  
        ServiceChatClient client;
        bool isConnected = false;
        int id;
        Login login;
        string username;
        public Form1(int id, string username, Login login)
        {
            this.login = login;
            this.id = id;
            this.username = username;
            InitializeComponent();
            ConnectUser();

        }
        void ConnectUser()
        {
            if(!isConnected)
            {
                client = new ServiceChatClient(new System.ServiceModel.InstanceContext(this));
                id = client.Connect(username,id);
               // button1.Text = "Disconnect";
                isConnected = true;
            }
        }

        void DisconnectUser()
        {
            if (isConnected)
            {
                client.Disconnect(id);
             //   button1.Text = "Connect";
                isConnected = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isConnected)
                DisconnectUser();
            else
                ConnectUser();
                 
        }

        public void MsgCallBack(string msg)
        {
            listBox1.Items.Add(msg);
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
