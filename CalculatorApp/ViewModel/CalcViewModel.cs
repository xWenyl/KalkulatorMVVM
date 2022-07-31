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
        public ICommand ReverseNumberSign => new ReverseNumberSignCommand(model, OnDisplayValueChanged);
        #endregion



        private void OnDisplayValueChanged(object obj)
        {
            onPropertyChanged(nameof(Display));
        }
    }
}
