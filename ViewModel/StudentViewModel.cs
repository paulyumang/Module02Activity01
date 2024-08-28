using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module02Activity01.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Module02Activity01.ViewModel
{
    public class StudentViewModel : INotifyPropertyChanged
    {
        //Role of ViewModel
        private Student _student;
        private string _fullname; //variable to combine the FirstName and LastName into one, using Conversion

        public StudentViewModel()
        {
            //Initial Sample Student Model. Coordination with Model
            _student = new Student { FirstName="John", LastName="Doe", Age=23};

            //UI Thread Management
            LoadStudentDataCommand = new Command(async () => await LoadStudentDataAsync());

            //Collections
            Students = new ObservableCollection<Student>
            {
                new Student {FirstName = "Jane", LastName = "Smith", Age = 24},
                new Student {FirstName = "Juan", LastName = "Dela Cruz", Age = 25},
                new Student {FirstName = "Pedro", LastName = "Penduko", Age = 26}
            };
        }

        //Setting collections in public
        public ObservableCollection<Student> Students { get; set; }

        public string FullName
        {
            get => _fullname;
            set
            {
                if (_fullname != value)
                {
                    _fullname = value;
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }

        //UI Thread Management
        public ICommand LoadStudentDataCommand { get; }

        //Tow-way Data Bind amd Data Conversion
        private async Task LoadStudentDataAsync()
        {
            await Task.Delay(1000); // I/O operation
            FullName = $"{_student.FirstName} {_student.LastName}"; //Data Conversion for FirstName and LastName
        
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) 
        { 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
    }
}
