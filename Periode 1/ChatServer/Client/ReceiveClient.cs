using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Client
{
    public delegate void ReceivedMessage(string sender, string message);
    public delegate void GotNames(object sender, List<string> names);

    class ReceiveClient : ChatService.ISendChatServiceCallback
    {
        public event ReceivedMessage ReceiveMsg;
        public event GotNames NewNames;

        InstanceContext inst = null;
        ChatService.SendChatServiceClient chatClient = null;

        public void Start(ReceiveClient rc,string name)
        {
            inst = new InstanceContext(rc);
            chatClient = new ChatService.SendChatServiceClient(inst);
            if(name == "Volunteer")
            {
                chatClient.StartVolunteer(name);
            }
            else if(name == "Elder")
            {
                chatClient.StartElder(name);
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

        public void Stop(string name)
        {

            if(name == "Volunteer")
            {
                chatClient.StopVolunteer(name);
            }
            else if(name == "Elder")
            {
                chatClient.StopElder(name);
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
