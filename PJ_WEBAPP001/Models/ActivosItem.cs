using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace PJ_WEBAPP001.Models
{
    public class ActivosItem
    {
        private ACTIVO _activo;

        public ACTIVO Activo
        {
            get { return _activo; }
            set { _activo = value; }
        }

        private int _cantidad;
        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        public ActivosItem()
        {

        }
        public ActivosItem(ACTIVO activo,int cantidad)
        {
            this._activo = activo;
            this._cantidad = cantidad;
        }


    }
}