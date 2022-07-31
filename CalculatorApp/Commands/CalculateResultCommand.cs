using CalculatorApp.Model;
using System;
using System.Globalization;

namespace CalculatorApp.Commands
{
    public class CalculateResultCommand : BaseCommand
    {
        private readonly CalcModel _model;
        private readonly Action<object> _doAfter;

        public CalculateResultCommand(CalcModel model, Action<object> doAfter)
        {
            _model = model;
            _doAfter = doAfter;
        }

        public override void Execute(object parameter)
        {
            _model.CalculateResult();
            _doAfter?.Invoke(this);
        }

        public override bool CanExecute(object parameter)
        {
            return !String.IsNullOrEmpty(_model.firstOpperand) &&
            !String.IsNullOrEmpty(_model.secondOperand) &&
            double.TryParse(_model.secondOperand, NumberStyles.Any, CultureInfo.InvariantCulture, out _);
        }
    }
}
