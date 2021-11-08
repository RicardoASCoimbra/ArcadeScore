using ArcadeScore.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeScore.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public virtual Escolaridade Escolaridade { get; set; }
        public bool Excluido { get; set; }
    }
}
