using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Model;

namespace ConsoleApp1.Controller
{
    class ProgramacaoController
    {

        public Boolean VerificarValidadeTempo(String tempo)
        {
            if (tempo.All(char.IsNumber))
            {
                if (Convert.ToInt32(tempo) >= 1 && Convert.ToInt32(tempo) <= 120)
                    return true;
                else
                    return false;

            }
            else
                return false;

        }

        public Boolean VerificarValidadePotencia(String potencia)
        {
            if (potencia.All(char.IsNumber))
            {
                if (Convert.ToInt32(potencia) >= 1 && Convert.ToInt32(potencia) <= 10)
                    return true;
                else
                    return false;

            }
            else
                return false;

        }

        public void carregarListaProgramacoes(List<ProgramacaoModel> listaProgramacao)
        {
            ProgramacaoModel modeloFrango = new ProgramacaoModel();
            ProgramacaoModel modeloArroz = new ProgramacaoModel();
            ProgramacaoModel modeloBrigadeiro = new ProgramacaoModel();
            ProgramacaoModel modeloPipoca = new ProgramacaoModel();

            modeloFrango.nomeProgramacao = "Frango";
            modeloFrango.potencia = "8";
            modeloFrango.tempo = "120";
            modeloFrango.descricao = "Ideal para o preparo de aves.";

            modeloArroz.nomeProgramacao = "Arroz";
            modeloArroz.potencia = "6";
            modeloArroz.tempo = "120";
            modeloArroz.descricao = "Ideal para o preparo de grãos.";

            modeloBrigadeiro.nomeProgramacao = "Brigadeiro";
            modeloBrigadeiro.potencia = "8";
            modeloBrigadeiro.tempo = "60";
            modeloBrigadeiro.descricao = "Ideal para deixar seu brigadeiro no ponto correto.";

            modeloPipoca.nomeProgramacao = "Pipoca";
            modeloPipoca.potencia = "6";
            modeloPipoca.tempo = "110";
            modeloPipoca.descricao = "Tempo e potência ideal para estourar 100g de pipoca.";

            listaProgramacao.Add(modeloArroz);
            listaProgramacao.Add(modeloBrigadeiro);
            listaProgramacao.Add(modeloFrango);
            listaProgramacao.Add(modeloPipoca);
        }

        public String CadastrarProgramacaoLista(List<ProgramacaoModel> listaProgramacao, string nomeProgramacao, string tempo, string potencia, string descricao)
        {
            if(VerificarValidadeTempo(tempo) && VerificarValidadePotencia(potencia))
            {
                ProgramacaoModel modelo = new ProgramacaoModel();
                modelo.nomeProgramacao = nomeProgramacao;
                modelo.tempo = tempo;
                modelo.potencia = potencia;
                modelo.descricao = descricao;
                listaProgramacao.Add(modelo);
                return "Cadastrado com sucesso!";
            }
            else
            {
                return "Erro: Verifique a potencia e o tempo.";
            }
            
        }

        public ProgramacaoModel inicializarPorProgramacao(List<ProgramacaoModel> listaProgamacao, string programa)
        {
           return listaProgamacao.Find(x => x.nomeProgramacao == programa);
        }
    }
}
