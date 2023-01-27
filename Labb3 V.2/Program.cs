
using Labb3_V._2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Data;
using System.Data.Common;
using System.Security.Cryptography.X509Certificates;

namespace Labb3
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Run();
        }
        public static void Run()
        {

            SchoolDbContext dbCon = new SchoolDbContext();

           bool loopBool = true;            
            while (loopBool) 
            {
                int userChoice = 0;
                Console.Clear();
                Console.WriteLine
                ("\t[1]Print Students names.\n" +
                " \t[2]Get all students from a certain class\n" +
                " \t[3]Add Personell");
                try
                {
                   userChoice = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {

                    Console.WriteLine("Wrong input");
                    Console.ReadLine();
                }
            

                switch (userChoice)
                {
                    case 1:
                        Console.WriteLine(
                     "\t[1]Sort By Firstname Descending\n" +
                     "\t[2]Sort By Firstname Ascending\n" +
                     "\t[3]Sort By Lastname Descending\n" +
                     "\t[4]Sort By Lastname Ascending");
                        int userChoice2 = int.Parse(Console.ReadLine());
                        switch (userChoice2)
                        {
                            case 1:
                                foreach (var item in dbCon.Students.OrderBy(x => x.FirstName))
                                {
                                    Console.WriteLine($"\t{item.FirstName} {item.LastName}");                                
                                }
                                Console.ReadKey();
                                break;
                            case 2:
                                foreach (var item in dbCon.Students.OrderByDescending(x => x.FirstName))
                                {
                                    Console.WriteLine($"\t{item.FirstName} {item.LastName}");
                                }
                                Console.ReadKey();
                                break;
                            case 3:
                                foreach (var item in dbCon.Students.OrderBy(x => x.LastName))
                                {
                                    Console.WriteLine($"\t{item.FirstName} {item.LastName}");
                                }
                                Console.ReadKey();
                                break;
                            case 4:
                                foreach (var item in dbCon.Students.OrderByDescending(x => x.LastName))
                                {
                                    Console.WriteLine($"\t{item.FirstName} {item.LastName}");
                                }
                                Console.ReadKey();
                                break;
                            default:
                                Console.WriteLine("Wrong Input.");
                                Console.ReadKey();
                                break;
                        }

                        break;
                    case 2:
                        Console.WriteLine(
                      "\t[1]Class 9a\n" +
                      "\t[2]Class 9b\n" +
                      "\t[3]Class 8a\n" +
                      "\t[4]Class 7b");
                        int userChoice3 = int.Parse(Console.ReadLine());
                        switch (userChoice3)
                        {
                            case 1:
                                foreach (var item in dbCon.Students.Where(x => x.ClassId == 1))
                                {
                                    Console.WriteLine($"\t{item.FirstName} {item.LastName}");                                   
                                }
                                Console.ReadKey();
                                break;
                            case 2:
                                foreach (var item in dbCon.Students.Where(x => x.ClassId == 4))
                                {
                                    Console.WriteLine($"\t{item.FirstName} {item.LastName}");                                  
                                }
                                Console.ReadKey();
                                break;
                            case 3:
                                foreach (var item in dbCon.Students.Where(x => x.ClassId == 2))
                                {                                                        
                                        Console.WriteLine($"\t{item.FirstName} {item.LastName}");                                  
                                }
                                Console.ReadKey();
                                break;

                            case 4:
                                foreach (var item in dbCon.Students.Where(x => x.ClassId == 3))
                                {
                                    Console.WriteLine($"\t{item.FirstName} {item.LastName}");                               
                                }                              
                                Console.ReadKey();
                                break;
                            default:
                                Console.WriteLine("Wrong Input.");
                                break;
                        }
                        break;
                    case 3:
                        Console.WriteLine("\tInput new Employee First name:");
                        string firstName = Console.ReadLine();

                        Console.WriteLine("\tInput new Employee Last name:");
                        string lastName = Console.ReadLine();

                        Console.WriteLine("\tInput new Employee Gender:");
                        string gender = Console.ReadLine();

                        Console.WriteLine("\tInput new Employee Age:");
                        int age = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("\tInput new Role ID:");
                        Console.WriteLine("\t[1] Principal\n" + "\t[2] Teacher\n" + "\t[3] Administrator\n" + "\t[4] Groundskeeper\n");
                        int roleID = Convert.ToInt32(Console.ReadLine());

                        Personel NewPersonel = new Personel()
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            Gender = gender,
                            Age = age,
                            EmployeeRole = roleID
                        };

                        dbCon.Personels.Add(NewPersonel);
                        dbCon.SaveChanges();


                        foreach (var item in dbCon.Personels)
                        {
                            Console.WriteLine("\t" + item.FirstName + " " + item.LastName + " " + $"Role ID : {item.EmployeeRole}");
                        }
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Wrong input");
                        break;
                }
            }

        }

    }
}




