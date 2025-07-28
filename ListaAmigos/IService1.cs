using ListaAmigos.Modelos;
using System.Collections.Generic;
using System.ServiceModel;

namespace ListaAmigosService
{
    [ServiceContract]
    public interface IListaAmigosService
    {
        [OperationContract]
        void AgregarAmigo(Amigo amigo);

        [OperationContract]
        List<Amigo> ObtenerAmigos();

        [OperationContract]
        Amigo BuscarPorAlias(string alias);

        [OperationContract]
        bool CambiarEstado(string alias, bool nuevoEstado);
    }
}
