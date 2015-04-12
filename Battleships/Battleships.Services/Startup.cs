using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Battleships.Services.Startup))]

namespace Battleships.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.Entity;
    using System.Reflection;
    using System.Web.Http;

    using Ninject;
    using Ninject.Web.Common.OwinHost;
    using Ninject.Web.WebApi.OwinHost;

    using Battleships.Data;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.UseNinjectMiddleware(this.CreateKernel).UseNinjectWebApi(GlobalConfiguration.Configuration);
        }

        private IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            this.RegisterMapping(kernel);

            return kernel;
        }

        private void RegisterMapping(IKernel kernel)
        {
            //kernel.Bind<DbContext>().To<ApplicationDbContext>();
            kernel.Bind<IBattleshipsData>().To<BattleshipsData>()
                .WithConstructorArgument("context", c => new ApplicationDbContext());
        }
    }
}
