using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;
using DataAccess;
using SimpleInjector;

namespace Common
{
    public class SimpleInjectorCommon
    {
        public static Container RegisterItems(Container container, Lifestyle lifeStyle)
        {
            RegisterItemsDataAccess(container, lifeStyle);
            RegisterItemsDataBusiness(container, lifeStyle);


            return container;
        }

        private static void RegisterItemsDataAccess(Container container, Lifestyle lifeStyle)
        {
            container.Register<IPersonRepository, PersonRepository>(lifeStyle);
            //container.Register<typeof(AdventureContext), AdventureContext > (lifeStyle);
            container.Register<DbContext, AdventureContext>(lifeStyle);
            container.Register<IUnitOfWork, UnitOfWork>(lifeStyle);

            //builder.RegisterType(typeof(SampleArchContext)).As(typeof(DbContext)).InstancePerLifetimeScope();
            //builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerRequest();

        }

        private static void RegisterItemsDataBusiness(Container container, Lifestyle lifeStyle)
        {
            container.Register<IPersonService, PersonService>(lifeStyle);

        }
    }
}
