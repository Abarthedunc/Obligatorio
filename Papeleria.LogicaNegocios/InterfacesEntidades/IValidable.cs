﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.InterfacesEntidades
{
    public interface IValidable<T> where T : class
    {
        /// <summary>
        /// Este método valida que la entidad sea válida. Si no lo es, lanza una excepción
        /// </summary>
        /// <param name="entidad">La entidad a validar. Ya debe incluir las properties asignadas, y lo solemos invocar en el constructor</param>
        bool EsValido();
    }
}
