using System.Collections.Generic;

namespace BirthdayGreetings
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAll();
    }
}