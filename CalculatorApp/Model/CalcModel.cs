using System;
using System.Globalization;

namespace CalculatorApp.Model
{
    public class CalcModel
    {
        public string firstOpperand = String.Empty;
        public string secondOperand = String.Empty;
        public string operation = String.Empty;
        public double result = 0;
        public string display;


        public void AddNum(object o)
        {


            if (o as string == "0" && display == "0")
            {
                return;
            } 

            if (String.IsNullOrEmpty(operation))
            {

                if (result != 0)
                {
                    firstOpperand = String.Empty;
                    display = String.Empty;
                    result = 0;
                    firstOpperand += (o as string);
                }
                else
                {
                    firstOpperand += (o as string);
                }
                display = firstOpperand;

            }

            else
            {
                if (String.IsNullOrEmpty(secondOperand))
                    display = String.Empty; ;
                secondOperand += (o as string);
                display = secondOperand;
            }

        }

        public void SelectOperation(object o)
        {
            if (double.TryParse(secondOperand, NumberStyles.Any, CultureInfo.InvariantCulture, out _))
            {
                CalculateResult();
            }
            operation = (o as string);

        }

        public void CalculateResult()
        {

            decimal fOperand = decimal.Parse(firstOpperand, CultureInfo.InvariantCulture);
            decimal sOperand = decimal.Parse(secondOperand, CultureInfo.InvariantCulture);


            switch (operation)
            {
                case "+":
                    result = Convert.ToDouble(fOperand + sOperand);
                    break;
                case "-":
                    result = Convert.ToDouble(fOperand - sOperand);
                    break;
                case "*":
                    result = Convert.ToDouble(fOperand * sOperand);
                    break;
                case "/":
                    result = Convert.ToDouble(fOperand) / Convert.ToDouble(sOperand);
                    break;

            }


            operation = String.Empty;
            secondOperand = String.Empty;
            firstOpperand = result.ToString().Replace(",", ".");
            display = firstOpperand;

        }

        public void ClearCalculator()
        {
            operation = String.Empty;
            firstOpperand = String.Empty;
            secondOperand = String.Empty;
            display = String.Empty;
            result = 0;
        }

        public void ReverseNumberSign()
        {
            if (String.IsNullOrEmpty(operation))
            { 
                if (firstOpperand.Contains("-"))
                {
                    firstOpperand = firstOpperand.Replace("-", "");
                } 
                else
                {
                    firstOpperand = firstOpperand.Insert(0, "-");
                }
                display = firstOpperand;
            } else
            {
                if (secondOperand.Contains("-"))
                {
                    secondOperand = secondOperand.Replace("-", "");
                }
                else
                {
                    secondOperand = secondOperand.Insert(0, "-");
                }
                display = secondOperand;
            }

        }
    }
}
