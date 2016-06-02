// <copyright file="VolunteerSystem.cs" company="S27A">
//      Copyright (c) ICT4Participation. All rights reserved.
// </copyright>
// <author>Sander Koch</author>
namespace Participation.ChatSysteem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;
    using System.Text;
    using Participation.SharedModels;
    using Participation.InlogSysteem.Interfaces;

    /// <summary>
    /// A delegate of a server method, used to get information from the server.
    /// </summary>
    /// <param name="sender">Person who send the message.</param>
    /// <param name="message">The chat message.</param>
    public delegate void ReceivedMessage(string sender, string message);

    /// <summary>
    /// A delegate of a server method, used to get information from the server.
    /// </summary>
    /// <param name="sender">Person who send the message.</param>
    /// <param name="names">The chat usernames.</param>
    public delegate void GotNames(object sender, List<string> names);

    public delegate void NewChat(string msg, string sender, string receiver);

 /// <summary>
 /// A instance of the Receive client class, this class is used to communicatie with the Chat service interface and services to
 /// communicate with the server and other clients.
 /// </summary>
    public class ReceiveClient : ChatService.ISendChatServiceCallback
    {
        /// <summary>
        /// Used in conjunction with the delegate version of this field.
        /// </summary>
        public event ReceivedMessage ReceiveMsg;

        /// <summary>
        /// Used in conjunction with the delegate version of this field.
        /// </summary>
        public event GotNames NewNames;

        public event NewChat ChatStart;

        /// <summary>
        /// A instance of the instance context from service model.
        /// </summary>
        private InstanceContext inst = null;

        /// <summary>
        /// A new null instance of the Chat service called chat client.
        /// </summary>
        private ChatService.SendChatServiceClient chatClient = null;

        /// <summary>
        /// Starts a new ReceiveClient instance and enables chatting. Also checks which kind of user, the user is.
        /// </summary>
        /// <param name="rc">A instance of the Receive client class</param>
        /// <param name="user">A instance of the user object which is currently logged in.</param>
        public void Start(ReceiveClient rc, IUser user)
        {
            this.inst = new InstanceContext(rc);
            this.chatClient = new ChatService.SendChatServiceClient(this.inst);
            if (user.GetType() == typeof(Volunteer))
            {
                this.chatClient.StartVolunteer(user.Name);
            }
            else if (user.GetType() == typeof(Patient))
            {
                this.chatClient.StartElder(user.Name);
            }
            else
            {
                throw new Exception("Couldn't log into chat system.");
            }
        }

        /// <summary>
        /// Sends a message to another user.
        /// </summary>
        /// <param name="msg">The chat message.</param>
        /// <param name="sender">Who sends the message.</param>
        /// <param name="receiver">Who receives the message.</param>
        public void SendMessage(string msg, string sender, string receiver)
        {
            this.chatClient.SendMessage(msg, sender, receiver);
        }

        public void StartChat(string msg, string sender, string receiver)
        {
            this.chatClient.StartChat(msg, sender, receiver);
        }

        /// <summary>
        /// Stops the chat, and removes the user from the list depending on which user.
        /// </summary>
        /// <param name="user">The current logged in user object.</param>
        public void Stop(IUser user)
        {
            if (user.GetType() == typeof(Volunteer))
            {
                this.chatClient.StopVolunteer(user.Name);
            }
            else if (user.GetType() == typeof(Volunteer))
            {
                this.chatClient.StopElder(user.Name);
            }

        }
        
        /// <summary>
        /// When a message is received from the server, this method will be triggered to show the new chat message.
        /// </summary>
        /// <param name="msg">This contains the chat message.</param>
        /// <param name="receiver">Who the message is ment for.</param>
        void ChatService.ISendChatServiceCallback.ReceiveMessage(string msg, string receiver)
        {
            if (this.ReceiveMsg != null)
            {
                this.ReceiveMsg(receiver, msg);
            }
        }

        void ChatService.ISendChatServiceCallback.NewChat(string msg, string sender, string receiver)
        {
            if(this.ChatStart != null)
            {
                this.ChatStart(msg, sender, receiver);
            }
        }

        /// <summary>
        /// Gets all the volunteer usernames who are logged in, gives it to logged in Elders.
        /// </summary>
        /// <param name="names">The list of Volunteer names.</param>
        public void SendVolunteerNames(string[] names)
            {
                if (this.NewNames != null)
                {
                    this.NewNames(this, names.ToList());
                }
        }

        /// <summary>
        /// Gets all the elder usernames who are logged in, gives it to logged in volunteers.
        /// </summary>
        /// <param name="names">The list of elder names.</param>
        public void SendElderNames(string[] names)
        {
            if (this.NewNames != null)
            {
                this.NewNames(this, names.ToList());
            }
        }
    }
}
