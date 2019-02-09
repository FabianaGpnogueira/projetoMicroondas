using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
    class ProgramacaoModel
    {
        private string tempo_;
        public string tempo
        {
            get { return tempo_; }
            set { tempo_ = value; }
        }
        private string potencia_;
        public string potencia
        {
            get { return potencia_; }
            set { potencia_ = value; }
        }
        private string descricao_;
        public string descricao
        {
            get { return descricao_; }
            set { descricao_ = value; }
        }
        private string nomeProgramacao_;
        public string nomeProgramacao
        {
            get { return nomeProgramacao_; }
            set { nomeProgramacao_ = value; }
        }
    }
}
