
namespace Server
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ServiceModel;
    using System.Reflection;

    public delegate void ListOfElder(List<string> ElderNames, object sender);

    public delegate void ListOfVolunteer(List<string> VolunteerNames, object sender);

    [ServiceContract(CallbackContract = typeof(IReceiveChatService))]
    public interface ISendChatService                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         
    {
        [OperationContract(IsOneWay = true)]
        void SendMessage(string msg, string sender, string receiver);
        [OperationContract(IsOneWay = true)]
        void StartChat(string msg, string sender, string receiver);

        [OperationContract(IsOneWay = true)]
        void StartVolunteer(string Name);
        [OperationContract(IsOneWay = true)]
        void StopVolunteer(string Name);
        [OperationContract(IsOneWay = true)]
        void StartElder(string Name);
        [OperationContract(IsOneWay = true)]
        void StopElder(string Name);

    }

    public interface IReceiveChatService
    {
        [OperationContract(IsOneWay = true)]
        void ReceiveMessage(string msg, string receiver);
        [OperationContract(IsOneWay = true)]
        void NewChat(string msg, string sender, string receiver);

        [OperationContract(IsOneWay = true)]
        void SendVolunteerNames(List<string> names);
        [OperationContract(IsOneWay = true)]
        void SendElderNames(List<string> names);
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ChatService : ISendChatService 
    {
        Dictionary<string, IReceiveChatService> ElderNames = new Dictionary<string, IReceiveChatService>();
        Dictionary<string, IReceiveChatService> VolunteerNames = new Dictionary<string, IReceiveChatService>();
        
        public static event ListOfElder ChatListOfElderNames;

        public static event ListOfVolunteer ChatListOfVolunteerNames;

        IReceiveChatService callback = null;

        public ChatService() { }

        public void Close()
        {
            this.callback = null;
            this.ElderNames.Clear();
            this.VolunteerNames.Clear();
        }

        public void StartVolunteer(string Name)
        {
            try
            {
                if (!this.VolunteerNames.ContainsKey(Name))
                {
                    this.callback = OperationContext.Current.GetCallbackChannel<IReceiveChatService>();
                    this.AddVolunteerUser(Name, this.callback);
                    this.SendElderNames();
                    this.SendVolunteerNames();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void StartElder(string Name)
        {
            try
            {
                if (!this.ElderNames.ContainsKey(Name))
                {
                    this.callback = OperationContext.Current.GetCallbackChannel<IReceiveChatService>();
                    this.AddElderUser(Name, this.callback);
                    this.SendElderNames();
                    this.SendVolunteerNames();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void StopVolunteer(string Name)
        {
            try
            {
                if (this.VolunteerNames.ContainsKey(Name))
                {
                    this.VolunteerNames.Remove(Name);
                    this.SendVolunteerNames();
                    this.SendElderNames();
                 }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void StopElder(string Name)
        {
            try
            {
                if (this.ElderNames.ContainsKey(Name))
                {
                    this.ElderNames.Remove(Name);
                    this.SendElderNames();
                    this.SendVolunteerNames();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void SendVolunteerNames()
        {
            foreach (KeyValuePair<string, IReceiveChatService> name in this.ElderNames)
            {
                IReceiveChatService proxy = name.Value;
                proxy.SendVolunteerNames(this.VolunteerNames.Keys.ToList());
            }

            if (ChatListOfVolunteerNames != null)
                ChatListOfVolunteerNames(this.VolunteerNames.Keys.ToList(), this);
        }

        void SendElderNames()
        {
            foreach (KeyValuePair<string, IReceiveChatService> name in this.VolunteerNames)
            {
                IReceiveChatService proxy = name.Value;
                proxy.SendElderNames(this.ElderNames.Keys.ToList());
            }

            if (ChatListOfElderNames != null)
                ChatListOfElderNames(this.ElderNames.Keys.ToList(), this);
        }

        void ISendChatService.SendMessage(string msg, string sender, string receiver)
        {
            if (this.ElderNames.ContainsKey(receiver))
            {
                this.callback = this.ElderNames[receiver];
                this.callback.ReceiveMessage(msg, sender);
           }

            if (this.VolunteerNames.ContainsKey(receiver))
            {
                this.callback = this.VolunteerNames[receiver];
                this.callback.ReceiveMessage(msg, sender);
            }
        }

        void ISendChatService.StartChat(string msg, string sender, string receiver)
        {
            if (this.ElderNames.ContainsKey(receiver))
            {
                this.callback = this.ElderNames[receiver];
                this.callback.NewChat(msg, sender, receiver);
            }

            if (this.VolunteerNames.ContainsKey(receiver))
            {
                this.callback = this.VolunteerNames[receiver];
                this.callback.NewChat(msg, sender, receiver);
            }
        }

        private void AddElderUser(string name, IReceiveChatService callback)
        {
            this.ElderNames.Add(name, callback);
            if (ChatListOfElderNames != null)
                ChatListOfElderNames(this.ElderNames.Keys.ToList(), this);
            
        }
        private void AddVolunteerUser(string name, IReceiveChatService callback)
        {
            this.VolunteerNames.Add(name, callback);
            if (ChatListOfVolunteerNames != null)
                ChatListOfVolunteerNames(this.VolunteerNames.Keys.ToList(), this);

        }
    }
}
