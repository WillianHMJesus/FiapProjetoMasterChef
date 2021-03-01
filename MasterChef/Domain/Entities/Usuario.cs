using System;

namespace Domain.Entities
{
    public class Usuario : Entity
    {
        protected Usuario()
        {

        }

        public Usuario(string primeiroNome, string sobreNome, string userName, string password, DateTime criacao)
        {
            PrimeiroNome = primeiroNome;
            SobreNome = sobreNome;
            UserName = userName;
            Password = password;
            Criacao = criacao;
        }

        public string PrimeiroNome { get; private set; }
        public string SobreNome { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public DateTime Criacao { get; private set; }
    }
}
