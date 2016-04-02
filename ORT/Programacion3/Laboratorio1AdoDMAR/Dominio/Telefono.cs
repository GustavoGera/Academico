using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Telefono
    {
        private int idContacto;

        public int IdContacto
        {
            get { return idContacto; }
            set { idContacto = value; }
        }
        private int idTelefono;

        public int IdTelefono
        {
            get { return idTelefono; }
            set { idTelefono = value; }
        }
        private static int ultId;

        public static int UltId
        {
            get { return Telefono.ultId; }
            set { Telefono.ultId = value; }
        }
        private int numero;

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }
        private string tipoNumero;

        public string TipoNumero
        {
            get { return tipoNumero; }
            set { tipoNumero = value; }
        }



        public Telefono(int idContacto, int numero, string tipoNumero)
        {
            this.idContacto = idContacto;
            this.numero = numero;
            this.tipoNumero = tipoNumero;
            this.idTelefono = ultId++;
        }
    }
}
