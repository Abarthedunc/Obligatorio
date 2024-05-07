using Microsoft.EntityFrameworkCore;
using Papeleria.BusinessLogic.ValueObjects;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using Papeleria.LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades
{
    [Index (nameof(email), IsUnique =  true)]
    public class Usuario : IValidable<Usuario>
    {
        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public NombreCompleto nombreCompleto { get; set; }
        public bool esAdmin { get; set; }
        public Usuario() { }

        public bool EsValido()
        {
            if(ValidarMail()&&
            ValidarNombreCompleto())
            {
                return true;
            }
            return false;
            
        }
        public bool ValidarMail()
        {
            if (this.email.Contains("@")&& this.email.Substring((email.Length - 4), 4) == ".com") return true;
            return false;
        }
        
        public bool ValidarNombreCompleto()
        {
            if(!ValidarNombre(this.nombreCompleto.nombre)) return false;
            if (!ValidarNombre(this.nombreCompleto.apellido)) return false;
            return true;
        }
        public bool ValidarNombre(string parteNombre)
        {
            //el nombre y el apellido solamente pueden contener caracteres
            //alfabéticos, espacio, apóstrofe o guión del medio.Los caracteres no alfabéticos no pueden estar ubicados al
            //principio ni al final de la cadena.
            for(int i= 0; i< parteNombre.Length; i++)
            {
                char c= parteNombre[i];
                if (!ValidarCaracterNombre(c)) return false;
                if (i == 0 || i== parteNombre.Length-1 )
                {
                    if(!char.IsLower(c) && !char.IsUpper(c))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private bool ValidarCaracterNombre(char letra)
        {
            char[] caracteresPuntuacion = { ' ', '-', '\'' };
            if (char.IsUpper(letra) || char.IsLower(letra)|| char.IsDigit(letra) || caracteresPuntuacion.Contains(letra))
            {
                return true;
            }
            return false;
        }
       
        public bool ValidarPassword(string contrasena)
        {
            bool tieneMayuscula = false;
            bool tieneMinuscula = false;
            bool tieneDigito = false;
            bool tienePuntuacion = false;
            char[] caracteresPuntuacion = { '.', ';', ',', '!' };
            if (contrasena.Length < 6) return false;
            foreach (char c in contrasena)
            {
                if (char.IsUpper(c))
                {
                    tieneMayuscula = true;
                }
                if (char.IsLower(c))
                {
                    tieneMinuscula = true;
                }
                if (char.IsDigit(c))
                {
                    tieneDigito = true;
                }
                if (caracteresPuntuacion.Contains(c))
                {
                    tienePuntuacion = true;
                }
                if (tieneMayuscula && tieneMinuscula && tieneDigito && tienePuntuacion)
                {
                    return true;
                }
            }
            return tieneMayuscula && tieneMinuscula && tieneDigito && tienePuntuacion;
        }

        


        /*public Usuario(string Email, string PasswordNoEncriptada,string PasswordEncriptada, NombreCompleto nombreEntero)
            {
               email = Email;
               nombreCompleto = nombreEntero;
               passwordNoEncriptada = PasswordNoEncriptada;
               passwordEncriptada = PasswordEncriptada;
            }*/

    }
}
