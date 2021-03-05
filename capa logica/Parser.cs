using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capa_logica
{
    /// <summary>
    /// Esta clase se encarga de trandformar una cadena de texto que contenga
    /// una expresion matematica valida en una expresion matematiaca post-fija.
    /// </summary>
    internal class Parser
    {
        /// <summary>
        /// Transforma una cadena de texto en una expresion matematica post-fija
        /// </summary>
        /// <param name="str">Expresion en formato cadena</param>
        /// <returns></returns>
        public List<string> ToMathExpresion(string str)
        {
            List<string> resultado = new List<string>();
            StringBuilder numero = new StringBuilder();

            foreach (var elemento in str)
            {
                if (Char.IsNumber(elemento))
                {
                    numero.Append(elemento);
                }
                else
                {
                    resultado.Add(numero.ToString());
                    resultado.Add(elemento.ToString());          
                    numero.Clear();
                }
            }
            resultado.Add(numero.ToString());
            return  toRpnExpresion(resultado);
        }

        /// <summary>
        /// Transforma una expresion matematica in-fija en psot-fija o RPN
        /// (Reverse Polish Notation).
        /// </summary>
        /// <param name="expresion">Expresion in-fija</param>
        /// <returns>Expresion post-fija</returns>
        private List<string> toRpnExpresion(List<string> expresion)
        {
            Stack<string> operaciones = new Stack<string>();
            List<string> resultado = new List<string>();

            foreach (var elemento in expresion)
            {
                if (double.TryParse(elemento, out double num))
                {
                    resultado.Add(elemento);
                }
                else
                {
                    while(operaciones.Count > 0 && 
                        prioridad(elemento, operaciones) <= 0)
                    {
                        resultado.Add(operaciones.Pop());
                    }
                    operaciones.Push(elemento);
                }
            }
            while (operaciones.Count > 0)
            {
                resultado.Add(operaciones.Pop());
            }
            return resultado;
        }

        /// <summary>
        /// Calcula la prioridad del operador indicado con respecto al 
        /// operador que se encuentra en la cima de la pila.
        /// </summary>
        /// <param name="operador">Operador a comparar</param>
        /// <param name="pila">Pila de operadores</param>
        /// <returns>
        ///     0 si som de igual prioridad
        ///     1 si es de mayor prioridad que la cima de la pila
        ///    -1 si es de menor prioridad que el operador en la cima
        /// </returns>
        private int prioridad(string operador, Stack<string> pila)
        {
            int prioridad = 0;

            if ((operador == "+" || operador == "-"))
            {
                if (pila.Peek() == "/" || pila.Peek() == "x")
                {
                    prioridad = -1;
                }
                else
                {
                    prioridad = 0;
                }
            }
            else if ((operador == "x" || operador == "/")) 
            {
                if (pila.Peek() == "+" || pila.Peek() == "-")
                {
                    prioridad = 1;
                }
                else
                {
                    prioridad = 0;
                }
            }
            return prioridad;
        }
    }
}
