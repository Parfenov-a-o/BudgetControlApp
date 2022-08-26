using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetControlApp.Domain.Exceptions
{
    public class NotEnoughMoneyException : Exception
    {
        public double AccountBalance { get; set; }
        public double RequiredBalance { get; set; }

        public NotEnoughMoneyException(double accountBalance, double requiredBalance)
        {
            AccountBalance = accountBalance;
            RequiredBalance = requiredBalance;
        }

        public NotEnoughMoneyException(double accountBalance, double requiredBalance,string message) : base(message)
        {
            AccountBalance = accountBalance;
            RequiredBalance = requiredBalance;
        }

        public NotEnoughMoneyException(double accountBalance, double requiredBalance,string message, Exception innerException) : base(message, innerException)
        {
            AccountBalance = accountBalance;
            RequiredBalance = requiredBalance;
        }
    }
}
