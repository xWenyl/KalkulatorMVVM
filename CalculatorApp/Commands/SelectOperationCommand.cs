using CalculatorApp.Model;
using System;

namespace CalculatorApp.Commands
{
    public class SelectOperationCommand : BaseCommand
    {
        private readonly CalcModel _model;
        private readonly Action<object> _doAfter;

        public  SelectOperationCommand(CalcModel model, Action<object> doAfter)
        {
            _model = model;
            _doAfter = doAfter;
        }

        public override void Execute(object parameter)
        {
            _model.SelectOperation(parameter);
            _doAfter?.Invoke(this);
        }

        public override bool CanExecute(object parameter)
        {

            return !(String.IsNullOrEmpty(_model.firstOpperand) || Double.IsInfinity(_model.result));
        }
    }
}
