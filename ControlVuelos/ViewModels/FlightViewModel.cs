using ControlVuelos.Core;
using ControlVuelos.Core.Commands;
using ControlVuelos.Models;
using ControlVuelos.Repositories;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;


namespace ControlVuelos.ViewModels
{
    //se hereda de viewmodelbase para poder tener acceso a la implemetancion de RaisePropertyChanged para la actualizacion de cambios
    public class FlightViewModel : ViewModelBase
    {
        //se inicializa la lista de vuelos
        private VueloCollection _listaVuelos = new VueloCollection();
        public VueloCollection ListaVuelos
        {
            get { return _listaVuelos; }
            set
            {
                _listaVuelos = value;
                //
                if (value != null && value.Count > 0)
                {
                    CurrentVuelo = value[0];
                }
                RaisePropertyChanged("ListaVuelos");
            }
        }

        //se crea un obj para  que cuando se seleccione en el listbox este quede asignado a la variable _currentVuelo asi poder manipularlo
        private flightModel _currentVuelo;
        public flightModel CurrentVuelo
        {
            get { return _currentVuelo; }
            set
            {
                _currentVuelo = value;
                RaisePropertyChanged("CurrentVuelo");
                
            }
        }
        //command para devolver la lista
        private ICommand _listarVuelosCommand;
        public ICommand ListarVuelosCommand
        {
            get
            {
                if (_listarVuelosCommand == null)
                    _listarVuelosCommand = new RelayCommand(new Action(ListarVuelos));
                return _listarVuelosCommand;
            }
        }
       

        private ICommand _infoVuelo2Command;
        public ICommand InfoVuelo2Command
        {
            get
            {
                if (_infoVuelo2Command == null)
                    _infoVuelo2Command = new ParamCommand(new Action<object>(InfoVuelo));
                return _infoVuelo2Command;
            }
        }

        private ICommand _eliminarVueloCommand;
        public ICommand EliminarVueloCommand
        {
            get
            {
                if (_eliminarVueloCommand == null)
                    _eliminarVueloCommand = new ParamCommand(new Action<object>(EliminarVuelo));
                return _eliminarVueloCommand;
            }
        }
        private ICommand _addFlightCommand;
        public ICommand AddFlightCommand
        {
            get
            {
                if (_addFlightCommand == null)
                    _addFlightCommand = new ParamCommand(new Action<object>(AddFlight));
                return _addFlightCommand;
            }
        }

        private static FlightRepository _dbConnector = new FlightRepository();
        public static FlightRepository DbConnector
        {
            get { return _dbConnector; }
        }

        private void ListarVuelos()
        {

            ListaVuelos = DbConnector.listarVuelos();
           
        }
   
        private void InfoVuelo(object obj)
        {
            if (obj != null)
            {
                CurrentVuelo = (flightModel)obj;
                MessageBox.Show("Origen: " + CurrentVuelo.Origen + "\n" +
                                "Destino: " + CurrentVuelo.Destino + "\n" +
                                "Fecha: " + CurrentVuelo.Fecha + "\n" +
                                "Hora Salida: " + CurrentVuelo.Salida + "\n" +
                                "Hora Llegada: " + CurrentVuelo.LLegada + "\n" +
                                "Numero Vuelo: " + CurrentVuelo.NumVuelo + "\n" +
                                "Aerolinea: " + CurrentVuelo.Aerolinea + "\n" +
                                "Estado: " + CurrentVuelo.Estado + "\n");
            }
        }
        private void EliminarVuelo(object obj)
        {
            if (obj != null)
            {
                CurrentVuelo = (flightModel)obj;
                if (DbConnector.eliminarVuelo(CurrentVuelo))
                {
                    if (MessageBox.Show("Eliminado " + CurrentVuelo.NumVuelo) == MessageBoxResult.OK)
                    {
                        ListaVuelos.Remove(CurrentVuelo);
                    }


                }
            }

        }

        private void AddFlight(object obj)
        {
        }
        
        public FlightViewModel()
        {

        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }

        private string _origen;
        public string Origen
        {
            get
            {
                return _origen;
            }
            set
            {
                _origen = value;
                RaisePropertyChanged(nameof(_origen));
            }
        }
        
        private string _destino;
        public string Destino
        {
            get
            {
                return _destino;
            }
            set
            {
                _destino = value;
                RaisePropertyChanged(nameof(_destino));
            }
        }
       
        private string _fecha;
        public string Fecha
        {
            get
            {
                return _fecha;
            }
            set
            {
                _fecha = value;
                RaisePropertyChanged(nameof(_fecha));
            }
        }
        
        private string _salida;

        public string Salida
        {
            get
            {
                return _salida;
            }
            set
            {
                _salida = value;
                RaisePropertyChanged(nameof(_salida));
            }
        }
        
        private string _llegada;
        public string Llegada
        {
            get
            {
                return _llegada;
            }
            set
            {
                _llegada = value;
                RaisePropertyChanged(nameof(_llegada));
            }
        }
        
        private string _aerolinea;
        public string Aerolinea
        {
            get
            {
                return _aerolinea;
            }
            set
            {
                _aerolinea = value;
                RaisePropertyChanged(nameof(_aerolinea));
            }
        }
       

        private string _estado;
        public string Estado
        {
            get
            {
                return _estado;
            }
            set
            {
                _estado = value;
                RaisePropertyChanged(nameof(_estado));
            }
        }
        
    }
}
