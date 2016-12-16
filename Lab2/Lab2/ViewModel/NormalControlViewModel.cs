using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Lab2.ViewModel
{
    public class NormalControlViewModel : ViewModelBase
    {
        private Random rnd = new Random();
        private double _n;
        private double _mo;
        private double _cko;
        private int _count;
        private string _result;

        public NormalControlViewModel()
        {
            CalculateCommand = new RelayCommand(ExecuteCalculateCommand);
            MO = 20;
            CKO = 5;
            N = 6;
            Count = 1000;
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

        public double MO
        {
            get { return _mo; }
            set
            {
                _mo = value;
                RaisePropertyChanged(() => MO);
            }
        }

        public double CKO
        {
            get { return _cko; }
            set
            {
                _cko = value;
                RaisePropertyChanged(() => CKO);
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

        private void Calculate()
        {
            var randArray = new List<double>();
            for (var i = 0; i < Count; i++)
            {
                var tmp = 0.0;
                for (var j = 0; j < _n; j++)
                {
                    tmp += rnd.NextDouble();
                }

                randArray.Add(_mo + _cko * Math.Sqrt(12.0 / _n) * (tmp - _n / 2));
            }

            MainViewModel.Calculate(randArray);
        }

        public RelayCommand CalculateCommand { get; private set; }

        private void ExecuteCalculateCommand()
        {
            Calculate();
        }
    }
}
