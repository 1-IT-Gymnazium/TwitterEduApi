using NodaTime;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterEdu.Data.Entities;
[Table(nameof(EmailMessage))]
public class EmailMessage
{
    public Guid Id { get; set; }
    public required string RecipientEmail { get; set; }
    public required string RecipientName { get; set; }
    public required string Subject { get; set; }
    public required string Body { get; set; }
    public bool Sent { get; set; }
    public Instant CreatedBy { get; set; }
    public required string FromEmail { get; set; }
    public required string FromName { get; set; }
}
