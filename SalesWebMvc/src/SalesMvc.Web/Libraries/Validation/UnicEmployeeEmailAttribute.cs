using System.ComponentModel.DataAnnotations;
using System.Linq;
using SalesMvc.Web.Models;
using SalesMvc.Web.Repositories.Interfaces;

namespace SalesMvc.Web.Libraries.Validation
{
    public class UnicEmployeeEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {            
            string Email = (value as string).Trim();
            IEmployeeRepository _employeeRepository = validationContext.GetService(typeof(IEmployeeRepository)) as IEmployeeRepository;
            var result = _employeeRepository.GetEmployerEmail(Email);

            Employee empl = (Employee)validationContext.ObjectInstance;

            if(result.Count() > 1)
                return new ValidationResult("E-mail already registered.");

            if(result.Count() == 1 && empl.Id != result.FirstOrDefault().Id)
                return new ValidationResult("E-mail already registered.");

            return ValidationResult.Success;
        }
    }
}
