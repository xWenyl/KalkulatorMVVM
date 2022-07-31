using CalculatorApp.Model;
using System;

namespace CalculatorApp.Commands
{
    public class ReverseNumberSignCommand : BaseCommand
    {
        private readonly CalcModel _model;
        private readonly Action<object> _doAfter;

        public ReverseNumberSignCommand(CalcModel model, Action<object> doAfter)
        {
            _model = model;
            _doAfter = doAfter;
        }

        public override void Execute(object parameter)
        {
            _model.ReverseNumberSign();
            _doAfter?.Invoke(this);
        }

    }
}