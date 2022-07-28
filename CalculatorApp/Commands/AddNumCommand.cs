using CalculatorApp.Model;
using System;

namespace CalculatorApp.Commands
{
    public class AddNumCommand : BaseCommand
    {
        private readonly CalcModel _model;
        private readonly Action<object> _doAfter;


        public AddNumCommand(CalcModel model, Action<object> doAfter)
        {
            _model = model;
            _doAfter = doAfter;
        }

        public override void Execute(object parameter)
        {
            _model.AddNum(parameter);
            _doAfter?.Invoke(this);
        }

        public override bool CanExecute(object parameter)
        {
            return ValidateComma(parameter as string);
        }
        
        public bool ValidateComma(string? displayText)
        {
            if (displayText != ".")
            {
                return true;
            }

            if (string.IsNullOrEmpty(_model.operation))
            {
                return !_model.firstOpperand.Contains(".");
            }

            return !_model.secondOperand.Contains(".");
        }
    }
}
