using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialControll.Models
{
    public class Profile : IdentityUser
    {
        public string Name { get; set; }

        public string Member { get; set; } = "Member";
        public double Sallary { get; set; }
        public DateTime BirthDate { get; set; }
        public Planning Planning { get; set; }
        public ICollection<Debt> Debt { get; set; } = new List<Debt>();
        public string OrgId { get; set; }



        public Profile()
        {
        }

        public Profile(string name, double sallary, DateTime birthDate, Planning planning)
        {
            Name = name;
            Sallary = sallary;
            BirthDate = birthDate;
            Planning = planning;
        }

        public class Organization
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }

        public void AddDebt(Debt debt)
        {
            Debt.Add(debt);
        }

        public void RemoveDebt(Debt debt)
        {
            Debt.Remove(debt);
        }


    }
}
