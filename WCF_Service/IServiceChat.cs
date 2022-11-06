using System.Collections.Generic;
using System.ServiceModel;

namespace WCF_Service
{
    [ServiceContract(CallbackContract = typeof(IServerChatCallback))]
    public interface IServiceChat
    {
        [OperationContract]
        int Connect(string name, int id);

        [OperationContract(IsOneWay = true)]
        void Disconnect(int id);

        [OperationContract(IsOneWay = true)]
        void SendMsg(string msg, int id);

    }
    public interface IServerChatCallback
    {
        [OperationContract(IsOneWay = true)]
        void MsgCallBack(string msg, string[] users);
    }
}
