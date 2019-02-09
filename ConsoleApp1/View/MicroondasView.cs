using ConsoleApp1.Controller;
using ConsoleApp1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1.View
{
    class MicroondasView
    {
        public List<ProgramacaoModel> listaProgramacoesCont = new List<ProgramacaoModel>();
        public MicroondasController microController = new MicroondasController();

        public void InicializaPrograma(List<ProgramacaoModel> listaProgramacao)
        {
            Boolean opcaoInvalida = true;
            Inicio();
            listaProgramacoesCont = listaProgramacao;
            while (opcaoInvalida)
            {
                string opcaoEscolhida = Console.ReadLine();
                if (opcaoEscolhida == "a" || opcaoEscolhida == "b" || opcaoEscolhida == "c" || opcaoEscolhida == "d")
                {
                    opcaoInvalida = false;
                    LerOpcaoMicroondas(opcaoEscolhida, listaProgramacoesCont);
                }
                else
                {
                    ErroOpcaoInvalida();
                }
            }
        }

        public void Inicio()
        { 
            Console.Clear();
            Console.WriteLine("Bem vindo ao seu microondas!");
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("(a) - Visualizar programações");
            Console.WriteLine("(b) - Cadastrar nova programação");
            Console.WriteLine("(c) - inicializar microondas");
            Console.WriteLine("(d) - Sair");
        }

    public void LerOpcaoMicroondas(string opcaoEscolhida, List<ProgramacaoModel> listaProgramacao)
        {
            ProgramacaoController programacaoCont = new ProgramacaoController();
            switch (opcaoEscolhida)
            {
                case "a":
                    CarregarProgramacoes(listaProgramacao);
                    break;
                case "b":
                    CadastrarProgramacao(listaProgramacao);
                    break;
                case "c":
                    InicializarMicroondas();
                    break;
                case "d":
                    Environment.Exit(0);
                    break;

            }
        }
  
        public void ErroOpcaoInvalida()
        {
            Console.WriteLine("Opção inválida, favor escolher uma das opções.");
            Thread.Sleep(2000);
         
        }

        public void CadastrarProgramacao(List<ProgramacaoModel> listaProgramacao)
        {
            ProgramacaoController progCont = new ProgramacaoController();
            string nome, descricao, tempo, potencia;

            Console.Clear();
            Console.WriteLine("Cadastro de programações:");
            Console.WriteLine("Digite o nome da sua programação:");
            nome = Console.ReadLine();
            Console.WriteLine("Digite a descrição de sua programação:");
            descricao = Console.ReadLine();
            Console.WriteLine("Digite o tempo de cozimento em segundos:");
            tempo = Console.ReadLine();
            Console.WriteLine("Digite a potencia:");
            potencia = Console.ReadLine();
            Console.Clear();
            string result = progCont.CadastrarProgramacaoLista(listaProgramacao, nome, tempo, potencia, descricao);
            Console.WriteLine(result);
            Thread.Sleep(3000);
            CarregarProgramacoes(listaProgramacao);
        }

        public void CarregarProgramacoes(List<ProgramacaoModel> listaProgramacao)
        {
            Console.Clear();
            Console.WriteLine("Lista de programações:");
            Console.WriteLine("");
            foreach (ProgramacaoModel model in listaProgramacao)
            {
                Console.WriteLine("Programação: " + model.nomeProgramacao);
                Console.WriteLine("Descrição: " + model.descricao);
                Console.WriteLine("Tempo: " + model.tempo + " segundos");
                Console.WriteLine("Potência: " + model.potencia);
                Console.WriteLine("=================================================================================");

            }

            while(carregarMenu());
        }

        public Boolean carregarMenu()
        {
            Console.WriteLine("Escolha a opcao desejada:");
            Console.WriteLine("(a) - Voltar menu anterior");
            Console.WriteLine("(b) - Sair");
            string decisao = Console.ReadLine();

            if (decisao == "a")
            {
                InicializaPrograma(listaProgramacoesCont);
                return true;
            }
            else if (decisao == "b")
            {
                Environment.Exit(0);
                return false;

            }
            else
            {
                Console.WriteLine("Opção inválida. Favor escolher uma das opções!");
                return false;
            }
        }

        public void InicializarProgramacaoRapida()
        {
            Console.Clear();
            Console.WriteLine("Inicialização rapida, aguarde 30 segundos enquanto o alimento é aquecido.");
            
            string result = microController.InicializacaoRapida();
            Console.WriteLine(result);
        }
        
        public void InicializarMicroondas()
        {
            Boolean opcaoValidada = false;

            Console.Clear();
            Console.WriteLine("Inicializando Microondas");
            Console.WriteLine("Escolha uma das opcoes:");
            Console.WriteLine("(a) - Inicialização rapida");
            Console.WriteLine("(b) - Escolher tempo ou programação");
            Console.WriteLine("(c) - Sair");

            while (!opcaoValidada)
            {
                string opcaoEscolhida = Console.ReadLine();
                switch (opcaoEscolhida)
                {
                    case "a":
                        Console.WriteLine("Inicializando microondas");
                        microController.InicializacaoRapida();
                        break;
                    case "b":
                        InicializarTempoProgramacao();
                        break;
                    case "c":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida!");
                        Console.WriteLine("Escolha uma das opcoes:");
                        Console.WriteLine("(a) - Inicialização rapida");
                        Console.WriteLine("(b) - Escolher tempo ou programação");
                        Console.WriteLine("(c) - Sair");
                        break;
                }
            }
        }

        public void InicializarTempoProgramacao()
        {
            Console.WriteLine("Inicializando Microondas.");
            Console.WriteLine("Insira o Tempo em segundos ou a programação desejada:");
            string result = Console.ReadLine();
            InicializaTelaPorParametro(microController.AlteraTempo(result, listaProgramacoesCont));
        }

        public void InicializaTelaPorParametro(string parametroResposta)
        {
            if (parametroResposta == "Tempo adicionado.")
            {
                Boolean continuarOpcoes = false;
   
                while (!continuarOpcoes)
                {
                    Console.WriteLine("Deseja alterar a potência? Potência atual 10. (S/N)");
                    string opcao = Console.ReadLine();
                    if (opcao == "s" || opcao == "S")
                    {
                        telaInserirPotencia();
                        TelaLigarMicroondas();
                        continuarOpcoes = true;
                    }
                    else if (opcao == "n" || opcao == "N")
                    {
                        TelaLigarMicroondas();
                        continuarOpcoes = true;
                    }
                    else
                    {
                        Console.WriteLine("Favor escolher uma opção válida.");
                        Thread.Sleep(2000);
                    }
                }
            }
            else if (parametroResposta == "O tempo deve ser entre 1 e 120 segundos.")
            {
                Console.WriteLine("Tempo escolhido inválido. Favor escolher o tempo entre 1 e 120 segundos.");
                InicializarTempoProgramacao();
            }
            else
            {
                Console.WriteLine(parametroResposta);
                TelaLigarMicroondas();
            }
        }

        public void telaInserirPotencia()
        {
            Console.WriteLine("Insira a potência desejada(1 a 10):");
            string opcao = Console.ReadLine();
            telaValidarPotencia(opcao);
        }

        public void telaValidarPotencia(string potencia)
        {
            Boolean resultPotencia = microController.AlterarPotencia(potencia);
            while (!resultPotencia)
            {
                Console.WriteLine("A potência selecionada é inválida. Favor selecionar uma potência de 1 a 10.");
                Thread.Sleep(2000);
                telaInserirPotencia();
            }
            Console.WriteLine("Potência alterada para: " + potencia);
        }

        public void TelaLigarMicroondas()
        {
            Console.WriteLine("Inicializando microondas");
            string result = microController.TimerMicroondas();
            Console.WriteLine(result);
            Thread.Sleep(3000);
            InicializaPrograma(listaProgramacoesCont);
        }
    }
}
