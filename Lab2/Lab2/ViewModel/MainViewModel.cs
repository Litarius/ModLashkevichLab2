using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Lab2.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private LemerControlViewModel _lemerControlViewModel;
        private GammaControlViewModel _gammaControlViewModel;
        private NormalControlViewModel _normalControlViewModel;
        private ExponentialControlViewModel _exponentialControlViewModel;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            LemerControlViewModel = new LemerControlViewModel();
            GammaControlViewModel = new GammaControlViewModel();
            NormalControlViewModel = new NormalControlViewModel();
            ExponentialControlViewModel = new ExponentialControlViewModel();
        }

        public LemerControlViewModel LemerControlViewModel
        {
            get { return _lemerControlViewModel; }
            set
            {
                _lemerControlViewModel = value;
                RaisePropertyChanged(() => LemerControlViewModel);
            }
        }

        public GammaControlViewModel GammaControlViewModel
        {
            get { return _gammaControlViewModel; }
            set
            {
                _gammaControlViewModel = value;
                RaisePropertyChanged(() => GammaControlViewModel);
            }
        }

        public NormalControlViewModel NormalControlViewModel
        {
            get { return _normalControlViewModel; }
            set
            {
                _normalControlViewModel = value;
                RaisePropertyChanged(() => NormalControlViewModel);
            }
        }

        public ExponentialControlViewModel ExponentialControlViewModel
        {
            get { return _exponentialControlViewModel; }
            set
            {
                _exponentialControlViewModel = value;
                RaisePropertyChanged(() => ExponentialControlViewModel);
            }
        }

        public static event Action<IEnumerable<double>> OnCalculate;

        public static void Calculate(IEnumerable<double> obj)
        {
            OnCalculate?.Invoke(obj);
        }
    }
}
