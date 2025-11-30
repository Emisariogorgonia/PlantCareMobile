namespace PlantCareMobile.Views;

public partial class WelcomePage : ContentPage
{
	public WelcomePage()
	{
		InitializeComponent();
	}

    private async void loginButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("LoginPage");
    }

    private async void registerButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("RegisterPage");

    }
}