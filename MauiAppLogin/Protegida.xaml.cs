namespace MauiAppLogin;

public partial class Protegida : ContentPage
{
	public Protegida()
	{
		InitializeComponent();

		string? usuarioLogado = null;

		Task.Run(async () =>
		{
			usuarioLogado = await SecureStorage.Default.GetAsync("usuarioLogado");
			lbl_boaVindas.Text = $"Bem-vindo {usuarioLogado}";
		});
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		bool confirmacao = await DisplayAlert("Tem Certeza?", "Sair do app", "Sim", "N�o");

		if (confirmacao)
		{
			SecureStorage.Default.Remove("usuarioLogado");
			App.Current.MainPage = new Login();
		}
    }
}