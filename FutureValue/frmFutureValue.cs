using System;
using System.Windows.Forms;

namespace FutureValue
{
    public partial class frmFutureValue : Form
    {
        public frmFutureValue()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            decimal monthlyInvestment;
            decimal yearlyInterestRate;
            int years;

            if (!Decimal.TryParse(txtMonthlyInvestment.Text, out monthlyInvestment))
            {
                MessageBox.Show("Please enter a valid decimal value for monthly investment.");
                txtMonthlyInvestment.Focus();
                return;
            }

            if (!Decimal.TryParse(txtInterestRate.Text, out yearlyInterestRate))
            {
                MessageBox.Show("Please enter a valid decimal value for interest rate.");
                txtInterestRate.Focus();
                return;
            }

            if (!Int32.TryParse(txtYears.Text, out years))
            {
                MessageBox.Show("Please enter a valid integer value for years.");
                txtYears.Focus();
                return;
            }

            int months = years * 12;
            decimal monthlyInterestRate = yearlyInterestRate / 12 / 100;

            decimal futureValue = 0m;
            for (int i = 0; i < months; i++)
            {
                futureValue = (futureValue + monthlyInvestment)
                            * (1 + monthlyInterestRate);
            }

            txtFutureValue.Text = futureValue.ToString("c");
            txtMonthlyInvestment.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
