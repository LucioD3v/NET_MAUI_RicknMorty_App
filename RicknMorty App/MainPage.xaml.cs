using RicknMorty_App.Service;

namespace RicknMorty_App
{
    public partial class MainPage : ContentPage
    {
        private readonly IRicknMortyService _service;

        public MainPage(IRicknMortyService service)
        {
            InitializeComponent();
            _service = service;
        }

        private async void OnDataClicked(object sender, EventArgs e)
        {
           loading.IsVisible = true;
            var data = await _service.GetCharactersAsync();
            listViewCharacters.ItemsSource = data;
           loading.IsVisible = false;
        }

        public void OnItemSelectedChanged(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem == null)
                return;

            //Handle the selected item (e.SelectedItem) here
            var selectedCharacter = e.SelectedItem as Models.CharactersModel;

            Application.Current.MainPage.DisplayAlert("Rick n Morty", $"Personaje: {selectedCharacter.name}", "OK");

            // Clear the selection
            ((ListView)sender).SelectedItem = null;
        }
    }
}
