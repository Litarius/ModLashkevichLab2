using System;
using System.Collections.Generic;
using System.Threading;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Lab2.ViewModel
{
    public class LemerControlViewModel : ViewModelBase
    {
        #region PrivateFields

        private double _a;
        private double _c;
        private int _n;
        private int _count;
        private string _result;

        #endregion

        public LemerControlViewModel()
        {
            A = 5;
            C = 3;
            N = 16;
            Count = 10000;

            LemerCommand = new RelayCommand(ExecuteLemerCommand);
        }

        #region Properties

        public double A
        {
            get { return _a; }
            set
            {
                _a = value;
                RaisePropertyChanged(() => A);
            }
        }

        public double C
        {
            get { return _c; }
            set
            {
                _c = value;
                RaisePropertyChanged(() => C);
            }
        }

        public int N
        {
            get { return _n; }
            set
            {
                _n = value;
                RaisePropertyChanged(() => N);
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

        #endregion

        #region Commands

        public RelayCommand LemerCommand { get; private set; }

        private void ExecuteLemerCommand()
        {
            List<double> results = new List<double>();
            var m = Math.Pow(2, N);

            var start = 0;
            var end = 1;

            double mo = (start + end) / 2.0; // Математическое ожидание
            var D = Math.Pow((start + end), 2.0) / 12.0; // дисперсия
            var sko = Math.Sqrt(D); // средне квадратическое ожидание

            for (var i = 0; i < Count; i++)
            {
                double tmpX = DateTime.Now.Ticks;
                Thread.Sleep(1);
                tmpX = (A * tmpX + C) % m;
                tmpX = tmpX / m;
                results.Add(tmpX);
            }

            var r = $"М0 = {mo}\n";
            r += $"D = {D}\n";
            r += "SKO =" + sko + "\n";
            r += IndirectSigns(results);

            Result = r;
            MainViewModel.Calculate(results);
        }

        private string IndirectSigns(List<double> items)
        {
            var countTrue = 0;
            var countFalse = 0;
            for (var i = 1; i < Count; i += 2)
            {
                if (Math.Pow(items[i - 1], 2) + Math.Pow(items[i], 2) < 1)
                {
                    countTrue++;
                }
                else
                {
                    countFalse++;
                }
            }

            return $"Количество пар входящих в 1 четверть: {countTrue}, не входящих: '{countFalse}";
        }

        #endregion
    }
}
