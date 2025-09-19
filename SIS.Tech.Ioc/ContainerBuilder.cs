using SimpleInjector;
using SIS.Tech.IServices;
using SIS.Tech.Services;
using System.Reflection;

namespace SIS.Tech.Ioc
{
    public static class ContainerBuilder
    {
        private static Container _containerWeb;

        static ContainerBuilder()
        {
            _containerWeb = new Container();
            _containerWeb.Options.ResolveUnregisteredConcreteTypes = true;
            
            RegistraApplications();

            RegistraDomain();

            RegistraRepository();

            RegistraServices();

            RegistraMvcControllers();

            _containerWeb.Verify();
        }

        private static void RegistraMvcControllers()
        {
            _containerWeb.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            _containerWeb.RegisterMvcIntegratedFilterProvider();
        }

        private static void RegistraApplications()
        {
            //_containerWeb.Register<ILoginApp, LoginApp>();
        }

        private static void RegistraDomain()
        {
            //_containerWeb.Register<ILoginBo, LoginBo>();
        }

        private static void RegistraRepository()
        {
            //_containerWeb.Register<ILoginRepository, LoginRepository>();           
        }

        private static void RegistraServices()
        {
            _containerWeb.Register<IControleAcesso, ControleAcesso>();
        }

        public static Container GetContainer()
        {
            return _containerWeb;
        }
    }
}
