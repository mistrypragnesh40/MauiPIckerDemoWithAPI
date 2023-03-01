namespace DropDownDemoWithAPI;

public partial class App : Application
{
	public static string BaseUrl = "https://www.universal-tutorial.com/api";
    public static string Token = "";

    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
