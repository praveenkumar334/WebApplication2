using Org.BouncyCastle.Asn1.Pkcs;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public interface IEMailService
    {
        bool SendMail(MailRequest mailData);
    }
}
