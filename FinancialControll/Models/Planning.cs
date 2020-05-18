using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialControll.Models
{
    public class Planning
    {
        [Key]
        public string ProfileId { get; set; }
        public double Goal { get; set; }
        public double SavedForMonth { get; set; }
        public double Paid { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinalDate { get; set; }
        public Profile Profile { get; set; }



        public Planning()
        {
        }

        public Planning(string profileId, double goal, double savedForMonth, double paid, DateTime startDate, DateTime finalDate)
        {
            ProfileId = profileId;
            Goal = goal;
            SavedForMonth = savedForMonth;
            Paid = paid;
            StartDate = startDate;
            FinalDate = finalDate;
           
        }
    }
}
