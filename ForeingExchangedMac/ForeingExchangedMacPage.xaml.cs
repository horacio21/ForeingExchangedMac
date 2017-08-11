using Xamarin.Forms;

namespace ForeingExchangedMac
{
    public partial class ForeingExchangedMacPage : ContentPage
    {
        public ForeingExchangedMacPage()
        {
            InitializeComponent();

            ConvertButton.Clicked += ConvertButton_Clicked; 
        }

        void ConvertButton_Clicked(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(PesosEntry.Text))
            {
                DisplayAlert("Error", "You must enter a value in pesos...", "Acept");
                return;
            }

            decimal pesos = 0;

            if (!decimal.TryParse(PesosEntry.Text, out pesos))
            {
				DisplayAlert("Error", "You must enter a numeric   value in pesos...", "Acept");
                PesosEntry.Text = null;
				return;
			}

            var dollars = pesos / 47.4991688M;
			var euros = pesos / 56.1646796M;
			var pounds = pesos / 61.6064219M;

            DollarsEntry.Text = string.Format("${0:N2}", dollars);
            EurosEntry.Text = string.Format("€{0:N2}", euros);
            PoundsEntry.Text = string.Format("£{0:N2}", pounds);
		}
    }
}
