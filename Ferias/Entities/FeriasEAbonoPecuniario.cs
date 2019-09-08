using System.Globalization;
using System.Text;

namespace Ferias.entities
{
    class DemonstrativoDeFerias
    {
        public string Funcionario { get; set; }
        public double Ferias { get; set; }
        public double AbonoPecuniario { get; set; }
        public double HoraExtra75 { get; set; }
        public double HoraExtra100 { get; set; }
        public double Adicional { get; set; }
        public int Dependente { get; set; }
        public double Hora { get; set; }

        public DemonstrativoDeFerias()
        {
        }

        public DemonstrativoDeFerias(string funcionario, double ferias, double abonoPecuniario, double horaExtra75, double horaExtra100, double adicional, double hora, int dependente)
        {
            Funcionario = funcionario;
            Ferias = ferias;
            AbonoPecuniario = abonoPecuniario;
            HoraExtra75 = horaExtra75;
            HoraExtra100 = horaExtra100;
            Adicional = adicional;
            Hora = hora;
            Dependente = dependente;
        }

        public DemonstrativoDeFerias(string funcionario, double ferias, double horaExtra75, double horaExtra100, double adicional, double hora, int dependente)
        {
            Funcionario = funcionario;
            Ferias = ferias;
            HoraExtra75 = horaExtra75;
            HoraExtra100 = horaExtra100;
            Adicional = adicional;
            Hora = hora;
            Dependente = dependente;
        }

        public DemonstrativoDeFerias(string funcionario, double ferias, double horaExtra75, double horaExtra100, double adicional, double hora, int dependente, double abonoPecuniario) 
            : this(funcionario, ferias, horaExtra75, horaExtra100, adicional, hora, dependente)
        {
            AbonoPecuniario = abonoPecuniario;
        }

        public double CalculoFerias()
        {
            return Hora * Ferias;
        }

        public double CalculoUm3Ferias()
        {
            return CalculoFerias() / 3.0;
        }

        public double CalculoAbonoPecuniario()
        {
            return Hora * AbonoPecuniario;
        }

        public double CalculoUm3AbonoPecuniario()
        {
            return CalculoAbonoPecuniario() / 3.0;
        }

        public double MediaHoraExtra75()
        {
            return Hora * HoraExtra75 / 12.0 * 0.75 + Hora * HoraExtra75 / 12.0;
        }

        public double MediaUm3HoraExtra75()
        {
            return MediaHoraExtra75() / 3.0;
        }

        public double MediaHoraExtra100()
        {
            return Hora * HoraExtra100 / 12.0 * 1 + Hora * HoraExtra100 / 12.0;
        }

        public double MediaUm3HoraExtra100()
        {
            return MediaHoraExtra100() / 3.0; 
        }

        public double MeidaAdicionalNoturno()
        {
            return Hora * 0.35 * Adicional / 12.0;
        }

        public double MediaUm3AdicionalNoturno()
        {
            return MeidaAdicionalNoturno() / 3.0;
        }

        public double BaseCalculoInss()
        {
            return CalculoFerias() + CalculoUm3Ferias() + MediaHoraExtra75() + MediaUm3HoraExtra75() 
                + MediaHoraExtra100() + MediaUm3HoraExtra100() + MeidaAdicionalNoturno() + MediaUm3AdicionalNoturno();
        }

        public double CalculoInss()
        {
            if (BaseCalculoInss() < 1751.82)
            {
                return BaseCalculoInss() * 0.08;
            }
            else if (BaseCalculoInss() < 2919.73)
            {
                return BaseCalculoInss() * 0.09;
            }
            else if (BaseCalculoInss() < 5839.46)
            {
                return BaseCalculoInss() * 0.11;
            }
            else
            {
                return 641.24;
            }
        }

        public double AliquotaInss()
        {
            if(BaseCalculoInss() < 1751.82)
            {
                return 8;
            }
            else if(BaseCalculoInss() < 2919.73)
            {
                return 9;
            }
            else if(BaseCalculoInss() < 5839.46)
            {
                return 11;
            }
            else
            {
                return 0;
            }
        }

        public double CalculoDependente()
        {
            return Dependente * 189.59;
        }

        public double BaseCalculoIrrf()
        {
            return BaseCalculoInss() - CalculoInss() - CalculoDependente();
        }

        public double CalculoIrrf()
        {
            if(BaseCalculoIrrf() < 1903.99)
            {
                return 0.0;
            }
            else if(BaseCalculoIrrf() < 2826.66)
            {
                return BaseCalculoIrrf() * 0.075 - 142.80;
            }
            else if(BaseCalculoIrrf() < 3751.06)
            {
                return BaseCalculoIrrf() * 0.15 - 354.80;
            }
            else if(BaseCalculoIrrf() < 4664.69)
            {
                return BaseCalculoIrrf() * 0.225 - 636.13;
            }
            else
            {
                return BaseCalculoIrrf() * 0.275 - 869.36;
            }
        }

        public double AliquotaIrrf()
        {
            if (BaseCalculoIrrf() < 1903.99)
            {
                return 0.0;
            }
            else if (BaseCalculoIrrf() < 2826.66)
            {
                return 7.5;
            }
            else if (BaseCalculoIrrf() < 3751.06)
            {
                return 15;
            }
            else if (BaseCalculoIrrf() < 4664.69)
            {
                return 22.5;
            }
            else
            {
                return 27.5;
            }
        }
      
