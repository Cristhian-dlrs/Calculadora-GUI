using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capa_logica
{
    /// <summary>
    /// Esta clase realiza las actividades propias de una calculadora
    /// usando dos pilas para gestionar las operaciones y los operandos.
    /// </summary>
    public class Calculadora
    {
        private Stack<string> operaciones = new Stack<string>();
        private Stack<double> operandos = new Stack<double>();

        /// <summary>
        /// Vacia las pilas de operaciones y operandos.
        /// </summary>
        public void BorrarTodo()
        {
            operaciones.Clear();
            operandos.Clear();
        }

        /// <summary>
        /// Calcula el resultado de una operacion
        /// </summary>
        /// <param name="operando">Nuevo operando introducido</param>
        /// <param name="operacion">Operacion solicitada</param>
        /// <returns>El resultado de la operacion como una cadena</returns>
        public string Calcular(string operando, string operacion)
        {
            double operando1;
            double operando2;
            string operacionAnt;
            double resultado = Convert.ToDouble(operando);

            if (operandos.Count == 0 && operaciones.Count == 0)
            {
                operandos.Push(Convert.ToDouble(operando));
                operaciones.Push(operacion);
            }
            else if (operandos.Count > 0 && operaciones.Count > 0)
            {
                operacionAnt = operaciones.Pop();
                operaciones.Push(operacion);
                operando1 = operandos.Pop();
                operando2 = Convert.ToDouble(operando);
                resultado = realizarOperacion(operando1, operando2, operacionAnt);
                operandos.Push(resultado);    
            }
            return resultado.ToString();
        }

        /// <summary>
        /// Calcula el resultado de una operacion
        /// </summary>
        /// <param name="operando1">priemr operando</param>
        /// <param name="operando2">segundo operando</param>
        /// <param name="operacion">operacion a realiar</param>
        /// <returns></returns>
        private double realizarOperacion(double operando1, double operando2,
            string operacion)
        {
            switch(operacion)
            {
                case "+":
                    return operando1 + operando2;

                case "-":
                    return operando1 - operando2;

                case "x":
                    return operando1 * operando2;
                

                case "/":
                    return operando1 / operando2;
                    

                case "=":
                    try
                    {
                        string OperacionAnt = operaciones.Pop();
                        return realizarOperacion(operando1, operando2, OperacionAnt);
                    }
                    catch (InvalidOperationException ex) 
                    {
                        return operando2;
                    }

                default:
                    return 0;
            }
        }
    }
}
