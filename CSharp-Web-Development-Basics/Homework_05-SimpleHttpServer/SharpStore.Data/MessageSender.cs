using SharpStore.Models;
using System;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace SharpStore.Data
{
    public static class MessageSender
    {
        private static SharpStoreContext context;

        public static void AddToDatabase(string url, string content)
        {
            context = Data.Context;

            string[] tokens = WebUtility.UrlDecode(content).Split('&');

            if (Regex.IsMatch(url, @"^/contacts.html"))
            {
                if (tokens.Length < 3)
                {
                    throw new ArgumentException();
                }

                var message = new Message();
                string senderEmail = tokens[0].Split('=')[1];
                User sender = context.Users.FirstOrDefault(u => u.Email == senderEmail);
                string subjectName = tokens[1].Split('=')[1];
                User subject = context.Users.FirstOrDefault(u => u.Username == subjectName);
                if (sender == null || subject == null)
                {
                    Console.WriteLine("Invalid email address or subject username.");
                    throw new ArgumentNullException();
                }

                message.Sender = sender;
                message.Subject = subject;
                message.MessageContent = tokens[2].Split('=')[1];
                context.Messages.Add(message);
               
                context.SaveChanges();
            }
        }
    }
}
