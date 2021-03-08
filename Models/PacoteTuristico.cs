using System;

namespace klturismo.Models
{
    public class PacoteTuristico
    {
        
        public int Id{get;set;}
        public string Nome{get;set;}
        public string Origem{get;set;}
        public string Destino{get;set;}
        public string Atrativo{get;set;}
        public DateTime Saida{get;set;}
        public DateTime Retorno{get;set;}
        public int Usuario {get;set;}
    
    }
}