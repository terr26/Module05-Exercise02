using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Module07Data_Access.Model;
using Module07Data_Access.Services;

namespace Module07Data_Access.ViewModel
{
    public class PersonalViewModel : INotifyPropertyChanged
    {
        private readonly PersonalService _personalService;
        public ObservableCollection<Personal> PersonalList { get; set; }
        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        private string _statusMessage;
        public string StatusMessage
        {
            get => _statusMessage;
            set
            {
                _statusMessage = value;
                OnPropertyChanged();
            }
        }

        // 

        private string _newPersonalName;

        public string NewPersonalName
        {
            get => _newPersonalName;
            set
            {
                _newPersonalName = value;
                OnPropertyChanged();
            }
        }

        private string _newPersonalGender;

        public string NewPersonalGender
        {
            get => _newPersonalGender;
            set
            {
                _newPersonalGender = value;
                OnPropertyChanged();
            }
        }

        private string _newPersonalContactNo;

        public string NewPersonalContactNo
        {
            get => _newPersonalContactNo;
            set
            {
                _newPersonalContactNo = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadDataCommand { get; }
        public ICommand AddPersonalCommand { get; }

        //PersonalViewModel Constructor

        public PersonalViewModel()
        {
            _personalService = new PersonalService();
            PersonalList = new ObservableCollection<Personal>();
            LoadDataCommand = new Command(async () => await LoadData());
            AddPersonalCommand = new Command(async () => await AddPerson());

            LoadData();
        }
        public async Task LoadData()
        {
            if (IsBusy) return;
            IsBusy = true;
            StatusMessage = "Loading personal data. . .";
            try
            {
                var personals = await _personalService.GetAllPersonalsAsync();
                PersonalList.Clear();
                foreach (var personal in personals)
                {
                    PersonalList.Add(personal);
                }
                StatusMessage = "Data loaded successfully!";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to load data: {ex.Message}";
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task AddPerson()
        {
            if (IsBusy || string.IsNullOrWhiteSpace(NewPersonalName) || string.IsNullOrWhiteSpace(NewPersonalGender) || string.IsNullOrWhiteSpace(NewPersonalContactNo))
            {
                StatusMessage = "Please fill in all fields before adding";
                return;
            }
            IsBusy = true;
            StatusMessage = "Adding new person . . .";

            try
            {
                var newPerson = new Personal
                {
                    Name = NewPersonalName,
                    Gender = NewPersonalGender,
                    ContactNo = NewPersonalContactNo
                };
                var isSuccess = await _personalService.AddPersonalAsync(newPerson);
                if (isSuccess)
                {
                    NewPersonalName = string.Empty;
                    NewPersonalGender = string.Empty;
                    NewPersonalContactNo = string.Empty;
                    StatusMessage = "New person added successfully";
                }
                else
                {
                    StatusMessage = "Failed to add the new person";
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed adding person: {ex.Message}";
            }
            finally
            {
                IsBusy = false;
                await LoadData();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string poropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(poropertyName));
        }
    }
}
