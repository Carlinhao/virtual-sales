using SalesMvc.Web.Models;

namespace SalesMvc.Web.Libraries.Email
{
    public interface IContactEmail
    {
        void SendContactEmail(Contact contact);
        void SendEmailToEmployee(Employee employee);
    }
}
