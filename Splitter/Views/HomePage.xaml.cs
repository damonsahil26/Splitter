namespace Splitter.Views;

public partial class HomePage : ContentPage
{
    decimal totalBillVal;
    decimal tip;
    int noOfPersons = 1;
    decimal subtotal;
    decimal tipPercent;
    bool isTipChanged;

	public HomePage()
	{
		InitializeComponent();
	}

    private void Bill_Entry_Completed(object sender, EventArgs e)
    {
        totalBillVal = int.Parse(Bill_Entry.Text);
        CalculateTotal();
    }

    private void CalculateTotal()
    {
        if (isTipChanged)
        {
            CalculateTip();
            totalBillVal += tip;
        }

        CalculateSubtotal();
        SetLabelTexts();
    }

    private void SetLabelTexts()
    {
        lbl_totalBill.Text = totalBillVal.ToString("c");
        lbl_subtotal_val
            .Text = subtotal.ToString("c");
        lbl_tip_val .Text = tip.ToString("c");
        lbl_frame_tip_val.Text = tip.ToString("c");

    }

    private void CalculateTip()
    {
        var calc = tipPercent / 100;
        tip = totalBillVal * calc;
    }

    private void CalculateSubtotal()
    {
        subtotal = totalBillVal / noOfPersons;
    }

    private void btn_inc_persons_Clicked(object sender, EventArgs e)
    {
        if(noOfPersons < 10)
        {
            noOfPersons+=1;
        }
        setNoOfPersonsLabel();
    }

    private void btn_dec_persons_Clicked(object sender, EventArgs e)
    {
        if (noOfPersons > 1)
        {
            noOfPersons -= 1;
        }
        setNoOfPersonsLabel();
    }
    
    private void setNoOfPersonsLabel()
    {
        lbl_no_of_persons.Text= noOfPersons.ToString();
        CalculateTotal();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        isTipChanged = true;
        if(sender is Button)
        {
           var button = (Button)sender;

           tipPercent = int.Parse(button.Text.Replace("%", ""));
        }

        CalculateTotal();
        isTipChanged=false;
    }

    private void slider_tip_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        isTipChanged = true;
        tipPercent = (int)slider_tip.Value;

        CalculateTotal();
        isTipChanged = false;
    }
}