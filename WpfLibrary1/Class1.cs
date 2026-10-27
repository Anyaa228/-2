using System;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;

namespace WpfLibrary1
{
    public class Calculator
    {
        public double Compute(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
                throw new ArgumentException("Пустое выражение");

            // Проверка на деление на ноль
            if (Regex.IsMatch(expression.Replace(" ", ""), @"/0(\.0*)?([\+\-\*\/\^\)]|$)"))
                throw new DivideByZeroException();

            string prepared = HandlePowerOperations(expression.Replace(" ", ""));
            var result = new DataTable().Compute(prepared, null);
            return Convert.ToDouble(result, CultureInfo.InvariantCulture);
        }

        private string HandlePowerOperations(string expr)
        {
            var pattern = new Regex(@"(-?\d+\.?\d*)\^(-?\d+\.?\d*)");
            while (pattern.IsMatch(expr))
            {
                expr = pattern.Replace(expr, m =>
                {
                    double a = double.Parse(m.Groups[1].Value, CultureInfo.InvariantCulture);
                    double b = double.Parse(m.Groups[2].Value, CultureInfo.InvariantCulture);
                    return Math.Pow(a, b).ToString(CultureInfo.InvariantCulture);
                }, 1);
            }
            return expr;
        }
    }
}