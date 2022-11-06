using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace WCF_Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceChat : IServiceChat
    {
        int nextId=1;
        List<ServerUser> users = new List<ServerUser>();
        public int Connect(string name, int id)
        {   
            ServerUser user = new ServerUser()
            {
               // ID = id,
                ID = nextId,
                Username = name,
                OperationContext = OperationContext.Current
            };
            nextId++;      
            SendMsg(" " + user.Username + " подключился", 0);
            users.Add(user);
            return user.ID;
        }

        public void Disconnect(int id)
        {
            var user = users.FirstOrDefault(x => x.ID == id);
            if (user != null)
            {
                users.Remove(user);
                SendMsg(" " + user.Username + " отключился", 0);
            }
        }

        public void SendMsg(string msg, int id)
        {
            foreach (var item in users)
            {
                string answer = DateTime.Now.ToShortTimeString();

                var user = users.FirstOrDefault(x => x.ID == id);
                if (user != null)
                {
                    answer += " : " + user.Username + " ";
                }
                answer += msg;

                item.OperationContext.GetCallbackChannel<IServerChatCallback>().MsgCallBack(answer);
            }
        }
    }
}
