using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Net.Mail;
using TwitterEdu.Api.Options;
using TwitterEdu.Data;

namespace TwitterEdu.Api.Services;

public class EmailSenderService
{
    private readonly AppDbContext _dbContext;
    private readonly SmtpOptions _smtpOptions;

    public EmailSenderService(AppDbContext appDbContext, IOptions<SmtpOptions> options)
    {
        _dbContext = appDbContext;
        _smtpOptions = options.Value;
    }
    public async Task SendEmailsAsync()
    {
        var unsentMails = await _dbContext.Emails.Where(x => !x.Sent).ToListAsync();
        foreach (var unsent in unsentMails)
        {
            using var mail = new MailMessage
            {
                Subject = unsent.Subject,
                Body = unsent.Body,
                IsBodyHtml = false,
                From = new MailAddress(unsent.FromEmail, unsent.FromName),
            };
            mail.To.Add(new MailAddress(unsent.RecipientEmail, unsent.RecipientName));

            try
            {
                using var smtp = new MailKit.Net.Smtp.SmtpClient();
                await smtp.ConnectAsync(_smtpOptions.Host, _smtpOptions.Port);
                await smtp.AuthenticateAsync(_smtpOptions.Username, _smtpOptions.Password);
                await smtp.SendAsync((MimeMessage)mail);

                unsent.Sent = true;
            }
            catch (Exception ex)
            {
            }
        }
    }
}
