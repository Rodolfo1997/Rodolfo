using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NegociacaoMerca.Entidades
{
    public class Mercadoria
    {
        public int Id { get; set; }
        
        public int CodMercadoria {get; set;}

        public string TipoMercadoria {get; set;}
 
        public string NomeMercadoria {get; set;}

        public int Quantidade {get; set;}

        public double Preco {get; set;}

        public TipoNegociacao TipoNegociacao { get; set; }

    }

    public enum TipoNegociacao
    {
        Compra = 1, Venda = 2   
    }
}

