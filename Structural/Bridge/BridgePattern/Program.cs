using System;

namespace BridgePattern
{ //have 3 social media platforms but want to message between all
    class Program
    {
        public abstract class Message //abstraction class
        {
            public ISender Sender { get; set; }
            public string Subject { get; set; }
            public string Body { get; set; }
            public abstract void Send();
        }

        public class SystemMessage : Message //refined abstraction
        {
            public override void Send()
            {
                Sender.SendMesage(Subject, Body);
            }
        }

        public class UserMessage : Message
        {
            public string UserComments { get; set; }
            public override void Send()
            {
                string fullBody = string.Format("{0} - User Comments: {1}", Body, UserComments);
                Sender.SendMessage(Subject, fullBody);
            }
        }

        public interface ISender //bridge
        {
            void SendMessage(string subject, string body);
        }

        //concrete classes that implements this bridge
        public class FacebookSender : ISender
        {
            public void SendMessage(string subject, string body)
            {
                Console.WriteLine("Facebook - {0} - {1}", subject, body);
            }
        }

        public class TwitterSender : ISender
        {
            public void SendMessage(string subject, string body)
            {
                Console.WriteLine("Twitter - {0} - {1}", subject, body);
            }
        }

        public class InstagramSender : ISender
        {
            public void SendMessage(string subject, string body)
            {
                Console.WriteLine("Instagram - {0} - {1}", subject, body);
            }
        }

        static void Main(string[] args)
        {
            ISender facbookSender = new FacebookSender();
            ISender twitterSender = new TwitterSender();
            ISender instagramSender = new InstagramSender();

            Message message = new SystemMessage();
            message.Subject = "Test Message";
            message.Body = "Hello World";

            message.Sender = FacebookSender;
            message.Send();

            message.Sender = TwitterSender;
            message.Send();

            message.Sender = InstagramSender;
            message.Send();

            UserMessage userMessage = new UserMessage();
            userMessage.Subject = "Test Message";
            userMessage.Body = "Hello World";
            userMessage.UserComments = "Hi";

            userMessage.Sender = FacebookSender;
            userMessage.Send();
            Console.ReadKey();
        }
    }
}
