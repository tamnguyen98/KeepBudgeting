using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeepBudgeting.Models
{
    public class Transaction
    {
        private int _noteMaxLen = 150;
        private string _note = "";

        // Don't think we'll need to set up private properties for this class
        public string   Label = "";
        public DateTime Date = DateTime.Now;
        public decimal  Cost = 0.0M;
        public string   Category = "";
        public string Note 
        { 
            get => _note;
            set 
            {
                if (value != null && value.Length <= 150)
                    Note = value;
            } 
        }

        public Transaction(string name, 
                            DateTime? date, 
                            decimal cost, 
                            string note,
                            string category)
        {
            Label = name;
            Cost = cost;
            Note = note; // No need to check since the setter does it for us
            if (date.HasValue)
                Date = date.Value;
            if (Category != null)
                Category = category;
        }
    }
}
