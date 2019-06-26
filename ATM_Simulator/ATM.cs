using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ATM_Simulator
{
    public partial class frmATM : Form
    {
        //declare variable that stores which account this instance of ATM is accessing
        int accStoreNum;

        //constructor
        public frmATM(int storeNum)
        {
            InitializeComponent();

            //disable control box
            this.ControlBox = false;

            //set store tracking variable from input parameter
            accStoreNum = storeNum;

            //hide withdraw options when this instance of the form is created
            hideWithdraw();
            hidePresets();
            hideBalance();

            //retrieve and display currently open account number to the user
            txtAccNum.Text = Bank.accountStore[accStoreNum].getAccountNum().ToString();

            //retrieve and display currently open account balance to the user
            txtBalance.Text = Bank.accountStore[accStoreNum].getBalance().ToString();

            //disable user resizing windows
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }
    
        //function which hides the input keypad from the user
        private void hideKeypad()
        {
            btn0.Hide();
            btn1.Hide();
            btn2.Hide();
            btn3.Hide();
            btn4.Hide();
            btn5.Hide();
            btn6.Hide();
            btn7.Hide();
            btn8.Hide();
            btn9.Hide();
            btnEnter.Hide();
            btnClear.Hide();
        }

        //function which displays the input keypad to the user
        private void showKeypad()
        {
            btn0.Show();
            btn1.Show();
            btn2.Show();
            btn3.Show();
            btn4.Show();
            btn5.Show();
            btn6.Show();
            btn7.Show();
            btn8.Show();
            btn9.Show();
            btnEnter.Show();
            btnClear.Show();
        }
        
        //function which displays the withdraw options to the user and hides the standard options
        private void showWithdraw()
        {
            showKeypad();
            btnBack.Show();
            lblWithdraw.Show();
            txtWithdraw.Show();
            btnCheckBal.Hide();
            btnWithdraw.Hide();
            btnExitAcc.Hide();
            txtWithdraw.Text = "";
            lblSymbol1.Show();
            pbWithdraw.Hide();
            pbBalance.Hide();
        }

        //function which hides the withdraw opetions from the user and shows the standard options
        private void hideWithdraw()
        {
            hideKeypad();
            btnBack.Hide();
            lblWithdraw.Hide();
            txtWithdraw.Hide();
            btnWithdraw.Show();
            btnCheckBal.Show();
            btnExitAcc.Show();
            txtWithdraw.Text = "";
            lblSymbol1.Hide();
            pbWithdraw.Show();
            pbBalance.Show();
            pbJeans.Show();
        }

        private void showBalance()
        {
            lblBalance.Show();
            lblSymbol2.Show();
            txtBalance.Show();
            pbWithdraw.Hide();
            pbBalance.Hide();

        }

        private void hideBalance()
        {
            lblBalance.Hide();
            lblSymbol2.Hide();
            txtBalance.Hide();
        }

        //function which hides the preset Withdraw buttons
        private void hidePresets()
        {
            btnWith10.Hide();
            btnWith20.Hide();
            btnWith30.Hide();
            btnWith40.Hide();
            btnWith50.Hide();
            btnWith60.Hide();
            btnWith100.Hide();
            btnWithOther.Hide();
            pb10.Hide();
            pb20.Hide();
            pb30.Hide();
            pb40.Hide();
            pb50.Hide();
            pb60.Hide();
            pb100.Hide();
            pbOther.Hide();
        }

        //function which shows the preset Withdraw buttons
        private void showPresets()
        {
            btnWith10.Show();
            btnWith20.Show();
            btnWith30.Show();
            btnWith40.Show();
            btnWith50.Show();
            btnWith60.Show();
            btnWith100.Show();
            btnBack.Show();
            btnWithOther.Show();
            btnWithdraw.Hide();
            btnCheckBal.Hide();
            lblWithdraw.Show();
            pb10.Show();
            pb20.Show();
            pb30.Show();
            pb40.Show();
            pb50.Show();
            pb60.Show();
            pb100.Show();
            pbOther.Show();
        }

        private void frmATM_Load(object sender, EventArgs e)
        {

        }

        //button that when clicked, prompts the user for confirmation and then closes the form if it receives it
        private void btnExitAcc_Click(object sender, EventArgs e)
        {
            //declare checker variable
            DialogResult confirmCheck;

            //construct message box 
            string message = "Are you sure you want to exit your account?";
            string caption = "Confirmation needed";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Information;

            //store message box result
            confirmCheck = MessageBox.Show(message, caption, buttons, icon);

            //close form if user clicks yes on the dialog
            if(confirmCheck == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        //button which updates balance shows the withdraw options on click
        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            showBalance();
            updateBalance();
            showPresets();
        }

        //button which hides the withdraw options on click
        private void btnBack_Click(object sender, EventArgs e)
        {
            hideBalance();
            hidePresets();
            hideWithdraw();
        }

        //functions which enter numbers into the withdraw text box on click
        //enters a 1
        private void btn1_Click(object sender, EventArgs e)
        {
            txtWithdraw.Text += '1';
        }

        //enters a 2
        private void btn2_Click(object sender, EventArgs e)
        {
            txtWithdraw.Text += '2';
        }

        //enters a 3
        private void btn3_Click(object sender, EventArgs e)
        {
            txtWithdraw.Text += '3';
        }

        //enters a 4
        private void btn4_Click(object sender, EventArgs e)
        {
            txtWithdraw.Text += '4';
        }

        //enters a 5
        private void btn5_Click(object sender, EventArgs e)
        {
            txtWithdraw.Text += '5';
        }

        //enters a 6
        private void btn6_Click(object sender, EventArgs e)
        {
            txtWithdraw.Text += '6';
        }

        //enters a 7
        private void btn7_Click(object sender, EventArgs e)
        {
            txtWithdraw.Text += '7';
        }

        //enters a 8
        private void btn8_Click(object sender, EventArgs e)
        {
            txtWithdraw.Text += '8';
        }

        //enters a 9
        private void btn9_Click(object sender, EventArgs e)
        {
            txtWithdraw.Text += '9';
        }

        //enters a 0
        private void btn0_Click(object sender, EventArgs e)
        {
            txtWithdraw.Text += '0';
        }

        //button which clears the withdraw text box when clicked
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtWithdraw.Text = "";
        }

        //function which withdraws money from the current account using an input parameter
        private void withdraw(int num)
        {
       
            //declare and initalise a new thread, passing the function from the static bank class which simulates work
            Thread thread = new Thread(Bank.semaphoreFunction);

            //start semaphoreFunction on the thread
            thread.Start();

            //runs the withdraw function from the bank class and compares the boolean value it returns
            if (Bank.withdraw(accStoreNum, num) == true)
            {
                updateBalance();
                //if true, balance will have decreased
            }
            //else if false, balance will not have decreased and an error message will show instead
            else
            {
                MessageBox.Show("You do not have that amount of money in your account.  Money has not been withdrawn.", "Not enough money", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //updates the balance on the form regardless if money was able to be withdrawn
            //this is because money can be withdrawn from another atm accessing the same account
            updateBalance();
        }

        //button which withdraws the entered amount from the account and updates the displayed balance
        private void btnEnter_Click(object sender, EventArgs e)
        {
            //declare local int variable
            int withdrawNum = 0;

            //check withdraw box is not empty
            if(txtWithdraw.Text != "")
            {
                //parse input and store in local variable
                withdrawNum = Int32.Parse(txtWithdraw.Text);
                withdraw(withdrawNum);
                //clear text entry
                txtWithdraw.Text = "";
                //go back to ATM menu
                hideBalance();
                hidePresets();
                hideWithdraw();
            }
            //if no amount is input to withdraw, display an error message
            else
            {
                MessageBox.Show("You must enter an amount to withdraw from your Account!", "Invald Entry!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblBalance_Click(object sender, EventArgs e)
        {

        }

        private void lblSymbol2_Click(object sender, EventArgs e)
        {

        }

        //functions which withdraw a preset amount from the account when clicked
        //withdraw 10
        private void btnWith10_Click(object sender, EventArgs e)
        {
            //run withdraw function and pass in value 10
            withdraw(10);
            //go back to ATM menu
            hideBalance();
            hidePresets();
            hideWithdraw();
        }
        
        //withdraw 20
        private void btnWith20_Click(object sender, EventArgs e)
        {
            //run withdraw function and pass in value 20
            withdraw(20);
            //go back to the ATM menu
            hideBalance();
            hidePresets();
            hideWithdraw();
        }

        //withdraw 30
        private void btnWith30_Click(object sender, EventArgs e)
        {
            //run withdraw function and pass in value 30
            withdraw(30);
            //go back to ATM menu
            hideBalance();
            hidePresets();
            hideWithdraw();
        }

        //withdraw 40
        private void btnWith40_Click(object sender, EventArgs e)
        {
            //run withdraw function and pass in value 40
            withdraw(40);
            //go back to ATM menu
            hideBalance();
            hidePresets();
            hideWithdraw();
        }

        //withdraw 50
        private void btnWith50_Click(object sender, EventArgs e)
        {
            //run withdraw function and pass in value 50
            withdraw(50);
            //go back to ATM menu
            hideBalance();
            hidePresets();
            hideWithdraw();
        }

        //withdraw 60
        private void btnWith60_Click(object sender, EventArgs e)
        {
            //run withdraw function and pass in value 60
            withdraw(60);
            //go back to ATM menu
            hideBalance();
            hidePresets();
            hideWithdraw();
        }

        //withdraw 100
        private void btnWith100_Click(object sender, EventArgs e)
        {
            //run withdraw function and pass in value 100
            withdraw(100);
            //go back to ATM menu
            hideBalance();
            hidePresets();
            hideWithdraw();
        }

        //button which hides the preset buttons and shows the custom entry keypad when clicked
        private void btnWithOther_Click(object sender, EventArgs e)
        {
            //hide preset buttons
            hidePresets();
            //show custom input buttons
            showWithdraw();
        }

        //function which updates the balance
        public void updateBalance()
        {
            txtBalance.Text = Bank.accountStore[accStoreNum].getBalance().ToString();
        }

        //function which updates and displays the current balance, and hides the menu buttons when clicked
        private void btnUpdateBal_Click(object sender, EventArgs e)
        {
            updateBalance();
            showBalance();
            btnWithdraw.Hide();
            btnCheckBal.Hide();
            btnBack.Show();
        }

        private void pb50_Click(object sender, EventArgs e)
        {

        }

        private void lblWithdraw_Click(object sender, EventArgs e)
        {

        }

        private void txtWithdraw_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblSymbol1_Click(object sender, EventArgs e)
        {

        }

        private void pbOther_Click(object sender, EventArgs e)
        {

        }
    }
}
