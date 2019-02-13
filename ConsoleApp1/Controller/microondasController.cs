using ConsoleApp1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleApp1.Controller
{
    class MicroondasController
    {
        private string potencia_ = "10";
        public string potencia
        {
            get { return potencia_; }
            set { potencia_ = value; }
        }

        public int tempoTotal { get; set; }
        
        public Boolean AlterarPotencia(string potenciaAlterada)
        {
            int potenciaInteira = Convert.ToInt32(potenciaAlterada);
            if (potenciaInteira >= 1 && potenciaInteira <= 10)
            {
                potencia = potenciaAlterada;
                return true;
            }
            else
            {
                return false;
            }
        }

        public string AlteraTempo(string tempoAlterado, List<ProgramacaoModel> listaProgramacao)
        {
            ProgramacaoController progContr = new ProgramacaoController();

            if (tempoAlterado.All(char.IsNumber)){
                int tempoInteiro = Convert.ToInt32(tempoAlterado);
                if (tempoInteiro >= 1 && tempoInteiro <= 120)
                {
                    tempoTotal = Convert.ToInt32(tempoAlterado);
                    return "Tempo adicionado.";
                }
                else
                {
                    return "O tempo deve ser entre 1 e 120 segundos.";
                }
            }
            else
            {
               ProgramacaoModel programacao = progContr.inicializarPorProgramacao(listaProgramacao, tempoAlterado);
                tempoTotal = Convert.ToInt32(programacao.tempo);
                potencia = programacao.potencia;
                return "Inicializando Programacao: " + programacao.nomeProgramacao;
            }
        }

       
        public String InicializacaoRapida()
        {
            potencia = "8";
            tempoTotal = 30;
            return TimerMicroondas();
        }

        public string TimerMicroondas()
        {
            Boolean esperarTimer = true;
            int tempoAtual = 0;
            while (esperarTimer)
            {
                if (tempoAtual >= tempoTotal)
                    esperarTimer = false;
                else
                    PreencherConsolePotencia();
                    Thread.Sleep(1000);
                    tempoAtual += 1;
            }

            return "\nAquecido!";
        }

        public void PreencherConsolePotencia()
        {
            Console.Write(PegarValorPotencia());
        }

        public string PegarValorPotencia()
        {
            int potenciaInteira = Convert.ToInt32(potencia);
            string result = "";
            for (int i = 1; i <= potenciaInteira; i++)
            {
                result += ".";

            }
                return result;
        }

        public Boolean ValidarTempoSelecionado(int tempoVerificacao)
        {
            if (tempoVerificacao >= 1 && tempoVerificacao <= 120)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
