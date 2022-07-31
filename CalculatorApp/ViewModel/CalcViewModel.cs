using CalculatorApp.Commands;
using CalculatorApp.Model;
using System;
using System.Globalization;
using System.Windows.Input;

namespace CalculatorApp.ViewModel
{

    public class CalcViewModel : ObservedObject
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
        public ICommand SelectOperation => new SelectOperationCommand(model, OnDisplayValueChanged);
        public ICommand CalculateResult => new CalculateResultCommand(model, OnDisplayValueChanged);

        // TODO: Modify like AddNum
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

        // TODO: Modify like AddNum
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
    }
}
