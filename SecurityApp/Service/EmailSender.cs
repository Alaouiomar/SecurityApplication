using Azure.Core;
using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SecurityApp.Service
{
    public class EmailSender : IEmailSender
    {
       // public string SendGridKey { get; set; }
       // public EmailSender(IConfiguration _config)
       // {
       //     SendGridKey = _config.GetValue<string>("SendGrid:SecretKey");
       // }

        public async Task SendEmailAsync(string recipientEmail, string subject, string body)
        {

            //   var client = new SendGridClient(SendGridKey);
            //   var from_email = new EmailAddress("hello@dotnetmastery.com", "DotNetMastery - Identity Manager");
            //   var to_email = new EmailAddress(recipientEmail);
            //   var msg = MailHelper.CreateSingleEmail(from_email, to_email, subject, "", body);
            //   return client.SendEmailAsync(msg);

            string smtpServer = "smtp.example.com";
            int smtpPort = 587;
            string smtpUsername = "votre_adresse_email@example.com";
            string smtpPassword = "votre_mot_de_passe";

            // Adresse e-mail de l'expéditeur
            string senderEmail = "votre_adresse_email@example.com";

            // Création de l'objet SmtpClient
            using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                smtpClient.EnableSsl = true;

                // Création de l'objet MailMessage
                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(senderEmail);
                    mailMessage.To.Add(recipientEmail);
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;
                    mailMessage.IsBodyHtml = true;

                    try
                    {
                        // Envoi de l'e-mail
                        await smtpClient.SendMailAsync(mailMessage);
                        Console.WriteLine("E-mail envoyé avec succès !");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erreur lors de l'envoi de l'e-mail : {ex.Message}");
                        // Gérer l'erreur (journalisation, notification, etc.)
                    }
                }
            }
        }
    }
}