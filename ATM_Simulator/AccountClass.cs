using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ATM_Simulator
{
    //this class has been copied from the example code
    class Account
    {
        //the attributes for the account
        private int balance;
        private int pin;
        private int accountNum;

        // a constructor that takes initial values for each of the attributes (balance, pin, accountNumber)
        public Account(int balance, int pin, int accountNum)
        {
            this.balance = balance;
            this.pin = pin;
            this.accountNum = accountNum;
        }

        //getter and setter functions for account balance
        public int getBalance()
        {
            return balance;
        }

        public void setBalance(int newBalance)
        {
            this.balance = newBalance;
        }

        /*
        *   This function allows us to decrement the balance of an account
        *   it perfoms a simple check to ensure the balance is greater than
        *   the amount being debited
        *   
        *   returns:
        *   true if the transaction is possible
        *   false if there are insufficent funds in the account
        */
        public Boolean decrementBalance(int amount)
        {
            if (this.balance >= amount)
            {
                balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }

        /*
         * This function checks the account pin against the argument passed to it
         *
         * returns:
         * true if they match
         * false if they do not
         */
        public Boolean checkPin(int pinEntered)
        {
            if (pinEntered == pin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //function which returns the account number
        public int getAccountNum()
        {
            return accountNum;
        }
    }
}
