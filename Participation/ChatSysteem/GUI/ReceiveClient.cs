using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Participation.SharedModels;
using Participation.InlogSysteem.Interfaces;

namespace Participation.ChatSysteem
{
    public delegate void ReceivedMessage(string sender, string message);
    public delegate void GotNames(object sender, List<string> names);

    public class ReceiveClient : ChatService.ISendChatServiceCallback
    {
        public event ReceivedMessage ReceiveMsg;
        public event GotNames NewNames;

        InstanceContext inst = null;
        ChatService.SendChatServiceClient chatClient = null;

        public void Start(ReceiveClient rc, IUser user)
        {
            inst = new InstanceContext(rc);
            chatClient = new ChatService.SendChatServiceClient(inst);
            if(user == typeof(Volunteer))
            {
                chatClient.StartVolunteer(user.Name);
            }
            else if(user == typeof(Patient))
            {
                chatClient.StartElder(user.Name);
            }
            else
            {
                throw new Exception("Couldn't log into chat system.");
            }

        }

        public void SendMessage(string msg, string sender,string receiver)
        {
            chatClient.SendMessage(msg, sender,receiver);
        }

        public void Stop(IUser user)
        {

            if(user == typeof(Volunteer))
            {
                chatClient.StopVolunteer(user.Name);
            }
            else if (user == typeof(Volunteer))
            {
                chatClient.StopElder(user.Name);
            }
            else
            {

            }

        }
        
        void ChatService.ISendChatServiceCallback.ReceiveMessage(string msg, string receiver)
        {
            if (ReceiveMsg != null)
                ReceiveMsg(receiver,msg);
        }

        public void SendVolunteerNames(string[] names)
            {
            if (NewNames != null)
                NewNames(this, names.ToList());
        }

        public void SendElderNames(string [] names)
        {
            if (NewNames != null)
                NewNames(this, names.ToList());
        }
    }
}
