using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace WCF_Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceChat : IServiceChat
    {
        List<ServerUser> users = new List<ServerUser>();
        public int Connect(string name, int id)
        {
            var xe = users.FirstOrDefault(x => x.ID == id);
            if (xe != null)
            {
                return 0;
            }
            ServerUser user = new ServerUser()
            {
                ID = id,
                // ID = nextId,
                Username = name,
                OperationContext = OperationContext.Current
            };

            SendMsg(" " + user.Username + "(" + user.ID + ") подключился", 0);
            users.Add(user);
            return user.ID;
        }

        public void Disconnect(int id)
        {
            var user = users.FirstOrDefault(x => x.ID == id);
            if (user != null)
            {
                users.Remove(user);
                SendMsg(" " + user.Username + "(" + user.ID + ") отключился", 0);
            }
        }

        public void SendMsg(string msg, int id)
        {
            string[] us = new string[0];
            if (users.Count != 0)
            {
                us = new string[users.Count];
                int i = 0;
                foreach (var item in users)
                {
                    us[i] = item.ID.ToString() + ": " + item.Username;
                    i++;
                }
            }
            foreach (var item in users)
            {
                string answer = DateTime.Now.ToShortTimeString();

                var user = users.FirstOrDefault(x => x.ID == id);
                if (user != null)
                {
                    answer += ", " + user.Username + " : ";
                }
                answer += msg;

                item.OperationContext.GetCallbackChannel<IServerChatCallback>().MsgCallBack(answer, us);
            }
        }
    }
}
