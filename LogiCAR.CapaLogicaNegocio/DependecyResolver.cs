using LogiCAR.DependencyResolver;
using System.ComponentModel.Composition;

namespace LogiCAR.CapaLogicaNegocio
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<ILogicaNegocioVehiculo, LogicaNegocioVehiculo>();
        }
    }
}
