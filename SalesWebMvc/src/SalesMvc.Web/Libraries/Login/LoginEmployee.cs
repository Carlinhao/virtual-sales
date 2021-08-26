using System.Text.Json;
using SalesMvc.Web.Libraries.Sessions;
using SalesMvc.Web.Models;

namespace SalesMvc.Web.Libraries.Login
{
    public class LoginEmployee
    {
        private readonly string _key = "Login.Employee";
        private readonly Session _sesseion;

        public LoginEmployee(Session sesseion)
        {
            _sesseion = sesseion;
        }

        public void PostEmplyee(Employee emplyee)
        {
            var value = JsonSerializer.Serialize(emplyee);

            _sesseion.Create(_key, value);
        }

        public Employee GetEmplyee()
        {
            if (_sesseion.Exist(_key))
            {
                return JsonSerializer.Deserialize<Employee>(_sesseion.Search(_key));
            }
            return null;
        }

        public void Logout()
        {
            _sesseion.RemoveAll();
        }
    }
}
