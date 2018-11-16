using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAdo1
{
    class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }


    }

    class Program
    {



        static void Main(string[] args)
        {
            Person First = new Person { Age = 27, Name = "Yura", Id = 1 };
            Person Second = new Person { Age = 34, Name = "Sergei", Id = 2 };
            List<Person> People = new List<Person> { First, Second };

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=DataBaseAdo1;Integrated Security=True";
            int age=0;
            string name = "";
            string sqlExpression = "INSERT INTO Users (Name, Age) VALUES (@name, @age)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                foreach (Person o in People)
                {
                    age = o.Age;
                    name = o.Name;
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    
                    SqlParameter nameParam = new SqlParameter("@name", name);
                    
                    command.Parameters.Add(nameParam);
                    
                    SqlParameter ageParam = new SqlParameter("@age", age);
                    
                    command.Parameters.Add(ageParam);

                    command.ExecuteNonQuery();
                   
                }
            }

        }
    }
}
