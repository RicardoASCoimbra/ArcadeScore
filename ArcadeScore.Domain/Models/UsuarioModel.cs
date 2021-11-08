using ArcadeScore.Domain.Core.Models;
using ArcadeScore.Domain.Enuns;
using System;

namespace ArcadeScore.Domain.Models
{
    public class UsuarioModel : Entity
    {
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public virtual Escolaridade Escolaridade { get; private set; }
        public bool Excluido { get; private set; }

        public UsuarioModel(
             Guid id,
             string nome,
             string sobrenome,
             string email,
             DateTime dataNascimento,
             Escolaridade escolaridade)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = dataNascimento;
            Escolaridade = escolaridade;
        }

        public void SetDados(
             string nome,
             string sobrenome,
             string email,
             DateTime dataNascimento,
             Escolaridade escolaridade)
        {         
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = dataNascimento;
            Escolaridade = escolaridade;
        }

        public void SetExcluido(bool flag)
        {
            Excluido = flag;
        }
    }
}
