using ControlVuelos.Models;
using System;
using System.Windows;


namespace ControlVuelos.Views
{
    /// <summary>
    /// Lógica de interacción para ProgramarVueloViews.xaml
    /// </summary>

    public partial class ProgramarVueloViews : Window
    {
        public ProgramarVueloViews()
        {
            InitializeComponent();
        }

        public void limpiarDatos()
        {
            origen_txt.Clear();
            destino_txt.Clear();
            fecha_txt.SelectedDate = null;
            salida_txt.Clear();
            llegada_txt.Clear();
            numVuelo_txt.Clear();
            aerolinea_txt.Clear();
            estado_txt.Clear();
        }
       
        private void LimpiarBtn_Click(object sender, RoutedEventArgs e)
        {
            limpiarDatos();
        }

        
    }
}
