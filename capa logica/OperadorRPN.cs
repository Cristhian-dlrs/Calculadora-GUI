using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capa_logica
{
    /// <summary>
    /// Esta calse se encarga de evaluar expresiones matematicas postfijas.
    /// </summary>
    internal class OperadorRPN
    {
        /// <summary>
        /// Evalua una expresion matematica postfija.
        /// </summary>
        /// <param name="expresion">Expresion matematica postfija</param>
        /// <returns>Resultado de evaular la expresion</returns>
        public double Calcular(List<string> expresion)
        {
            Stack<double> resultado = new Stack<double>();
            double operando1;
            double operando2;

            foreach (var operando in expresion)
            {
                switch(operando)
                {
                    case "+":
                        operando1 = Convert.ToDouble(resultado.Pop());
                        operando2 = Convert.ToDouble(resultado.Pop());
                        resultado.Push(operando2 + operando1);
                        break;

                    case "-":
                        operando1 = Convert.ToDouble(resultado.Pop());
                        operando2 = Convert.ToDouble(resultado.Pop());
                        resultado.Push(operando2 - operando1);
                        break;

                    case "x":
                        operando1 = Convert.ToDouble(resultado.Pop());
                        operando2 = Convert.ToDouble(resultado.Pop());
                        resultado.Push(operando2 * operando1);
                        break;

                    case "/":
                        operando1 = Convert.ToDouble(resultado.Pop());
                        operando2 = Convert.ToDouble(resultado.Pop());
                        resultado.Push(operando2 / operando1);
                        break;

                    default:
                        resultado.Push(Convert.ToDouble(operando));
                        break;
                }
            }
            return resultado.Pop();
        }
    }
}
