using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Dominio
{
    class Contacto
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private static int ultId;
        private string nombre;
        private string direccion;
        private string mail;

        public bool Save()
        {
            string consulta = "Contactos_Insert";
            CommandType tipo = CommandType.StoredProcedure;
            List<SqlParameter> lst = new List<SqlParameter>();
            lst.Add(new SqlParameter("@nombre", this.nombre));
            lst.Add(new SqlParameter("@direccion", this.direccion));
            lst.Add(new SqlParameter("@mail", this.mail));
            Object retorno = AccesoDatos.EjecutarEscalar(consulta, lst, tipo);
            if (retorno != null) this.id = (int)retorno;
            return this.id > 0;
        }

        public Contacto(string nombre, string direccion)
        {
            this.direccion = direccion;
            this.nombre = nombre;
            this.id = ultId++;
        }
    }
}
