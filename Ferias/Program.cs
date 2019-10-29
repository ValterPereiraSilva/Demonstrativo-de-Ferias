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
        private static double faltas;
        private static double calc;

        static void Main(string[] args)
        {
            try
            {
                DemonstrativoDeFerias calculo;

                Console.Write(" Digite O Nome do Funcionário: ");
                string funcionario = Console.ReadLine();
                Console.Write(" " + funcionario + " Quanto Você Ganha Por Hora: R$ ");
                hora = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write(" " + funcionario + " Você tem Faltas Injustificadas durante o Ano (s/n)? ");
                char pergunta = char.Parse(Console.ReadLine());
                if (pergunta == 's' || pergunta == 'S')
                {
                    Console.Write(" " + funcionario + " Informe quantas Faltas Teve no Ano: ");
                    faltas = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    if (faltas < 6)
                    {
                        calc = 220.00;
                    }
                    else if (faltas < 15)
                    {
                        calc = 176.00;
                    }
                    else if (faltas < 24)
                    {
                        calc = 132.00;
                    }
                    else if (faltas < 33)
                    {
                        calc = 88.00;
                    }
                    else
                    {
                        throw new System.InvalidProgramException(" " + funcionario + " VOCÊ NÃO TEM DIREITO A FÉRIAS ......");
                    }
                }
                else
                {
                    calc = 220.00;
                }
                Console.Write(" " + funcionario + " Você vai tirar as Férias Completas (s/n)? ");
                pergunta = char.Parse(Console.ReadLine());
                if (pergunta == 's' || pergunta == 'S')
                {
                    ferias = calc;
                    calculo = new DemonstrativoDeFerias(funcionario, ferias, horaExtra75, horaExtra100, adicional, hora, dependente, faltas);
                }
                else
                {
                    ferias = calc / 3.0 * 2.0;
                    abonoPecuniario = calc / 3.0;
                    calculo = new DemonstrativoDeFerias(funcionario, ferias, horaExtra75, horaExtra100, adicional, hora, dependente, abonoPecuniario, faltas);
                }
                Console.Write(" " + funcionario + " Você tem Dependentes para Dedução do IRRF (s/n)?: ");
                pergunta = char.Parse(Console.ReadLine());
                if (pergunta == 's' || pergunta == 'S')
                {
                    Console.Write(" " + funcionario + " Informe quantos Dependentes são: ");
                    dependente = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    calculo = new DemonstrativoDeFerias(funcionario, ferias, abonoPecuniario, horaExtra75, horaExtra100, adicional, hora, dependente, faltas);
                }
                else
                {
                    calculo = new DemonstrativoDeFerias(funcionario, ferias, abonoPecuniario, horaExtra75, horaExtra100, adicional, hora, dependente, faltas);
                }
                Console.Write(" " + funcionario + " Você Tem Reflexos sobre as Férias (s/n)?: ");
                pergunta = char.Parse(Console.ReadLine());
                if (pergunta == 's' || pergunta == 'S')
                {
                    Console.Write(" " + funcionario + " Você fez Hora Extra à 75% (s/n)?: ");
                    pergunta = char.Parse(Console.ReadLine());
                    if (pergunta == 's' || pergunta == 'S')
                    {
                        Console.Write(" " + funcionario + " Informe quantas Horas Extra à 75% são: ");
                        horaExtra75 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        calculo = new DemonstrativoDeFerias(funcionario, ferias, abonoPecuniario, horaExtra75, horaExtra100, adicional, hora, dependente, faltas);
                    }
                    Console.Write(" " + funcionario + " Você fez Hora Extra à 100% (s/n)?: ");
                    pergunta = char.Parse(Console.ReadLine());
                    if (pergunta == 's' || pergunta == 'S')
                    {
                        Console.Write(" " + funcionario + " Informe quantas Horas Extra à 100% são: ");
                        horaExtra100 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        calculo = new DemonstrativoDeFerias(funcionario, ferias, abonoPecuniario, horaExtra75, horaExtra100, adicional, hora, dependente, faltas);
                    }
                    Console.Write(" " + funcionario + " Você fez Hora de Adicional Noturno (s/n)?: ");
                    pergunta = char.Parse(Console.ReadLine());
                    if (pergunta == 's' || pergunta == 'S')
                    {
                        Console.Write(" " + funcionario + " Informe quantas Horas de Adicional Noturno são: ");
                        adicional = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        calculo = new DemonstrativoDeFerias(funcionario, ferias, abonoPecuniario, horaExtra75, horaExtra100, adicional, hora, dependente, faltas);
                    }
                }
                Console.WriteLine();
                Console.WriteLine(calculo.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
