//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PJ_WEBAPP001.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DETALLESOLICITUD
    {
        public int IDE_DET { get; set; }
        public Nullable<int> NUM_SOL { get; set; }
        public Nullable<int> IDE_ACT { get; set; }
        public Nullable<int> CAN_ART { get; set; }
    
        public virtual ACTIVO ACTIVO { get; set; }
        public virtual SOLICITUD SOLICITUD { get; set; }
    }
}