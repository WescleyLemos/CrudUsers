using System;
using System.ComponentModel.DataAnnotations;
using ProjetoConfitec.Models.Enums;

namespace ProjetoConfitec.Models
{
    public class Usuarios
    {
        public Usuarios(Guid id, string nome, string sobrenome, string email, DateTime dataNascimento, int escolaridade)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$"))
            {
                throw new Exception("Email inválido");
            }
            if (dataNascimento > DateTime.Now)
            {
                throw new ArgumentException("A data de nascimento não pode ser maior que a data atual");
            }

            if (!Enum.IsDefined(typeof(Escolaridade), escolaridade))
            {
                throw new ArgumentException("Escolaridade inválida");
            }
            if (id == null || id == Guid.Empty)
            {
                Id = Guid.NewGuid();
            }
            else
            {
                Id = id;
            }
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = dataNascimento;
            Escolaridade = escolaridade;
        }
        [Key]
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public int Escolaridade { get; private set; }
    }
}
