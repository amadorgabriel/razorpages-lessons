using System;

namespace acidenteMarte.Models {
    public class RelatoModel{
        
        public int Id {get; set;}
        public string NomeRelator {get; set;}
        public string Email {get; set;}
        public DateTime Data {get; set;}
        public string Mensagem {get;set;}

        //CONSTRUTOR - Método que facilitará a criação de objetos;
        public RelatoModel(string nome, string email, DateTime data, string msg)
        {
            this.NomeRelator = nome;
            this.Email = email;
            this.Data = data;
            this.Mensagem = msg;
        }

    }
}