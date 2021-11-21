using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WPFTestApp.Command;
using WPFTestApp.Mock;
using WPFTestApp.Model;

namespace WPFTestApp.ViewModel
{
    public class PhoneViewModel : INotifyPropertyChanged
    {
        private Phone _selectedPhone;
        private IRepository<Phone> _phoneRepository;
        private RelayCommand _addCommand;
        private RelayCommand _removeCommand;

        public ObservableCollection<Phone> Phones { get; set; }
        public Phone SelectedPhone
        {
            get { return _selectedPhone; }
            set
            {
                _selectedPhone = value;
                OnPropertyChanged(nameof(this.SelectedPhone));
            }
        }

        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ??
                       (_addCommand = new RelayCommand(obj =>
                       {
                           Phone phone = new Phone();
                           _phoneRepository.Add(phone);
                           Phones.Insert(0, phone);
                           SelectedPhone = phone;
                       }));
            }
        }

        public RelayCommand RemoveCommand
        {
            get
            {
                return _removeCommand ??
                       (_removeCommand = new RelayCommand(obj =>
                           {

                               if (obj is Phone phone)
                                   Phones.Remove(phone);
                           }, (obj) => Phones.Count > 0));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public PhoneViewModel()
        {
            _phoneRepository = new PhoneRepositoryMock();
            var phoneList = _phoneRepository.List();
            Phones = new ObservableCollection<Phone>(phoneList); 
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
