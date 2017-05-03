using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace SMTPTrafficGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
           
            HostFactory.Run(x =>                                 
            {
                x.Service<MailGenerationService>(s =>                       
                {
                    s.ConstructUsing(name => new MailGenerationService());    
                    s.WhenStarted(tc => tc.Start());             
                    s.WhenStopped(tc => tc.Stop());               
                });
                x.RunAsLocalSystem();                           

                x.SetDescription("Cyber Range Mail Generation Service");        
                x.SetDisplayName("CyberRange SMTP Generator");                       
                x.SetServiceName("CyberRange.SMTPTrafficGenerator");                       
            });
        }
    }
}
