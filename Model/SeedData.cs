using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Context(serviceProvider.GetRequiredService<
                    DbContextOptions<Context>>()))
            {
                if (context.Company.Any())
                {
                    return;
                }
                EmployeeType employeeType1 = new EmployeeType
                {
                    naziv = "Junior"
                };
                EmployeeType employeeType2 = new EmployeeType
                {
                    naziv = "Medior"
                };
                EmployeeType employeeType3 = new EmployeeType
                {
                    naziv = "Senior"
                };
                EmployeeType employeeType4 = new EmployeeType
                {
                    naziv = "Mabager"
                };
                context.EmployeeTypes.AddRange(employeeType1, employeeType2, employeeType3, employeeType4);
                Employee employee1 = new Employee
                {
                    fullName = "Tamara Milovanovic",
                    email = "tamara@gmail.com",
                    phoneNumber = "064846186",
                    dateOfBirth = new DateTime(2001, 2, 15),
                    monthlySalary = 650,
                    employeeType = employeeType1
                };
                Employee employee2 = new Employee
                {
                    fullName = "Dunja Milijic",
                    email = "dunja@gmail.com",
                    phoneNumber = "064846186",
                    dateOfBirth = new DateTime(2002, 6, 11),
                    monthlySalary = 650,
                    employeeType = employeeType1
                };
                Employee employee3 = new Employee
                {
                    fullName = "Uros Stankovic",
                    email = "uros@gmail.com",
                    phoneNumber = "064846186",
                    dateOfBirth = new DateTime(1995, 4, 22),
                    monthlySalary = 1000.50f,
                    employeeType = employeeType2
                };
                Employee employee4 = new Employee
                {
                    fullName = "Lana Kostic",
                    email = "Lana@gmail.com",
                    phoneNumber = "064846186",
                    dateOfBirth = new DateTime(2001, 1, 13),
                    monthlySalary = 650,
                    employeeType = employeeType1
                };
                Employee employee5 = new Employee
                {
                    fullName = "Janko Mitkovic",
                    email = "janko@gmail.com",
                    phoneNumber = "064846186",
                    dateOfBirth = new DateTime(1992, 7, 20),
                    monthlySalary = 1700,
                    employeeType = employeeType3
                };
                Employee employee6 = new Employee
                {
                    fullName = "Sara Savic",
                    email = "sara@gmail.com",
                    phoneNumber = "064846186",
                    dateOfBirth = new DateTime(1999, 12, 5),
                    monthlySalary = 650,
                    employeeType = employeeType1
                };
                Employee employee7 = new Employee
                {
                    fullName = "Andrija Zlatjovic",
                    email = "andrija@gmail.com",
                    phoneNumber = "064846186",
                    dateOfBirth = new DateTime(1998, 8, 15),
                    monthlySalary = 800,
                    employeeType = employeeType2
                };
                Employee employee8 = new Employee
                {
                    fullName = "Tamara Misic",
                    email = "tamaram@gmail.com",
                    phoneNumber = "064846186",
                    dateOfBirth = new DateTime(2000, 11, 20),
                    monthlySalary = 650,
                    employeeType = employeeType1
                };
                Employee employee9 = new Employee
                {
                    fullName = "Uros Milovanovic",
                    email = "urosm@gmail.com",
                    phoneNumber = "064846186",
                    dateOfBirth = new DateTime(1997, 4, 11),
                    monthlySalary = 650,
                    employeeType = employeeType1
                };
                Employee employee10 = new Employee
                {
                    fullName = "Zeljko jankovic",
                    email = "Zeljko@gmail.com",
                    phoneNumber = "064846186",
                    dateOfBirth = new DateTime(1990, 4, 8),
                    monthlySalary = 1350,
                    employeeType = employeeType4
                };
                Employee employee11 = new Employee
                {
                    fullName = "Irina Petrovic",
                    email = "irina@gmail.com",
                    phoneNumber = "064846186",
                    dateOfBirth = new DateTime(1997, 2, 15),
                    monthlySalary = 650,
                    employeeType = employeeType1
                };
                Employee employee12 = new Employee
                {
                    fullName = "Radovan Milenkovic",
                    email = "radovan@gmail.com",
                    phoneNumber = "064846186",
                    dateOfBirth = new DateTime(1993, 3, 30),
                    monthlySalary = 1500,
                    employeeType = employeeType4
                };
                Employee employee13 = new Employee
                {
                    fullName = "Anja Ilic",
                    email = "anja@gmail.com",
                    phoneNumber = "064846186",
                    dateOfBirth = new DateTime(2003, 5, 30),
                    monthlySalary = 500,
                    employeeType = employeeType1
                };
                Employee employee14 = new Employee
                {
                    fullName = "Kosta Veselic",
                    email = "kosta@gmail.com",
                    phoneNumber = "064846186",
                    dateOfBirth = new DateTime(1998, 2, 15),
                    monthlySalary = 650,
                    employeeType = employeeType1
                };
                Employee employee15 = new Employee
                {
                    fullName = "Valjko Blagojevic",
                    email = "veljko@gmail.com",
                    phoneNumber = "064846186",
                    dateOfBirth = new DateTime(1999, 12, 1),
                    monthlySalary = 700,
                    employeeType = employeeType1
                };
                Employee employee16 = new Employee
                {
                    fullName = "Miliva Vasiljevic",
                    email = "tamara@gmail.com",
                    phoneNumber = "064846186",
                    dateOfBirth = new DateTime(1996, 3, 15),
                    monthlySalary = 1650,
                    employeeType = employeeType3
                };
                context.Employees.AddRange(employee1,
                                employee2,
                                employee3,
                                employee4,
                                employee5,
                                employee6,
                                employee7,
                                employee8,
                                employee9,
                                employee10,
                                employee11,
                                employee12,
                                employee13,
                                employee14,
                                employee15,
                                employee16);

                context.Company.AddRange(
                    new Company
                    {
                        name = "Company 1",
                        address = "Address 1",
                        city = "City 1",
                        employee = new List<Employee>() { employee1, employee2, employee3, employee4 }
                    },
                     new Company
                     {
                         name = "Company 2",
                         address = "Address 2",
                         city = "City 2",
                         employee = new List<Employee>() { employee5, employee6, employee7, employee8 }
                     },
                     new Company
                     {
                         name = "Company 3",
                         address = "Address 3",
                         city = "City 3",
                         employee = new List<Employee>() { employee9, employee10, employee11, employee12 }
                     },
                    new Company
                    {
                        name = "Company 4",
                        address = "Address 4",
                        city = "City 4",
                        employee = new List<Employee>() { employee13, employee14, employee15, employee16 }
                    }
                );
                Meeting meeting = new Meeting
                {
                    date = new DateTime(2023, 3, 13, 13, 0, 0),
                    duration = 90,
                    description = "Important meeting",

                };
                EmployeeMeeting employeeMeeting = new EmployeeMeeting()
                {
                    meeting = meeting,
                    employee = employee1
                };
                meeting.EmployeeMeetings = new List<EmployeeMeeting>
                {
                    employeeMeeting
                };

                Meeting meeting1 = new Meeting
                {
                    date = new DateTime(2023, 3, 13, 13, 0, 0),
                    duration = 90,
                    description = "Important meeting",

                };
                EmployeeMeeting employeeMeeting1 = new EmployeeMeeting()
                {
                    meeting = meeting,
                    employee = employee1
                };
                EmployeeMeeting employeeMeeting2 = new EmployeeMeeting()
                {
                    meeting = meeting,
                    employee = employee2
                };
                EmployeeMeeting employeeMeeting3 = new EmployeeMeeting()
                {
                    meeting = meeting,
                    employee = employee3
                };
                meeting1.EmployeeMeetings = new List<EmployeeMeeting>()
                {
                    employeeMeeting1,
                    employeeMeeting2,
                    employeeMeeting3
                };
                
                

                Meeting meeting2 = new Meeting
                {
                    date = new DateTime(2023, 1, 20, 12, 0, 0),
                    duration = 90,
                    description = "Important meeting",

                };
                EmployeeMeeting employeeMeeting4 = new EmployeeMeeting()
                {
                    meeting = meeting,
                    employee = employee7
                };
                EmployeeMeeting employeeMeeting5 = new EmployeeMeeting()
                {
                    meeting = meeting,
                    employee = employee2
                };
                EmployeeMeeting employeeMeeting6 = new EmployeeMeeting()
                {
                    meeting = meeting,
                    employee = employee10
                };
                meeting2.EmployeeMeetings = new List<EmployeeMeeting>()
                {
                    employeeMeeting4,
                    employeeMeeting5,
                    employeeMeeting6
                };

                Meeting meeting3 = new Meeting
                {
                    date = new DateTime(2023, 2, 1, 13, 0, 0),
                    duration = 90,
                    description = "Important meeting",

                };
                EmployeeMeeting employeeMeeting7 = new EmployeeMeeting()
                {
                    meeting = meeting,
                    employee = employee2
                };
                EmployeeMeeting employeeMeeting8 = new EmployeeMeeting()
                {
                    meeting = meeting,
                    employee = employee13
                };
                EmployeeMeeting employeeMeeting9 = new EmployeeMeeting()
                {
                    meeting = meeting,
                    employee = employee5
                };
                EmployeeMeeting employeeMeeting10 = new EmployeeMeeting()
                {
                    meeting = meeting,
                    employee = employee16
                };
                meeting3.EmployeeMeetings = new List<EmployeeMeeting>()
                {
                    employeeMeeting7,
                    employeeMeeting8,
                    employeeMeeting9,
                    employeeMeeting10
                };
                
                context.Meetings.AddRange(
                    meeting,
                    meeting1,
                    meeting2,
                    meeting3
                );
                context.EmployeeMeetings.AddRange(
                    employeeMeeting,
                    employeeMeeting1,
                    employeeMeeting2,
                    employeeMeeting3,
                    employeeMeeting4,
                    employeeMeeting5,
                    employeeMeeting6,
                    employeeMeeting7,
                    employeeMeeting8,
                    employeeMeeting9,
                    employeeMeeting10
                );
                context.Tasks.AddRange(
                    new Task
                    {
                        descrption = "Some description of task",
                        dueDate = new DateTime(2023, 2, 13),
                        done = true,
                        assignee = employee1
                    },
                     new Task
                     {
                         descrption = "Some description of task",
                         dueDate = new DateTime(2023, 2, 13),
                         done = true,
                         assignee = employee1
                     },
                     new Task
                     {
                         descrption = "Some description of task",
                         dueDate = new DateTime(2023, 2, 13),
                         done = true,
                         assignee = employee1
                     },
                     new Task
                     {
                         descrption = "Some description of task",
                         dueDate = new DateTime(2023, 2, 13),
                         done = true,
                         assignee = employee1
                     },
                     new Task
                     {
                         descrption = "Some description of task",
                         dueDate = new DateTime(2023, 2, 13),
                         done = true,
                         assignee = employee1
                     },

                     new Task
                     {
                         descrption = "Some description of task",
                         dueDate = new DateTime(2023, 2, 13),
                         done = true,
                         assignee = employee2
                     },
                     new Task
                     {
                         descrption = "Some description of task",
                         dueDate = new DateTime(2023, 2, 13),
                         done = true,
                         assignee = employee2
                     },
                     new Task
                     {
                         descrption = "Some description of task",
                         dueDate = new DateTime(2023, 2, 13),
                         done = true,
                         assignee = employee2
                     },

                     new Task
                     {
                         descrption = "Some description of task",
                         dueDate = new DateTime(2023, 2, 13),
                         done = true,
                         assignee = employee2
                     },
                     new Task
                     {
                         descrption = "Some description of task",
                         dueDate = new DateTime(2023, 2, 13),
                         done = true,
                         assignee = employee4
                     },
                     new Task
                     {
                         descrption = "Some description of task",
                         dueDate = new DateTime(2023, 2, 13),
                         done = true,
                         assignee = employee4
                     },
                     new Task
                     {
                         descrption = "Some description of task",
                         dueDate = new DateTime(2023, 2, 13),
                         done = true,
                         assignee = employee4
                     },
                     new Task
                     {
                         descrption = "Some description of task",
                         dueDate = new DateTime(2023, 2, 13),
                         done = true,
                         assignee = employee7
                     },
                     new Task
                     {
                         descrption = "Some description of task",
                         dueDate = new DateTime(2023, 2, 13),
                         done = true,
                         assignee = employee7
                     },
                     new Task
                     {
                         descrption = "Some description of task",
                         dueDate = new DateTime(2023, 2, 13),
                         done = true,
                         assignee = employee10
                     },
                     new Task
                     {
                         descrption = "Some description of task",
                         dueDate = new DateTime(2023, 3, 13),
                         done = true,
                         assignee = employee10
                     },
                     new Task
                     {
                         descrption = "Some description of task",
                         dueDate = new DateTime(2022, 4, 13),
                         done = true,
                         assignee = employee10
                     },
                     new Task
                     {
                         descrption = "Some description of task",
                         dueDate = new DateTime(2022, 7, 13),
                         done = true,
                         assignee = employee10
                     },
                     new Task
                     {
                         descrption = "Some description of task",
                         dueDate = new DateTime(2022, 1, 15),
                         done = true,
                         assignee = employee10
                     },
                    new Task
                    {
                        descrption = "Some description of task",
                        dueDate = new DateTime(2023, 3, 15),
                        done = true,
                        assignee = employee10
                    }
                );
                context.SaveChanges();
            }
        }
    }
}