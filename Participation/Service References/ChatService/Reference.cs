﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Participation.ChatSysteem.ChatService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName = "ChatService.ISendChatService", CallbackContract = typeof(Participation.ChatSysteem.ChatService.ISendChatServiceCallback))]
    public interface ISendChatService {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ISendChatService/SendMessage")]
        void SendMessage(string msg, string sender, string receiver);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ISendChatService/StartVolunteer")]
        void StartVolunteer(string Name);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ISendChatService/StopVolunteer")]
        void StopVolunteer(string Name);

        [System.ServiceModel.OperationContractAttribute(IsOneWay = true, Action = "http://tempuri.org/ISendChatService/StartElder")]
        void StartElder(string Name);

        [System.ServiceModel.OperationContractAttribute(IsOneWay = true, Action = "http://tempuri.org/ISendChatService/StopElder")]
        void StopElder(string Name);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISendChatServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ISendChatService/ReceiveMessage")]
        void ReceiveMessage(string msg, string receiver);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ISendChatService/SendVolunteerNames")]
        void SendVolunteerNames(string[] names);

        [System.ServiceModel.OperationContractAttribute(IsOneWay = true, Action = "http://tempuri.org/ISendChatService/SendElderNames")]
        void SendElderNames(string[] names);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISendChatServiceChannel : Participation.ChatSysteem.ChatService.ISendChatService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SendChatServiceClient : System.ServiceModel.DuplexClientBase<Participation.ChatSysteem.ChatService.ISendChatService>, Participation.ChatSysteem.ChatService.ISendChatService
    {
        
        public SendChatServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public SendChatServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public SendChatServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public SendChatServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public SendChatServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void SendMessage(string msg, string sender, string receiver) {
            base.Channel.SendMessage(msg, sender, receiver);
        }

        public void StartVolunteer(string Name)
        {
            base.Channel.StartVolunteer(Name);
        }

        public void StopVolunteer(string Name)
        {
            base.Channel.StopVolunteer(Name);
        }
        
        public void StartElder(string Name) {
            base.Channel.StartElder(Name);
        }
        
        public void StopElder(string Name) {
            base.Channel.StopElder(Name);
        }
    }
}