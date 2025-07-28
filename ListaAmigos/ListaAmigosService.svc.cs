using ListaAmigos.Modelos;
using System.Collections.Generic;
using System.Linq;

namespace ListaAmigosService
{
    public class ListaAmigosService : IListaAmigosService
    {
        private static List<Amigo> amigos = new List<Amigo>();

        public void AgregarAmigo(Amigo amigo)
        {
            amigos.Add(amigo);
        }

        public List<Amigo> ObtenerAmigos()
        {
            return amigos;
        }

        public Amigo BuscarPorAlias(string alias)
        {
            return amigos.FirstOrDefault(a => a.Alias == alias);
        }

        public bool CambiarEstado(string alias, bool nuevoEstado)
        {
            var amigo = BuscarPorAlias(alias);
            if (amigo != null)
            {
                amigo.EsActivo = nuevoEstado;
                return true;
            }
            return false;
        }
    }
}
