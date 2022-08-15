namespace MauiTest;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}
    public void OnNewButtonClicked(object sender, EventArgs args)
    {
        statusMessage.Text = "";

        App._personRepo.AddNewPerson(newPerson.Text);
        statusMessage.Text = App._personRepo.StatusMessage;
    }

    public void OnGetButtonClicked(object sender, EventArgs args)
    {
        statusMessage.Text = "";

        List<Person> people = App._personRepo.GetAllPersons();
        peopleList.ItemsSource = people;
    }
}

