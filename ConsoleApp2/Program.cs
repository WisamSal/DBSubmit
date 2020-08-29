using ConsoleApp2.DataAccess;
using ConsoleApp2.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running...!");
            var dbContext = new MyContext();
            string filePath = @"C:\Users\wsala\OneDrive\Desktop\text.txt";
            List<string> lines = new List<string>();
            try { 
                lines = File.ReadAllLines(filePath).ToList();
            }
            catch (Exception x)
            {
                Console.WriteLine("Error while reading file!");
            }
            try { 
                foreach(String line in lines)
                {
                    Console.WriteLine("Submitted !");
                    var array = line.Split(',');
                    var id = Int32.Parse(array[0]);
                    var name = array[1].Replace(@"""","");
                    var age = Int32.Parse(array[2]);

                    dbContext.patients.RemoveRange(dbContext.patients);

                    dbContext.patients.Add(new Patients
                    {
                        id = id,
                        name = name,
                        age = age
                    });
                }

                dbContext.SaveChanges();
            }
            catch (Exception x) {
                Console.WriteLine(x.Message);
            }
            Console.ReadLine();
        }
    }
}