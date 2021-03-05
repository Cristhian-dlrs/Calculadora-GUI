using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capa_logica
{
    /// <summary>
    /// Esta clase presta los servicios de una calculadora a la interfaz
    /// grafica.
    /// </summary>
    public class Calculadora
    {
        private Parser parser = new Parser();
        private OperadorRPN operador = new OperadorRPN();

        /// <summary>
        /// Recibe una cadena que contiene una expresion matematica y devuelve
        /// el resultado de la misma.
        /// </summary>
        /// <param name="expresion">Cadena con expresion matematica</param>
        /// <returns>valor resultante de evaluar la expresion</returns>
        public string Calcular(string expresion)
        {
            List<string> expresionRPN = parser.ToMathExpresion(expresion);
            double resultado = Math.Round(operador.Calcular(expresionRPN), 3);
            return resultado.ToString();
        }
    }
}
