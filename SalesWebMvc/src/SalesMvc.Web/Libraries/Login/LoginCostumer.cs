using System.Text.Json;
using SalesMvc.Web.Libraries.Sessions;
using SalesMvc.Web.Models;

namespace SalesMvc.Web.Libraries.Login
{
    public class LoginCostumer
    {
        private readonly string _key = "Login.Costumer";
        private readonly Session _sesseion;

        public LoginCostumer(Session sesseion)
        {
            _sesseion = sesseion;
        }

        public void PostCostumer(Customer costumer)
        {
            var value = JsonSerializer.Serialize(costumer);

            _sesseion.Create(_key, value);
        }

        public Customer GetCustomer()
        {
            if(_sesseion.Exist(_key))
            {
                return JsonSerializer.Deserialize<Customer>(_sesseion.Search(_key));
            }
            return null;            
        }

        public void Logout()
        {
            _sesseion.RemoveAll();
        }
    }
}
