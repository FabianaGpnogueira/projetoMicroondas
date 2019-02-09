using System;
using ConsoleApp1.View;
using ConsoleApp1.Controller;
using ConsoleApp1.Model;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        public List<ProgramacaoModel> listaProgramacoes = new List<ProgramacaoModel>();

        static void Main(string[] args)
        {
            Program programa = new Program();
            ProgramacaoController progContr = new ProgramacaoController();
            MicroondasView microView = new MicroondasView();

            progContr.carregarListaProgramacoes(programa.listaProgramacoes);
            microView.InicializaPrograma(programa.listaProgramacoes);
        }
    }
}
