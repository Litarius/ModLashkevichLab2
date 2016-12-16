using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Lab2.ViewModel
{
    public class ExponentialControlViewModel : ViewModelBase
    {
        private Random rnd = new Random();
        private double _p;
        private int _count;
        private string _result;

        public ExponentialControlViewModel()
        {
            _p = 40;
            Count = 1000;
            CalculateCommand = new RelayCommand(ExecuteCalculateCommand);
        }


        public double P
        {
            get { return _p; }
            set
            {
                _p = value;
                RaisePropertyChanged(() => P);
            }
        }

        public int Count
        {
            get { return _count; }
            set { _count = value; RaisePropertyChanged(() => Count); }
        }

        public string Result
        {
            get { return _result; }
            set { _result = value; RaisePropertyChanged(() => Result); }
        }

        private void Calculate()
        {
            var randomArray = new List<double>();
            for (var i = 0; i < Count; i++)
            {
                randomArray.Add(-Math.Log(rnd.NextDouble()) / P);
            }

            Result += "Математическое ожидание: " + 1 / P + "\n";
            Result += "Дисперсия: " + 1 / P;

            MainViewModel.Calculate(randomArray);
        }

        public RelayCommand CalculateCommand { get; private set; }

        private void ExecuteCalculateCommand()
        {
            Result = string.Empty;
            Calculate();
        }
    }
}
