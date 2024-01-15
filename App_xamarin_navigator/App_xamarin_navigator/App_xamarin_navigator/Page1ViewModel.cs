using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App_xamarin_navigator
{
    class Page1ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;



        public float X;
        public float Y;
        public string Name;
        public string Result;
        public bool _isMale;
        public bool _isFemale;

        public bool IsMale
        {
            get => _isMale;
            set
            {
                if (_isMale != value)
                {
                    _isMale = value;
                    var arg = new PropertyChangedEventArgs(nameof(IsMale));
                    PropertyChanged?.Invoke(this, arg);
                }
            }
        }

        public bool IsFemale
        {
            get => _isFemale;
            set
            {
                if (_isFemale != value)
                {
                    _isFemale = value;
                    var arg = new PropertyChangedEventArgs(nameof(IsFemale));
                    PropertyChanged?.Invoke(this, arg);
                }
            }
        }

        public float x
        {
            get => X;
            set
            {
                X = value;
                var arg = new PropertyChangedEventArgs(nameof(x));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        public float y
        {
            get => Y;
            set
            {
                Y = value;
                var arg = new PropertyChangedEventArgs(nameof(y));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        public string result
        {
            get => Result;
            set
            {
                if (Result != value)
                {
                    Result = value;
                    var arg = new PropertyChangedEventArgs(nameof(result));
                    PropertyChanged?.Invoke(this, arg);
                }
            }
        }

        public string name
        {
            get => Name;
            set
            {
                if (Name != value)
                {
                    Name = value;
                    var arg = new PropertyChangedEventArgs(nameof(name));
                    PropertyChanged?.Invoke(this, arg);
                }
            }
        }
        public Command SubMitCommand { get; set; }
        public Command CanCelCommand { get; set; }





        public Page1ViewModel()
        {

            result = "X * Y =?";

            SubMitCommand = new Command(() =>
            {
                float sum = x * y;
                string gender = IsMale ? "Male" : (IsFemale ? "Female" : "No Select choice");
                result = name + "\r\nX * Y = " + sum.ToString() + "\r\n" + gender;
            });

            CanCelCommand = new Command(() =>
            {
                this.x = 0;
                this.y = 0;
                this.name = "";
                this.IsMale = false;
                this.IsFemale = false;
                this.result = "X * Y =?";
            });
        }
    }


}