namespace MauiTest;

public partial class App : Application
{
	public static PersonRepository _personRepo { get; private set; }
	public App(PersonRepository PersonRepo)
	{
		InitializeComponent();

		MainPage = new AppShell();

		_personRepo = PersonRepo;
	}
}
