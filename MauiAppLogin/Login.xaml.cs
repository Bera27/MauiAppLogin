namespace MauiAppLogin;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		try
		{

			List<DadosUsuario> listaUsuario = new List<DadosUsuario>()
			{
				new DadosUsuario()
				{
					Usuario = "gabriel",
					Senha = "123"
				},

				new DadosUsuario()
				{
					Usuario = "bruno",
					Senha = "321"
				}
			};

			DadosUsuario dadosDigitados = new DadosUsuario()
			{
				Usuario = txt_usuario.Text,
				Senha = txt_senha.Text
			};

			if(listaUsuario.Any
				(i => dadosDigitados.Usuario == i.Usuario && dadosDigitados.Senha == i.Senha))
			{
				await SecureStorage.Default.SetAsync("usuarioLogado", dadosDigitados.Usuario);

				App.Current.MainPage = new Protegida();
			} else
			{
				throw new Exception("Usuário ou Senha incorretos.");
			}

		} catch (Exception ex)
		{
			await DisplayAlert("Ops", ex.Message, "Fechar");
		}
    }
}