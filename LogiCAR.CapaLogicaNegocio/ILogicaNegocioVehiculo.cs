using LogiCAR.Entidades;
using System.Collections.Generic;

namespace LogiCAR.CapaLogicaNegocio
{
    public interface ILogicaNegocioVehiculo
    {
        IEnumerable<Vehiculo> Get();

        //void Delete(int id);
        //string Get(int id);
        //void Post([FromBody] string value);
        //void Put(int id, [FromBody] string value);
    }
}