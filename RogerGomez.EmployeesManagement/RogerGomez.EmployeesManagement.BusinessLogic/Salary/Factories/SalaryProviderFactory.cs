using System;
using System.Linq;
using System.Reflection;
using RogerGomez.EmployeesManagement.Entities;

namespace RogerGomez.EmployeesManagement.BusinessLogic.Salary.Factories
{
    public abstract class SalaryProviderFactory
    {
        public static SalaryProvider CreateSalaryProvider(TypeOfContract typeOfContract)
        {
            var providers = Assembly.GetAssembly(typeof(SalaryProvider))
                .GetTypes()
                .Where(t => typeof(SalaryProvider).IsAssignableFrom(t));

            var provider = providers.Single(x => x.Name.ToLowerInvariant().Contains(typeOfContract.ToString().ToLowerInvariant()));
            return (SalaryProvider)Activator.CreateInstance(provider);
        }
    }
}
