namespace MauiAppLogin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            string? usuarioLogado = null;

            Task.Run(async () =>
            {
                usuarioLogado = await SecureStorage.Default.GetAsync("usuarioLogado");

                if(usuarioLogado == null)
                {
                    MainPage = new Login();
                } else
                {
                    MainPage = new Protegida();
                }
            });

            MainPage = new Login();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);

            window.Width = 400;
            window.Height = 700;

            return window;
        }
    }
}