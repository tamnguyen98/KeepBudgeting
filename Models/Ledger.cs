using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeepBudgeting.Models
{
    public class Ledger
    {
        private string _name = "";
        private decimal _defaultSpendingCut = 0.3M; // percentage of the income set for spending
        private DateTime _created = DateTime.Now;
        private List<Statement> _statements = new List<Statement>();
        private short _performance = 0; // star rating

        public string Name { get => _name; set => _name = value; }
        public decimal DefaultSpending 
        { 
            get => _defaultSpendingCut;
            set
            {
                _defaultSpendingCut = Math.Max(0, value); // ensure it's positive
                _defaultSpendingCut = Math.Min(1, _defaultSpendingCut); // 1 (100%) is the max
            }
        }
        public DateTime Created { get => _created; private set => _created = value; }
        public List<Statement> Statements { get => _statements; set => _statements = value; }
        public short Performance { get => _performance; private set => _performance = value; }

        public Ledger()
        {
             
        }
    }
}
