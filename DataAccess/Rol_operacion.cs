//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rol_operacion
    {
        public int idRolOperacion { get; set; }
        public int idRol { get; set; }
        public int idOperacion { get; set; }
    
        public virtual Operaciones Operaciones { get; set; }
        public virtual Roles Roles { get; set; }
    }
}