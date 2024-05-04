using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.ValueObjects;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Papeleria.BusinessLogic.ValueObjects;

namespace Papeleria.LogicaAplicacion.Mappers
{
    public class UsuarioDtoMapper
    {
        public static UsuarioDTO ToDto(Usuario usuario)
        {
            return new UsuarioDTO(usuario);
        }
        public static Usuario FromDto(UsuarioDTO dto)
        {
            //Usuario usuario = new Usuario(dto.email, dto.password, passEncriptada,new NombreCompleto(dto.nombre, dto.apellido));
            return new Usuario
            {
                Id = dto.Id,
                email = dto.email,
                nombreCompleto = new NombreCompleto(dto.nombre, dto.apellido),
                password = dto.password,
                esAdmin = dto.esAdmin
                // aplicar encriptcacion
            };

        }
    }
}
