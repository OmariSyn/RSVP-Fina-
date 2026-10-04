using static RsV__Application_Final.Models;

namespace RsV__Application_Final
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var userEntry = new UserEntry
            {
                Name = NameEntry.Text,
                Email = EmailEntry.Text,
                Phone = PhoneEntry.Text,
                Notes = NotesEditor.Text
            };

            object operationResult = await App.DatabaseService.GetConnection().InsertAsync(userEntry);
            await DisplayAlert("Success", "Entry saved successfully!", "OK");
        }

        private async void OnViewClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ViewEntriesPage());
        }

        private async void OnSearchClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchEntriesPage());
        }
    }
}