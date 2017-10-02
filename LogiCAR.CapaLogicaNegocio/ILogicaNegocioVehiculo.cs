using LogiCAR.Entidades;
using System.Collections.Generic;
using System.Web.Http;

namespace LogiCAR.CapaLogicaNegocio
{
    public interface ILogicaNegocioVehiculo
    {
        IEnumerable<Vehiculo> Get();

        void Put(int id, [FromBody] string value);
        //void Delete(int id);
        //string Get(int id);
        //void Post([FromBody] string value);

    }
}