using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Lab2.ViewModel
{
    public class GammaControlViewModel : ViewModelBase
    {
        private Random rnd = new Random();
        private double _n;
        private double _l;
        private int _count;
        private string _result;

        public GammaControlViewModel()
        {
            _n = 7;
            _l = 5;
            _count = 1000;

            CalculateCommand = new RelayCommand(ExecuteCalculateCommand);
        }


        private void Calculate()
        {
            List<double> randArray = new List<double>();
            for (var i = 0; i < _count; i++)
            {
                var tmp = 0.0;
                for (var j = 0; j < _n; j++)
                {
                    tmp += -1 / _l * Math.Log10(rnd.NextDouble());

                }
                randArray.Add(tmp);

            }

            var mo = _n / _l;
            var D = _n / (_l * _l);
            //$('.abc .ergcoun').html('СКО: ' + sko);

            var r = $"М0 = {mo}\n";
            r += $"D = {D}\n";

            Result = r;

            MainViewModel.Calculate(randArray);



        }

        public double N
        {
            get { return _n; }
            set
            {
                _n = value;
                RaisePropertyChanged(() => N);
            }
        }

        public double L
        {
            get { return _l; }
            set
            {
                _l = value;
                RaisePropertyChanged(() => L);
            }
        }

        public int Count
        {
            get { return _count; }
            set
            {
                _count = value;
                RaisePropertyChanged(() => Count);
            }
        }

        public string Result
        {
            get { return _result; }
            set { _result = value; RaisePropertyChanged(() => Result); }
        }

        public RelayCommand CalculateCommand { get; private set; }

        private void ExecuteCalculateCommand()
        {
            Result = string.Empty;
            Calculate();
        }

    }
}
