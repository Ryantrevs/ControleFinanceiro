using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialControll.Models
{
    public class Card
    {
        public string Id { get; set; }
        public DateTime DueDate { get; set; }
        public string Name { get; set; }
        ICollection<InstallmentDebt> Plots { get; set; } = new List<InstallmentDebt>();

        public Card()
        {
        }

        public Card(string id,DateTime dueDate, string name)
        {
            Id = id;
            DueDate = dueDate;
            Name = name;
        }

        public void AddDebt(InstallmentDebt plots)
        {
            Plots.Add(plots);
        }

        public void RemoveDebt(InstallmentDebt plots)
        {
            Plots.Remove(plots);
        }
    }
}
