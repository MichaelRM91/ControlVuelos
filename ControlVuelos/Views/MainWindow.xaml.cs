using ControlVuelos.Views;
using System.Windows;

namespace ControlVuelos
{
       public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FlightViews v = new FlightViews();
            v.ShowDialog();
        }

        private void Button_Program(object sender, RoutedEventArgs e)
        {
            ProgramarVueloViews v = new ProgramarVueloViews();
            v.ShowDialog();
        }
    }
}
