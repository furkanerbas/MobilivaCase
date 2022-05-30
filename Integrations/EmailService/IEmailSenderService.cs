using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrations.EmailService
{
    public interface IEmailSenderService
    {
        Task SendAsync(EmailMessageModel message);
    }
}
