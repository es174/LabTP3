﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChatClient.ServiceLogin {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceLogin.IServiceLogin")]
    public interface IServiceLogin {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceLogin/Connect", ReplyAction="http://tempuri.org/IServiceLogin/ConnectResponse")]
        int Connect(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceLogin/Connect", ReplyAction="http://tempuri.org/IServiceLogin/ConnectResponse")]
        System.Threading.Tasks.Task<int> ConnectAsync(string username, string password);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceLoginChannel : ChatClient.ServiceLogin.IServiceLogin, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceLoginClient : System.ServiceModel.ClientBase<ChatClient.ServiceLogin.IServiceLogin>, ChatClient.ServiceLogin.IServiceLogin {
        
        public ServiceLoginClient() {
        }
        
        public ServiceLoginClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceLoginClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceLoginClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceLoginClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int Connect(string username, string password) {
            return base.Channel.Connect(username, password);
        }
        
        public System.Threading.Tasks.Task<int> ConnectAsync(string username, string password) {
            return base.Channel.ConnectAsync(username, password);
        }
    }
}
