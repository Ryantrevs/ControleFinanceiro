using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialControll.Models
{
    public class InstallmentDebt
    {
        
        public string Id { get; set; }
        public String Name { get; set; }
        public double Value { get; set; }
        public int Plots { get; set; }

        public InstallmentDebt()
        {
        }

        public InstallmentDebt(string id, string name, double value,int plots)
        {
            Id = id;
            Name = name;
            Value = value;
            Plots = plots;
        }
    }
}
