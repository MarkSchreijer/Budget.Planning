using System.Web.Mvc;
using Budget.Planning.DataAccess;
using Budget.Planning.Logic;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;

namespace Budget.Planning.Web
{
    public static class UnityBootstrapper
    {
        public static IUnityContainer Initialize()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            RegisterTypes(container);
            return container;
        }

        private static void RegisterTypes(IUnityContainer container)
        {
            // register all your components with the container here
            // This is the important line to edit
            container.RegisterType<ISync, Sync>();
            container.RegisterType<IAccountNumberStore, AccountNumberStore>();
        }
    }
}