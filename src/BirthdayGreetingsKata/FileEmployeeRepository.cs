using System.Collections.Generic;
using System.IO;

namespace BirthdayGreetings
{
    public class FileEmployeeRepository : IEmployeeRepository
    {
        private readonly string _fileName;

        public FileEmployeeRepository(string fileName)
        {
            _fileName = fileName;
        }

        public List<Employee> GetAll()
        {
            List<Employee> employees = new List<Employee>();
            if (System.IO.File.Exists(_fileName))
            {
                var objStream = new FileStream(_fileName, FileMode.Open);
                var objReader = new StreamReader(objStream);
                do
                {
                    var textLine = objReader.ReadLine();
                    if (!string.IsNullOrEmpty(textLine) && !textLine.Contains("last_name"))
                    {
                        var employeeData = textLine.Split(new char[] { ',' });
                        var employee = new Employee
                        {
                            FirstName = employeeData[1],
                            LastName = employeeData[0],
                            BirthDate = new XDate(employeeData[2]),
                            Email = employeeData[3]
                        };

                        employees.Add(employee);
                    }
                } while (objReader.Peek() != -1);

            }

            return employees;
        }
    }
}