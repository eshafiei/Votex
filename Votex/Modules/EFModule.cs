using Autofac;
using Votex.Models;
using Votex.Models.Core;
using Votex.Models.Persistence;

namespace Votex.Modules
{
    public class EfModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>()
                   .As<IUnitOfWork>()
                   .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationDbContext>().AsSelf();
        }
    }
}