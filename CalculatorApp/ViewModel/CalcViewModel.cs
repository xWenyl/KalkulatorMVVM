using CalculatorApp.Commands;
using System;
using System.ComponentModel;

namespace CalculatorApp.ViewModel
{
    using Model;
    using System.Globalization;
    using System.Windows.Input;

    public class CalcViewModel : INotifyPropertyChanged
    {
        public CalcModel model = new CalcModel();

        public string Display
        {
            get
            {
                return model.display;
            }
            set
            {
                model.display = value;
                onPropertyChanged(nameof(Display));
            }
        }


        #region Commands

        public ICommand AddNum => new AddNumCommand(model, OnDisplayValueChanged);

        private ICommand selectOperation = null;
        public ICommand SelectOperation
        {
            get
            {
                if (selectOperation == null) selectOperation = new RelayCommand(
                    (object o) =>
                    {
                        model.SelectOperation(o);
                        onPropertyChanged(nameof(Display));
                    },
                    (object o) =>
                    {
                        bool validate = String.IsNullOrEmpty(model.firstOpperand) || Double.IsInfinity(model.result);
                        return !validate;
                    }
                    );
                return selectOperation;
            }
        }


        private ICommand calculateResult = null;
        public ICommand CalculateResult
        {
            get
            {
                if (calculateResult == null) calculateResult = new RelayCommand(
                    (object o) =>
                    {
                        model.CalculateResult();
                        onPropertyChanged(nameof(Display));
                    },
                    (object o) =>
                    {
                        return !String.IsNullOrEmpty(model.firstOpperand) &&
                        !String.IsNullOrEmpty(model.secondOperand) &&
                        double.TryParse(model.secondOperand, NumberStyles.Any, CultureInfo.InvariantCulture, out _);
                    }
                    );
                return calculateResult;
            }
        }


        private ICommand clearCalculator = null;
        public ICommand ClearCalculator
        {
            get
            {
                if (clearCalculator == null) clearCalculator = new RelayCommand(
                    (object o) =>
                    {
                        model.ClearCalculator();
                        onPropertyChanged(nameof(Display));
                    }
                    );
                return clearCalculator;
            }
        }


        public ICommand negateNumber = null;
        public ICommand NegateNumber
        {
            get
            {
                if (negateNumber == null) negateNumber = new RelayCommand(
                    (object o) =>
                    {
                        model.NegateNumber();
                        onPropertyChanged(nameof(Display));
                    });
                return negateNumber;
            }
        }
        #endregion



        private void OnDisplayValueChanged(object obj)
        {
            onPropertyChanged(nameof(Display));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void onPropertyChanged(string nazwaWlasnosci)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(nazwaWlasnosci));
        }
    }
}
