using System;

namespace CAD.Core.Negocio.Enums
{
    public class LetraAttribute : Attribute
    {
        public string Letra { get; set; }

        public LetraAttribute(string letra)
        {
            Letra = letra;
        }
    }
}