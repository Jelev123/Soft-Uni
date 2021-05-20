﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DefiningClasses;

namespace Define_a_Class_Person
{
   public class Family
    {
        public List<Person> People { get; set; }

        public Family()
        {
            People = new List<Person>();
        }

        public void AddMember(Person member)
        {
            People.Add(member);
        }

       public Person GetOldestMember()
       {
           Person oldestPerson = People.OrderByDescending(p => p.Age)
               .FirstOrDefault();
           return oldestPerson; 

       } 
    }
}
