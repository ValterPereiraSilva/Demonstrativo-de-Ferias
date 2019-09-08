using System;
using System.Globalization;
using Ferias.entities;

namespace Ferias
{
    class Program
    {
        private static double ferias;
        private static double horaExtra75;
        private static double horaExtra100;
        private static double adicional;
        private static int dependente;
        private static double hora;
        private static double abonoPecuniario;

        static void Main(string[] args)
        {
            DemonstrativoDeFerias calculo;

            Console.Write(" Digite o Nome do Funcionário: ");
            string funcionario = Console.ReadLine();
            Console.Write(" " + funcionario + " Quanto Você Ganha Por Hora: R$ ");
            hora = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write(" " + funcionario + " Você vai tirar as Férias Completas (s/n)? ");
            char pergunta = char.Parse(Console.ReadLine());
            if (pergunta == 's' || pergunta == 'S')
            {
                ferias = 220.00;
                calculo = new DemonstrativoDeFerias(funcionario, ferias, horaExtra75, horaExtra100, adicional, hora, dependente);
            }
            else
            {
                ferias = 146.66666;
                abonoPecuniario = 73.33333;
                calculo = new DemonstrativoDeFerias(funcionario, ferias, horaExtra75, horaExtra100, adicional, hora, dependente, abonoPecuniario);
            }
            Console.Write(" " + funcionario + " Você Tem Reflexos sobre as Férias (s/n)?: ");
            pergunta = char.Parse(Console.ReadLine());
            if (pergunta == 's' || pergunta == 'S'){
                Console.Write(" " + funcionario + " Você fez Hora Extra à 75% (s/n)?: ");
                pergunta = char.Parse(Console.ReadLine());
                if (pergunta == 's' || pergunta == 'S')
                {
                    Console.Write(" " + funcionario + " Informe quantas Horas Extra à 75% são: ");
                    horaExtra75 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    calculo = new DemonstrativoDeFerias(funcionario, ferias, abonoPecuniario, horaExtra75, horaExtra100, adicional, hora, dependente);
                }
                Console.Write(" " + funcionario + " Você fez Hora Extra à 100% (s/n)?: ");
                pergunta = char.Parse(Console.ReadLine());
                if (pergunta == 's' || pergunta == 'S')
                {
                    Console.Write(" " + funcionario + " Informe quantas Horas Extra à 100% são: ");
                    horaExtra100 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    calculo = new DemonstrativoDeFerias(funcionario, ferias, abonoPecuniario, horaExtra75, horaExtra100, adicional, hora, dependente);
                }
                Console.Write(" " + funcionario + " Você fez Hora de Adicional Noturno durante o Ano (s/n)?: ");
                pergunta = char.Parse(Console.ReadLine());
                if (pergunta == 's' || pergunta == 'S')
                {
                    Console.Write(" " + funcionario + " Informe quantas Horas de Adicional Noturno são: ");
                    adicional = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    calculo = new DemonstrativoDeFerias(funcionario, ferias, abonoPecuniario, horaExtra75, horaExtra100, adicional, hora, dependente);
                }
            }
            Console.Write(" " + funcionario + " Você tem Dependentes para Dedução do IRRF (s/n)?: ");
            pergunta = char.Parse(Console.ReadLine());
            if (pergunta == 's' || pergunta == 'S')
            {
                Console.Write(" " + funcionario + " Informe quantos Dependentes são: ");
                dependente = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                calculo = new DemonstrativoDeFerias(funcionario, ferias, abonoPecuniario, horaExtra75, horaExtra100, adicional, hora, dependente);
            }
            Console.WriteLine();
            Console.WriteLine(calculo.ToString());
        }
    }
}
