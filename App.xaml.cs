
namespace Calculator
{
    public partial class App : Application
    {
        private const int DEFAULT_WIDTH = 600;
        private const int DEFAULT_HEIGHT = 800;

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);

            window.Width = DEFAULT_WIDTH;
            window.Height = DEFAULT_HEIGHT;

            return window;
        }
    }
}
