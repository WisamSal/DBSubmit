using ConsoleApp2.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace ConsoleApp2.DataAccess
{
    public class MyContext : DbContext
    {
        public MyContext()
            : base("Data Source=.;Initial Catalog=myDB;Integrated Security=SSPI;")
        {
            
        }
        public DbSet<Patients> patients { set; get;}
        
    }
}
