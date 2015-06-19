using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace HuePlay.ViewModels
{
    class ColourCanvasViewModel : INotifyPropertyChanged
    {
        private SolidColorBrush _selectedColour;
        public SolidColorBrush SelectedColour
        {
            get { return _selectedColour; }
            set
            {
                if (_selectedColour != value)
                {
                    _selectedColour = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
