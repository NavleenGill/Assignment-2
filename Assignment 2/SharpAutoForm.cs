using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_2
{
    /// <summary>
    /// Class to Calculate the price of vehicle
    /// </summary>
    public partial class SharpAutoForm : Form
    {
        //Private variables
        private double _basePrice;
        private double _additionalOption;
        private double _subTotal;
        private double _salesTax;
        private double _total;
        private double _allowance;
        private double _amountDue;

        /// <summary>
        /// Constructor of Class
        /// </summary>
        public SharpAutoForm()
        {
            InitializeComponent();

            this.CenterToScreen();// show the form at center of screen

              _basePrice=0;
              _additionalOption=0;
              _subTotal=0;
              _salesTax=0;
              _total=0;
              _allowance=0;
              _amountDue=0;
              
        }

        /// <summary>
        /// Event Handler for button "about" click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This program calculates the amount due on a New or Used Vehicle ", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        // Function to calculate the price of Vehicle
        /// <summary>
        /// Event Handler to calcualate the price of vehicle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calculatePriceButton_Click(object sender, EventArgs e)
        {
            // Initialize to zero
             _additionalOption = 0;
             _basePrice = 0;
             _allowance = 0;
             _total = 0;

            //Check if values are valid in textbox
            if (ValidateTextbox())
            {
                if (additionalOptionTextbox.Text != "") // Get value of additionalOptions from textbox
                    _additionalOption = double.Parse(additionalOptionTextbox.Text);
                else
                    _additionalOption = 0;

                // Get value of base price from textbox
                _basePrice = double.Parse(basePriceTextbox.Text);

                //Calulate and display sub Total
                _subTotal = _additionalOption + _basePrice;
                subTotalTextbox.Text = _subTotal.ToString();

                // Calculate tax and update total
                _total = calculateTax();
                totalTextbox.Text = _total.ToString();

                // Calculate and display amount due 
                _allowance = Double.Parse(allowanceTextbox.Text);
                _amountDue=_total - _allowance;
                amountDueTextbox.Text = _amountDue.ToString();
                
            }
            else
            {
                MessageBox.Show("Please enter valid input. ", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
         
        /// <summary>
        /// Function to calculate tax and return the total
        /// </summary>
        /// <returns></returns>
        private double calculateTax()
        {
             _subTotal = 0;
             _total = 0;
             _subTotal = double.Parse( subTotalTextbox.Text);
             salesTaxTextbox.Text = _subTotal.ToString();
            _salesTax=_subTotal * 0.13;
            _total = _subTotal - _salesTax;  //Calculating for 13% of Sales Tax
            return _total;
            
        }

        // Function to validate the valid price in textbox
        /// <summary>
        /// Function to validate the values of textbox
        /// </summary>
        /// <returns>return true if textbox have valid values else return false</returns>
        private bool ValidateTextbox()
        {
            double tempBasePrice,tempTradeInAllowance;

            //Check if base price and allowance contains the valid price 
            if (double.TryParse(basePriceTextbox.Text, out tempBasePrice))
            {
                if (double.TryParse(allowanceTextbox.Text, out tempTradeInAllowance))
                {
                    return true;
                }
            }

            return false;
        }

        
        /// <summary>
        /// Event Handler for to add price to "Additional Options" for stereo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stereoCheckbox_CheckedChanged(object sender, EventArgs e)
        {
              _additionalOption=0;

            // CHeck if stereo is checked or not
            if(stereoCheckbox.Checked)
            {
                //If current Additional Option is empty
                if (additionalOptionTextbox.Text == "")
                {
                     
                    _additionalOption = 425.76;
                    additionalOptionTextbox.Text = _additionalOption.ToString();
                }
                else
                {
                    _additionalOption = Double.Parse(additionalOptionTextbox.Text);
                    _additionalOption += 425.76;
                    additionalOptionTextbox.Text = _additionalOption.ToString();
                }


            }
            else  
            {
                
                    _additionalOption = Double.Parse(additionalOptionTextbox.Text);
                    _additionalOption -= 425.76;
                    additionalOptionTextbox.Text = _additionalOption.ToString();

            }

           
        }
       
        
        /// <summary>
        /// Event Handler to add price to "Additional Options" for computer Navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void computerNavigCheckCheckedChanged(object sender, EventArgs e)
        {
              _additionalOption = 0;

            if (computerNavigCheck.Checked)
            {
                if (additionalOptionTextbox.Text == "")
                {
                    
                    _additionalOption = 1741.23;
                    additionalOptionTextbox.Text = _additionalOption.ToString();
                }
                else
                {
                    _additionalOption = Double.Parse(additionalOptionTextbox.Text);
                    _additionalOption += 1741.23;
                    additionalOptionTextbox.Text = _additionalOption.ToString();
                }


            }
            else
            {
                _additionalOption = Double.Parse(additionalOptionTextbox.Text);
                _additionalOption -= 1741.23;
                additionalOptionTextbox.Text = _additionalOption.ToString();

            }

           
        }
       
        
        /// <summary>
        /// Event Handler for "Additional Options" for Leather Interior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void leatherInterCheckbox_CheckedChanged(object sender, EventArgs e)
        {
              _additionalOption = 0;

            if (leatherInterCheckbox.Checked)
            {
                if (additionalOptionTextbox.Text == "")
                {
                    
                    _additionalOption = 987.41;
                    additionalOptionTextbox.Text = _additionalOption.ToString();
                }
                else
                {
                    _additionalOption = Double.Parse(additionalOptionTextbox.Text);
                    _additionalOption += 987.41;
                    additionalOptionTextbox.Text = _additionalOption.ToString();
                }


            }
            else
            {
                _additionalOption = Double.Parse(additionalOptionTextbox.Text);
                _additionalOption -= 987.41;
                additionalOptionTextbox.Text = _additionalOption.ToString();

            }

        }
       
         
        /// <summary>
        /// Event Handler for pearlized Radio Button 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pearlizedRadio_CheckedChanged(object sender, EventArgs e)
        {
              _additionalOption = 0;

            if (pearlizedRadio.Checked)
            {
                if (additionalOptionTextbox.Text == "")
                {

                    _additionalOption = 345.72;
                    additionalOptionTextbox.Text = _additionalOption.ToString();
                }
                else
                {
                    _additionalOption = Double.Parse(additionalOptionTextbox.Text);
                    _additionalOption += 345.72;
                    additionalOptionTextbox.Text = _additionalOption.ToString();
                }


            }
            else
            {
                _additionalOption = Double.Parse(additionalOptionTextbox.Text);
                _additionalOption -= 345.72;
                additionalOptionTextbox.Text = _additionalOption.ToString();

            }

        }
       
       /// <summary>
       /// Event Handler for customized Radio Button
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void customizedRadio_CheckedChanged(object sender, EventArgs e)
        {
              _additionalOption = 0;

            if (customizedRadio.Checked)
            {
                if (additionalOptionTextbox.Text == "")
                {

                    _additionalOption = 599.99;
                    additionalOptionTextbox.Text = _additionalOption.ToString();
                }
                else
                {
                    _additionalOption = Double.Parse(additionalOptionTextbox.Text);
                    _additionalOption += 599.99;
                    additionalOptionTextbox.Text = _additionalOption.ToString();
                }


            }
            else
            {
                _additionalOption = Double.Parse(additionalOptionTextbox.Text);
                _additionalOption -= 599.99;
                additionalOptionTextbox.Text = _additionalOption.ToString();

            }
        }

        /// <summary>
        /// Event Handler for clear all the fields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearPriceButton_Click(object sender, EventArgs e)
        {
            // Clear all textboxes
            basePriceTextbox.Text = "";
            subTotalTextbox.Text = "";
            salesTaxTextbox.Text = "";
            totalTextbox.Text = "";
            allowanceTextbox.Text = "0";
            amountDueTextbox.Text = "";

            // Uncheck all the check box and select radio button of "standard"
            stereoCheckbox.Checked = false;
            computerNavigCheck.Checked = false;
            leatherInterCheckbox.Checked = false;
            pearlizedRadio.Checked = false;
            customizedRadio.Checked = false;
            standardRadio.Checked = true;
        }
    
        /// <summary>
        ///  Event Handler for exit button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitPriceButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Event Handler for font button click menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            DialogResult result = fontDialog.ShowDialog();  // Show the font dialog and get the result
            
            if (result == DialogResult.OK)  // Check if font dialog return OK result
            {
                
                //Setting font of base price and amount due textbox
                Font font = fontDialog.Font;
                amountDueTextbox.Font = font;
                basePriceTextbox.Font = font;
            }
        }

        /// <summary>
        /// Event Handler for color button click in menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Show the color dialog
            ColorDialog colorDialog = new ColorDialog();

            //Check if dialog return OK result
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                //Set the font color of base price and amount due text box
                amountDueTextbox.ForeColor = colorDialog.Color;
                basePriceTextbox.ForeColor = colorDialog.Color;
                 
            }
        }
     
 
    }
}
