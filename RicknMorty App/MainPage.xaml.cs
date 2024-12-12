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
    }

}
