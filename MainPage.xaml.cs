namespace kerem_küçük_ödev
{
    public partial class MainPage : ContentPage
    {

        private double value = 0;
        private double newvalue = 0;
        private string operation = null;
        private bool newentry = true;

        public MainPage()
        {
            InitializeComponent();
        }


        private void OnOperationClicked(object sender, EventArgs e)
        {
            if (double.TryParse(NumberEntry.Text, out double enteredValue))
            {
                if (operation != null)
                {
                    value = Calculate(value, enteredValue, operation);
                }
                else
                {
                    value = enteredValue;
                }
                operation = (sender as Button).Text;
                OperationLabel.Text = $"{value} {operation}";
                NumberEntry.Text = string.Empty;
                newentry = true;
            }
        }

        private void OnEqualsClicked(object sender, EventArgs e)
        {
            if (operation != null && double.TryParse(NumberEntry.Text, out double enteredValue))
            {
                newvalue = Calculate(value, enteredValue, operation);
                NumberEntry.Text = newvalue.ToString();
                OperationLabel.Text = string.Empty;
                ResetCalculator();
            }
        }

        private double Calculate(double first, double second, string operation)
        {
            return operation switch
            {
                "+" => first + second,
                "-" => first - second,
                "×" => first * second,
                "/" => second != 0 ? first / second : 0,
                _ => 0
            };
        }

        private void ResetCalculator()
        {
            value = 0;
            newvalue = 0;
            operation = null;
            newentry = true;
        }


    }

}
