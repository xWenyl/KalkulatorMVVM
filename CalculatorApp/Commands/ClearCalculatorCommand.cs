using CalculatorApp.Model;
using System;

namespace CalculatorApp.Commands
{
    public class ClearCalculatorCommand : BaseCommand
    {
        private readonly CalcModel _model;
        private readonly Action<object> _doAfter;

        public ClearCalculatorCommand(CalcModel model, Action<object> doAfter)
        {
            _model = model;
            _doAfter = doAfter;
        }

        public override void Execute(object parameter)
        {
            _model.ClearCalculator();
            _doAfter?.Invoke(this);
        }

    }
}