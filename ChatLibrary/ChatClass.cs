using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Reflection;


namespace Server
{


    public delegate void ListOfElder(List<string> ElderNames, object sender);

    public delegate void ListOfVolunteer(List<string> VolunteerNames, object sender);

    [ServiceContract(CallbackContract = typeof(IReceiveChatService))]
    public interface ISendChatService                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         
    {
        [OperationContract(IsOneWay = true)]
        void SendMessage(string msg, string sender, string receiver);
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
        void ReceiveMessage(string msg,string receiver);
        [OperationContract(IsOneWay = true)]
        void SendVolunteerNames(List<string> names);
        [OperationContract(IsOneWay = true)]
        void SendElderNames(List<string> names);
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ChatService : ISendChatService 
    {
        Dictionary<string, IReceiveChatService> ElderNames = new Dictionary<string, IReceiveChatService>();
        Dictionary<string, IReceiveChatService> VolunteerNames = new Dictionary<string,IReceiveChatService>();
        
        public static event ListOfElder ChatListOfElderNames;

        public static event ListOfVolunteer ChatListOfVolunteerNames;

        IReceiveChatService callback = null;

        public ChatService() { }

        public void Close()
        {
            callback = null;
            ElderNames.Clear();
            VolunteerNames.Clear();
        }

        public void StartVolunteer(string Name)
        {
            try
            {
                if (!VolunteerNames.ContainsKey(Name))
                {
                    callback = OperationContext.Current.GetCallbackChannel<IReceiveChatService>();
                    AddVolunteerUser(Name, callback);
                    SendElderNames();
                    SendVolunteerNames();
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
                if (!ElderNames.ContainsKey(Name))
                {
                    callback = OperationContext.Current.GetCallbackChannel<IReceiveChatService>();
                    AddElderUser(Name, callback);
                    SendElderNames();
                    SendVolunteerNames();

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
                if (VolunteerNames.ContainsKey(Name))
                {
                    VolunteerNames.Remove(Name);
                    SendVolunteerNames();
                    SendElderNames();
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
                if (ElderNames.ContainsKey(Name))
                {
                    ElderNames.Remove(Name);
                    SendElderNames();
                    SendVolunteerNames();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void SendVolunteerNames()
        {
             foreach (KeyValuePair<string, IReceiveChatService> name in ElderNames)
            {
                IReceiveChatService proxy = name.Value;
                proxy.SendVolunteerNames(VolunteerNames.Keys.ToList());
            }

            if (ChatListOfVolunteerNames != null)
                ChatListOfVolunteerNames(VolunteerNames.Keys.ToList(), this);
        }

        void SendElderNames()
        {
            foreach (KeyValuePair<string, IReceiveChatService> name in VolunteerNames)
            {
                IReceiveChatService proxy = name.Value;
                proxy.SendElderNames(ElderNames.Keys.ToList());
            }

            if (ChatListOfElderNames != null)
                ChatListOfElderNames(ElderNames.Keys.ToList(), this);
        }

        void ISendChatService.SendMessage(string msg,string sender, string receiver)
        {
            if (ElderNames.ContainsKey(receiver))
            {
                callback = ElderNames[receiver];
                callback.ReceiveMessage(msg, sender);
           }

            if (VolunteerNames.ContainsKey(receiver))
            {
                callback = VolunteerNames[receiver];
                callback.ReceiveMessage(msg, sender);
            }
        }

        private void AddElderUser(string name,IReceiveChatService callback)
        {
            ElderNames.Add(name, callback);
            if (ChatListOfElderNames !=null)
                ChatListOfElderNames(ElderNames.Keys.ToList(), this);
            
        }
        private void AddVolunteerUser(string name, IReceiveChatService callback)
        {
            VolunteerNames.Add(name, callback);
            if (ChatListOfVolunteerNames != null)
                ChatListOfVolunteerNames(VolunteerNames.Keys.ToList(), this);

        }
    }
}
