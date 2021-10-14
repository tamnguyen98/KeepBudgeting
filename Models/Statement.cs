using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeepBudgeting.Models
{
    public class Statement
    {
        private DateTime _start = DateTime.Now;
        private DateTime _end = DateTime.Now.AddDays(14); // 2 week period
        private decimal _spendingPercent = 0.3M;
        private decimal _savingPercent = 0.7M;
        private decimal _takehome = 0.0M; // Pay for this period
        private decimal _balance = 0.0M;
        private List<Transaction> _transactions = new List<Transaction>();
        private bool _isInBudget = true;
        public DateTime Start 
        { 
            get => _start; 
            set => _start = value; 
        }
        public DateTime End 
        { 
            get => _end;
            set
            {
                if (IsD1BeforeD2(_start, value))
                {
                    // Assign only if the value is after the start date
                    _end = value;
                }
            }
        }
        public decimal SpendingPercent { 
            get => _spendingPercent;
            set => _spendingPercent = BoundValue(value, 0, 1M);
        }

        public decimal SavingPercent
        {
            get => _savingPercent;
            set=> _savingPercent = BoundValue(value, 0, 1M);
        }

        public decimal Balance 
        {
            get => _balance;
            private set => _balance = value;
        }

        public List<Transaction> Transactions 
        { 
            get => _transactions; 
            private set => _transactions = value;  // Private for now?
        }

        public bool IsInBudget 
        { 
            get => _isInBudget; 
            private set => _isInBudget = value; 
        }
        public Statement(decimal income, decimal rollover, decimal? spendingPercent, decimal? savingPercent)
        {
            if (spendingPercent.HasValue)
                SpendingPercent = spendingPercent.Value;
            if (savingPercent.HasValue)
                SavingPercent = savingPercent.Value;

            _takehome = income;
            Balance = income * SpendingPercent;
            Balance -= rollover;
            IsInBudget = (Balance < 0);
        }

        public decimal AddBalance (decimal val)
        {
            Balance += val;
            return val;
        }

        public decimal DeductBalance (decimal val)
        {
            Balance -= val;
            return val;
        }

        public bool AddTransaction (Transaction t)
        {
            if (Transactions == null)
                Transactions = new List<Transaction>();
            Transactions.Add(t);

            return Transactions.Contains(t);
        }

        public void AddTransactions(Object o)
        {
            //TODO
        }

        public bool IsD1BeforeD2 (DateTime d1, DateTime d2)
        {
            return d1.CompareTo(d2) < 0;
        }

        private decimal BoundValue (decimal value, decimal min, decimal max)
        {
            decimal ans = Math.Max(0, value); // ensure it's positive
            ans = Math.Min(1, ans); // 1 (100%) is the max

            return ans;
        }
    }
}
