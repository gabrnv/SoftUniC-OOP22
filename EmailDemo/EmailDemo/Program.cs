using FluentEmail.Core;
using FluentEmail.Smtp;
using System;
using System.Threading.Tasks;

namespace EmailDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var sender = new SmtpSender(() => new System.Net.Mail.SmtpClient("localhost")
            {
                EnableSsl = false,
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                Port = 25
                //PickupDirectoryLocation = @"D:\EmailDemos",
            });

            Email.DefaultSender = sender;

            var email = await Email
                .From("newprogrammer64@gmail.com")
                .To("newprogrammer64@gmail.com", "RoboBot")
                .Subject("Information:")
                .Body("Yello")
                .SendAsync();

        }
    }
}
