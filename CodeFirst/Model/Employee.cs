using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODEFIRST.Model
{
    class Employee // iskay through database mai table banyga
    {
        [Key] // anotation ha jo primary key bandeygi 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Designation { get; set; }
    }
}

// aik au class banaygy connectivity k liye . is class ko context class kaha jata h 
//employee ka jitna b data store hoga wo context class ma hoga show 