using System;
using System.Collections.ObjectModel;

namespace ControlVuelos.Models
{
    //para setear la lista de personas en MVVM es recomendable la clase ObservableCollection
    public class VueloCollection : ObservableCollection<flightModel>
    {

    }
    //fin clase  de colleccion
    public class flightModel
    {
        private string _id;
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _origen;
        public string Origen
        {
            get { return _origen; }
            set { _origen = value; }
        }

        private string _destino;
        public string Destino
        {
            get { return _destino; }
            set { _destino = value; }
        }

        private string _fecha;
        public string Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        private string _salida;
        public string Salida
        {
            get { return _salida; }
            set { _salida = value; }
        }

        private string _llegada;
        public string LLegada
        {
            get { return _llegada; }
            set { _llegada = value; }
        }

        private string _numVuelo;
        public string NumVuelo
        {
            get { return _numVuelo; }
            set { _numVuelo = value; }
        }

        private string _aerolinea;
        public string Aerolinea
        {
            get { return _aerolinea; }
            set { _aerolinea = value; }
        }

        private string _estado;
        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public flightModel()
        {

        }
        public flightModel(string id, string origen, string numVuelo)
        {
            Id = id;
            Origen = origen;
            NumVuelo = numVuelo;
        }

        public flightModel(string id, string origen, string destino, string fecha, string salida, string llegada, string numVuelo, string aerolinea, string estado)
        {
            Id = id;
            Origen = origen;
            Destino = destino;
            Fecha = fecha;
            Salida = salida;
            LLegada = llegada;
            NumVuelo = numVuelo;
            Aerolinea = aerolinea;
            Estado = estado;

        }

        public override string ToString()
        {
            return NumVuelo;
        }

    }
}