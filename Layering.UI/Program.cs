using ConsoleTools;
using Layering.Data;
using Layering.Data.Entities;
using Layering.Logic;
using Layering.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Layering.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();

            IStudentLogic studentLogic = host.Services.GetRequiredService<IStudentLogic>();
            ICourseLogic courseLogic = host.Services.GetRequiredService<ICourseLogic>();

            var menu = new ConsoleMenu(args, level: 0)
               .Add("Add Course", () => AddCourse(courseLogic))
               .Add("List Courses", () => GetCourses(courseLogic))
               .Add("Add Student", () => AddStudent(studentLogic))
               .Add("List Students", () => GetStudents(studentLogic))
               .Add("Get Student by Id", () => GetStudent(studentLogic))
               .Add("Assign Student to Course", () => AssignStudentToCourse(studentLogic))
               .Add("Close", ConsoleMenu.Close)
               .Add("Exit", () => Environment.Exit(0))
               .Configure(config =>
               {
                   config.Selector = "--> ";
                   config.EnableFilter = true;
                   config.Title = "Main menu";
                   config.EnableWriteTitle = true;
                   config.EnableBreadcrumb = true;
               });

            menu.Show();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\egyetem\Layering\Layering\Layering.Data\Db.mdf;Integrated Security=True";

            return Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                })
                .ConfigureServices((_, services) =>
                    services.AddDbContext<UniversityDbContext>(options => options.UseSqlServer(connectionString))
                            .AddTransient<IStudentRepository, StudentRepository>()
                            .AddTransient<ICourseRepository, CourseRepository>()
                            .AddTransient<IStudentLogic, StudentLogic>()
                            .AddTransient<ICourseLogic, CourseLogic>());
        }

        private static void AddCourse(ICourseLogic courseLogic)
        {
            Console.WriteLine("Please write the name of the course you want to create");

            string name = Console.ReadLine();

            courseLogic.CreateCourse(name);

            Console.WriteLine("Course created.");

            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }

        private static void AddStudent(IStudentLogic studentLogic)
        {
            Console.WriteLine("Please write the name of the student you want to create");

            string name = Console.ReadLine();

            studentLogic.CreateStudent(name);

            Console.WriteLine("Student created.");

            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }

        private static void GetCourses(ICourseLogic courseLogic)
        {
            List<Course> courses = courseLogic.GetCourses();

            courses.ForEach(course =>
            {
                Console.WriteLine($"Id: {course.Id} Name: {course.Name} Students: {string.Join(',', course.Students.Select(student => student.Name))}");
            });

            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }

        private static void GetStudents(IStudentLogic studentLogic)
        {
            List<Student> students = studentLogic.GetStudents();

            students.ForEach(student =>
            {
                Console.WriteLine($"Id: {student.Id} Name: {student.Name}");
            });

            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }

        private static void GetStudent(IStudentLogic studentLogic)
        {
            Console.WriteLine("Please write the id of the student you are looking for");
            string input = Console.ReadLine();

            Student student = studentLogic.GetStudent(int.Parse(input));

            if (student != null)
            {
                Console.WriteLine($"Id: {student.Id} Name: {student.Name}");
            }
            else
            {
                Console.WriteLine("Student not found");
            }

            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }

        private static void AssignStudentToCourse(IStudentLogic studentLogic)
        {
            Console.WriteLine("Please write the id of the student you are looking for");
            string studentInput = Console.ReadLine();

            Console.WriteLine("Please write the id of the course you are looking for");
            string courseInput = Console.ReadLine();


            studentLogic.AddStudentToCourse(int.Parse(studentInput), int.Parse(courseInput));

            Console.WriteLine("Student moved to different course.");

            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }
    }
}
