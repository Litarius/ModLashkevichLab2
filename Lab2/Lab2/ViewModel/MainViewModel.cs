using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Lab2.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private LemerControlViewModel _lemerControlViewModel;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            LemerControlViewModel = new LemerControlViewModel();
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

        public static event Action<IEnumerable<double>> OnCalculate;

        public static void Calculate(IEnumerable<double> obj)
        {
            OnCalculate?.Invoke(obj);
        }
    }
}
