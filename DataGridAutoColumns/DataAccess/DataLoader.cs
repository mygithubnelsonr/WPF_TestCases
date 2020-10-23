using DasDataGrid.Entities;
using System;
using System.Collections.ObjectModel;

namespace DasDataGrid.DataAccess
{
    public class DataLoader
    {
        public static ObservableCollection<Employee> LoadEmployees()
        {
            var list = new ObservableCollection<Employee>
            {
                new Employee{FirstName="Thomas",
                LastName="Huber",
                StartDate=new DateTime(2010,5,1),
                Department= Department.IT,
                IsBoss=true,
                Homepage=new Uri("http://www.thomasclaudiushuber.com"),
                Responsibilities=new ObservableCollection<string>
                {
                    "Development",
                    "Projectmanagement",
                    "IT-Strategy"
                }
                },
                new Employee{FirstName="Jean-Yves",
                LastName="Konrad",
                StartDate=new DateTime(2010,6,1),
                Department= Department.Financial,IsBoss=true,IsMarried=true},
                new Employee{FirstName="Heiko", LastName="Vetter",StartDate=new DateTime(2010,5,1),Department=Department.IT},
                new Employee{FirstName="Julia",LastName="Huber",StartDate=new DateTime(2010,7,1),Department = Department.Marketing,IsBoss=true},
                new Employee{FirstName="Uli",LastName="Hoeneß", StartDate=new DateTime(2010,10,1),Department=Department.Purchasing,IsMarried=true},
            };

            return list;
        }
    }
}
