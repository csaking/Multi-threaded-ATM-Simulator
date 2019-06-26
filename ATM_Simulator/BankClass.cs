using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ATM_Simulator
{
    class Bank
    {
        //declare and initialise array that stores accounts
        public static Account[] accountStore = new Account[3];

        //declare and initialise semaphore of 4 slots, 3 for other threads and 1 for the current thread
        public static Semaphore bankSemaphore = new Semaphore(3, 4);

        //constructor
        public Bank()
        {
            //create accounts and store them
            accountStore[0] = new Account(300, 1111, 111111);
            accountStore[1] = new Account(750, 2222, 222222);
            accountStore[2] = new Account(3000, 3333, 333333);
        }

        //function which opens an account in an ATM form from account number and PIN input parameters
        public Boolean openATM(int AccNum, int PIN)
        {
            //declare local boolean check variable
            Boolean checkSuccessful = false;

            //loop through accountStore array
            for (int i = 0; i < 3; i++)
            {
                //if the account numbers match AND the checkPin function in account returns true
                if ((accountStore[i].getAccountNum() == AccNum) && (accountStore[i].checkPin(PIN) == true))
                {
                    //open an instance of the ATM form with the account values
                    frmATM ATM = new frmATM(i);
                    ATM.Show();
                    
                    //set boolean check variable to be true
                    checkSuccessful = true;
                }
            }
            //return boolean check variable
            return checkSuccessful;
        }

        //function which simulates work being done in the semaphore
        public static void semaphoreFunction()
        {
            //wait for an available slot
            bankSemaphore.WaitOne();

            //wait for 2000 milliseconds / 2 seconds
            Thread.Sleep(2000);
        }

        //function which withdraws from the account
        public static Boolean withdraw(int accStoreNum, int withNum)
        {
            //declare local variable
            Boolean successCheck = false;

            //call the semaphore function
            semaphoreFunction();

            //assign the check variable to be the return of the account's decrement balance function
            successCheck = accountStore[accStoreNum].decrementBalance(withNum);

            //release the slot
            bankSemaphore.Release();

            //return the boolean variable
            return successCheck;
        }
    }
}