        public double Vencimentos()
        {
            return CalculoFerias() + CalculoUm3Ferias() + CalculoAbonoPecuniario() + CalculoUm3AbonoPecuniario() + MediaHoraExtra75()
                + MediaUm3HoraExtra75() + MediaHoraExtra100() + MediaUm3HoraExtra100() + MeidaAdicionalNoturno() + MediaUm3AdicionalNoturno();
        }

        public double Descontos()
        {
            return CalculoInss() + CalculoIrrf();
        }

        public double Fgts()
        {
            return Vencimentos() * 0.08;
        }

        public double LiquidoFerias()
        {
            return Vencimentos() - Descontos();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (CalculoAbonoPecuniario() == 0.0)
            {
                sb.AppendLine(" " + Funcionario + " Suas Férias é: R$ " + CalculoFerias().ToString("F2", CultureInfo.InvariantCulture));
                sb.AppendLine(" " + Funcionario + " Seu 1/3 de Férias é: R$ " + CalculoUm3Ferias().ToString("F2", CultureInfo.InvariantCulture));
            }
            else
            {
                sb.AppendLine(" " + Funcionario + " Suas Férias é: R$ " + CalculoFerias().ToString("F2", CultureInfo.InvariantCulture));
                sb.AppendLine(" " + Funcionario + " Seu 1/3 de Férias é: R$ " + CalculoUm3Ferias().ToString("F2", CultureInfo.InvariantCulture));
                sb.AppendLine(" " + Funcionario + " Seu Abono Pecuniário de Férias é: R$ " + CalculoAbonoPecuniario().ToString("F2", CultureInfo.InvariantCulture));
                sb.AppendLine(" " + Funcionario + " Seu 1/3 do Abono Pecuniário de Férias é: R$ " + CalculoUm3AbonoPecuniario().ToString("F2", CultureInfo.InvariantCulture));
            }
            sb.AppendLine();
            if(MediaHoraExtra75() != 0.0 && MediaUm3HoraExtra75() != 0.0)
            {
                sb.AppendLine(" " + Funcionario + " Sua Média de Hora Extra à 75% Sobre Férias é: R$ " + MediaHoraExtra75().ToString("F2", CultureInfo.InvariantCulture));
                sb.AppendLine(" " + Funcionario + " Seu 1/3 Da Média de Hora Extra à 75% Sobre Férias é: R$ " + MediaUm3HoraExtra75().ToString("F2", CultureInfo.InvariantCulture));
                sb.AppendLine();
            } 
            if(MediaHoraExtra100() != 0.0 && MediaUm3HoraExtra100() != 0.0)
            {
                sb.AppendLine(" " + Funcionario + " Sua Média de Hora Extra à 100% Sobre Férias é: R$ " + MediaHoraExtra100().ToString("F2", CultureInfo.InvariantCulture));
                sb.AppendLine(" " + Funcionario + " Seu 1/3 Da Média de Hora Extra à 100% Sobre Férias é: R$ " + MediaUm3HoraExtra100().ToString("F2", CultureInfo.InvariantCulture));
                sb.AppendLine();
            } 
            if(MeidaAdicionalNoturno() != 0.0 && MediaUm3AdicionalNoturno() != 0.0)
            {
                sb.AppendLine(" " + Funcionario + " Sua Média de Adicional Noturno Sobre Férias é: R$ " + MeidaAdicionalNoturno().ToString("F2", CultureInfo.InvariantCulture));
                sb.AppendLine(" " + Funcionario + " Seu 1/3 Da Média do Adicional Noturno Sobre Férias é: R$ " + MediaUm3AdicionalNoturno().ToString("F2", CultureInfo.InvariantCulture));
                sb.AppendLine();
            } 
            sb.AppendLine(" " + Funcionario + " A Base de Cálculo do INSS é: R$ " + BaseCalculoInss().ToString("F2", CultureInfo.InvariantCulture));
            sb.AppendLine(" " + Funcionario + " O Desconto do INSS é: " + CalculoInss().ToString("F2", CultureInfo.InvariantCulture));
            if (AliquotaInss() == 0)
            { sb.AppendLine(" " + Funcionario + " Alíquota do INSS é: Fixa"); }
            else
            { sb.AppendLine(" " + Funcionario + " Alíquota do INSS é: " + AliquotaInss() + "%"); }
            sb.AppendLine();
            sb.AppendLine(" " + Funcionario + " A Base para Cálculo do IRRF é: R$ " + BaseCalculoIrrf().ToString("F2", CultureInfo.InvariantCulture));
            sb.AppendLine(" " + Funcionario + " Desconto do IRRF é R$ " + CalculoIrrf().ToString("F2", CultureInfo.InvariantCulture));
            if (AliquotaIrrf() == 0)
            { sb.AppendLine(" " + Funcionario + " Alíquota do IRRF é: Isento"); }
            else
            { sb.AppendLine(" " + Funcionario + " Alíquota do IRRF é " + AliquotaIrrf() + "%"); }
            sb.AppendLine();
            sb.AppendLine(" " + Funcionario + " Total dos Vencimentos é: R$ " + Vencimentos().ToString("F2", CultureInfo.InvariantCulture));
            sb.AppendLine(" " + Funcionario + " Total dos Descontos é: R$ " + Descontos().ToString("F2", CultureInfo.InvariantCulture));
            sb.AppendLine();
            sb.AppendLine(" " + Funcionario + " FGTS de Férias é: R$ " + Fgts().ToString("F2", CultureInfo.InvariantCulture));
            sb.AppendLine(" " + Funcionario + " Férias Líquida à Receber é: R$ " + LiquidoFerias().ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();
        }
    }
}
