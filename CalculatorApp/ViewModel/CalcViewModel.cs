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
        public ICommand ClearCalculator => new ClearCalculatorCommand(model, OnDisplayValueChanged);
        // TODO: Modify like AddNum
        public ICommand negateNumber = null;
        public ICommand NegateNumber
        {
            get
            {
                if (negateNumber == null) negateNumber = new RelayCommand(
                    (object o) =>
                    {
                        model.ReverseNumberSign();
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
