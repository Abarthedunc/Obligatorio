using Papeleria.BusinessLogic.ValueObjects;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using Papeleria.LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades
{
    public class Cliente : IValidable<Cliente>
    {
        
        public int id { get; set; }
        public string razonSocial { get; set; }
        public string rut { get; set; }
        public Direccion adress { get; set; }
        public double distancia { get; set; }
        public NombreCompletoClientes nombreCompleto { get; set; }
        public Cliente() { }
        public Cliente(string razonSocial, string rut, Direccion direccion,double distancia, NombreCompletoClientes nombreCompletoCli)
        {
            this.razonSocial = razonSocial;
            this.rut = rut;
            this.adress = direccion;
            this.distancia = distancia;
            this.nombreCompleto = nombreCompletoCli;
        }
        public Cliente(string razonSocial, string rut, string calle,  string puerta, string ciudad, double distancia, string nombre, string apellido)
        {
            this.razonSocial = razonSocial;
            this.rut = rut;
            adress = new Direccion(calle, puerta, ciudad);
            this.distancia = distancia;
            nombreCompleto = new NombreCompletoClientes(nombre, apellido);
        }

        public bool EsValido()
        {
            if (ValidarRUT()) return true;
            return false;
        }

        public bool ValidarRUT()
        {
            if (this.rut.Length < 12) return false;
            return true;
        }
    }
}
