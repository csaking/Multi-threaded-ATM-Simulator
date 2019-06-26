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
    public partial class frmMenu : Form
    {
        //declare and initialise AccountNum and PIN store
        private int AccountNumHold = 0;
        private int PINHold = 0;

        //declare static Bank, which stores the accounts
        static Bank BankStore = new Bank();

        //declare and initialise boolean checker variable
        private bool EntryCheck = false;

        //constructor
        public frmMenu()
        {
            InitializeComponent();

            //setup labels
            lblPin.Hide();
            lblAccountNum.Show();

            //disable control box
            this.ControlBox = false;

            //disable text entry without using buttons
            txtEntry.ReadOnly = true;

            //disable user resizing windows
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

        }

        //function which diplays a generic error message to the user when called
        private void showErrorMessage()
        {
            MessageBox.Show("Account Number must be 6 digits long.  PIN must be 4 digits long.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        //function to check account information and open ATM form
        private void btnEnter_Click(object sender, EventArgs e)
        {
            //declare and initialise boolean check variable
            Boolean accExistsCheck = false;

            //validate Account Number
            if ((EntryCheck == false) && (txtEntry.Text.Length == 6))
            {
                //flip checker variable
                EntryCheck = true;
                //flip labels
                lblAccountNum.Hide();
                lblPin.Show();
                //store account number
                AccountNumHold = Int32.Parse(txtEntry.Text);
                //reset entry box
                txtEntry.Text = "";
            }
            //validate PIN
            else if((EntryCheck == true) && (txtEntry.Text.Length == 4))
            {
                //flip checker variable
                EntryCheck = false;
                //store PIN
                PINHold = Int32.Parse(txtEntry.Text);
                //reset entry text box
                txtEntry.Text = "";
                //flip labels
                lblPin.Hide();
                lblAccountNum.Show();
                //open account in ATM from Bank class if possible and display error message if entered parameters are incorrect
                if (accExistsCheck = BankStore.openATM(AccountNumHold, PINHold) == false)
                {
                    MessageBox.Show("Account is invalid! Make sure you enter the correct Account Number and PIN!", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            //Account Number Entry Error
            else if ((EntryCheck == false) && (txtEntry.Text.Length != 6))
            {
                showErrorMessage();
            }
            //PIN Entry Error
            else if ((EntryCheck == true) && (txtEntry.Text.Length != 4))
            {
                showErrorMessage();
            }
        }

        //function which handles the exit button click
        private void btnExit_Click(object sender, EventArgs e)
        {
            //declare checker variable
            DialogResult confirmCheck;

            //construct message box 
            string message = "Are you sure you want to exit the ATM simulator? Doing so will close and reset all accounts.";
            string caption = "Confirmation needed";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Information;

            //store message box result
            confirmCheck = MessageBox.Show(message, caption, buttons, icon);

            //close form if user clicks yes on the dialog
            if (confirmCheck == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        //functions which handle the input button clicks
        //button that enters 8 into the entry text box 
        private void btn8_Click(object sender, EventArgs e)
        {
            //if entering an account number
            if (EntryCheck == false)
            {
                //check account number has not reached max length
                if (txtEntry.Text.Length < 6)
                {
                    txtEntry.Text += '8';
                }
            }
            //if entering a PIN
            else
            {
                //check PIN has not reached max length
                if (txtEntry.Text.Length < 4)
                {
                    txtEntry.Text += '8';
                }
            }
        }
        //button that enters 1 into the entry text box 
        private void btn1_Click(object sender, EventArgs e)
        {
            //if entering an account number
            if (EntryCheck == false)
            {
                //check account number has not reached max length
                if (txtEntry.Text.Length < 6)
                {
                    txtEntry.Text += '1';
                }
            }
            //if entering a PIN
            else
            {
                //check PIN has not reached max length
                if (txtEntry.Text.Length < 4)
                {
                    txtEntry.Text += '1';
                }
            }
        }
        //button that enters 2 into the entry text box 
        private void btn2_Click(object sender, EventArgs e)
        {
            //if entering an account number
            if (EntryCheck == false)
            {
                //check account number has not reached max length
                if (txtEntry.Text.Length < 6)
                {
                    txtEntry.Text += '2';
                }
            }
            //if entering a PIN
            else
            {
                //check PIN has not reached max length
                if (txtEntry.Text.Length < 4)
                {
                    txtEntry.Text += '2';
                }
            }
        }
        //button that enters 3 into the entry text box 
        private void btn3_Click(object sender, EventArgs e)
        {
            //if entering an account number
            if (EntryCheck == false)
            {
                //check account number has not reached max length
                if (txtEntry.Text.Length < 6)
                {
                    txtEntry.Text += '3';
                }
            }
            //if entering a PIN
            else
            {
                //check PIN has not reached max length
                if (txtEntry.Text.Length < 4)
                {
                    txtEntry.Text += '3';
                }
            }
        }
        //button that enters 4 into the entry text box 
        private void btn4_Click(object sender, EventArgs e)
        {
            //if entering an account number
            if (EntryCheck == false)
            {
                //check account number has not reached max length
                if (txtEntry.Text.Length < 6)
                {
                    txtEntry.Text += '4';
                }
            }
            //if entering a PIN
            else
            {
                //check PIN has not reached max length
                if (txtEntry.Text.Length < 4)
                {
                    txtEntry.Text += '4';
                }
            }
        }
        //button that enters 5 into the entry text box 
        private void btn5_Click(object sender, EventArgs e)
        {
            //if entering an account number
            if (EntryCheck == false)
            {
                //check account number has not reached max length
                if (txtEntry.Text.Length < 6)
                {
                    txtEntry.Text += '5';
                }
            }
            //if entering a PIN
            else
            {
                //check PIN has not reached max length
                if (txtEntry.Text.Length < 4)
                {
                    txtEntry.Text += '5';
                }
            }
        }
        //button that enters 6 into the entry text box 
        private void btn6_Click(object sender, EventArgs e)
        {
            //if entering an account number
            if (EntryCheck == false)
            {
                //check account number has not reached max length
                if (txtEntry.Text.Length < 6)
                {
                    txtEntry.Text += '6';
                }
            }
            //if entering a PIN
            else
            {
                //check PIN has not reached max length
                if (txtEntry.Text.Length < 4)
                {
                    txtEntry.Text += '6';
                }
            }
        }
        //button that enters 7 into the entry text box 
        private void btn7_Click(object sender, EventArgs e)
        {
            //if entering an account number
            if (EntryCheck == false)
            {
                //check account number has not reached max length
                if (txtEntry.Text.Length < 6)
                {
                    txtEntry.Text += '7';
                }
            }
            //if entering a PIN
            else
            {
                //check PIN has not reached max length
                if (txtEntry.Text.Length < 4)
                {
                    txtEntry.Text += '7';
                }
            }
        }
        //button that enters 9 into the entry text box 
        private void btn9_Click(object sender, EventArgs e)
        {
            //if entering an account number
            if (EntryCheck == false)
            {
                //check account number has not reached max length
                if (txtEntry.Text.Length < 6)
                {
                    txtEntry.Text += '9';
                }
            }
            //if entering a PIN
            else
            {
                //check PIN has not reached max length
                if (txtEntry.Text.Length < 4)
                {
                    txtEntry.Text += '9';
                }
            }
        }
        //button that enters 0 into the entry text box 
        private void btn0_Click(object sender, EventArgs e)
        {
            //if entering an account number
            if (EntryCheck == false)
            {
                //check account number has not reached max length
                if (txtEntry.Text.Length < 6)
                {
                    txtEntry.Text += '0';
                }
            }
            //if entering a PIN
            else
            {
                //check PIN has not reached max length
                if (txtEntry.Text.Length < 4)
                {
                    txtEntry.Text += '0';
                }
            }
        }

        //function which handles the clear button click
        private void btnClear_Click(object sender, EventArgs e)
        {
            //clears back to the account number if PIN entry is empty
            if((txtEntry.Text.Length == 0) && (EntryCheck == true))
            {
                EntryCheck = false;
                lblPin.Hide();
                lblAccountNum.Show();
            }
            //clears the entry box without changing entry type
            else
            {
                txtEntry.Text = "";
            }
        }
    }
}
