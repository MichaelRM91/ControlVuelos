using System.ComponentModel;

namespace ControlVuelos
{
    //nos permite transmitir los cambios de los objetos a las interfaces graficas INotifyPropertyChanged
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
