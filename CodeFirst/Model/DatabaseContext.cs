
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CODEFIRST.Model
{
      
     class DatabaseContext : DbContext  // database context child class bangyi dbcontext ki 
    {

        public DbSet<Employee> Employees { get; set; } // Employees ki property ma data store hoga employee ka , this is generic roperty jo Employee type ki ha , agar mujhy insert update deleete krwaana o ma employee ko usse krungi 


    }
}
