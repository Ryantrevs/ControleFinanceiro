using FinancialControll.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace FinancialControll.Models
{
    public class Debt
    {
 
        public string Id { get; set; }
        public double SimpleDebt { get; set; }
        public string NameDebt { get; set; }
        public ICollection<Card> Card { get; set; } = new List<Card>();
        public DebtStatus Status { get; set; }

        public int MyProperty { get; set; }

        public Debt()
        {
        }

        public Debt(string id, double simpleDebt, string nameDebt,DebtStatus status)
        {
            Id = id;
            SimpleDebt = simpleDebt;
            NameDebt = nameDebt;
            Status = status;
        }

        public void AddCard(Card card)
        {
            Card.Add(card);
        }

        public void RemoveCard(Card card)
        {
            Card.Remove(card);
        }
    }
}
