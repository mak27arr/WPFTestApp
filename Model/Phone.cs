using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFTestApp.Model
{
    public class Phone : INotifyPropertyChanged
    {
        private string _title;
        private string _company;
        private int _price;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(this.Title));
            }
        }
        public string Company
        {
            get { return _company; }
            set
            {
                _company = value;
                OnPropertyChanged(nameof(this.Company));
            }
        }
        public int Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged(nameof(this.Price));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
