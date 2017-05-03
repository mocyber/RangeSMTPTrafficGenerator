using System;
using System.Configuration;
using System.Net.Mail;
using System.Timers;

namespace SMTPTrafficGenerator
{
    internal class MailGenerationService
    {
        readonly Timer _timer;
        SmtpClient client;
        string dFile;
        string[] dict;
        string rFile;
        string[] recipients;

        public MailGenerationService()
        {
            _timer = new Timer(3000) { AutoReset = true };
            _timer.Elapsed += _timer_Tick;

            //bootstrap for cache

            client = new SmtpClient();

            dFile = ConfigurationManager.AppSettings["DictionaryFile"];
            dict = System.IO.File.ReadAllLines(dFile);

            rFile = ConfigurationManager.AppSettings["RecipientFile"];
            recipients = System.IO.File.ReadAllLines(rFile);
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        private void _timer_Tick(object sender, ElapsedEventArgs e)
        {
            MailMessage msg = ConstructMessage();
            Console.WriteLine("Sending Payload: {0}", Newtonsoft.Json.JsonConvert.SerializeObject(msg));
            client.Send(msg);
        }

        MailMessage ConstructMessage()
        {
           

            //Generate Text elements

            RandomText textGenBody = new RandomText(dict);
            textGenBody.AddContentParagraphs(5, 2, 15, 5, 19);
            string body = textGenBody.Content;

            RandomText textGenSubject = new RandomText(dict);
            textGenSubject.AddContentParagraphs(0, 1, 1, 1, 5);
            string subject = textGenSubject.Content;

            //Choose sender & recipient pair from enclave list
            RandomUser userGen = new RandomUser(recipients);
            var userPair = userGen.GetRecipientPair();
            
            MailMessage message = new MailMessage();
            message.Subject = subject;
            message.Body = body;
            message.To.Add(new MailAddress(userPair.Item1));
            message.From = new MailAddress(userPair.Item2);

            return message;

        }
    }
    
    
}