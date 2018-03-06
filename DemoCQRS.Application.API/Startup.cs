using Autofac;
using Autofac.Integration.WebApi;
using DemoCQRS.Application.Core.CommandStack.Handlers;
using MediatR;
using Owin;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Http;

namespace DemoCQRS.Application.API
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "defaultWebApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new
                {
                    id = RouteParameter.Optional
                });
            IContainer container = BuildContainer();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseWebApi(config);




        }

        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // mediator itself
            builder
              .RegisterType<Mediator>()
              .As<IMediator>()
              .InstancePerLifetimeScope();

            // request handlers
            builder
              .Register<SingleInstanceFactory>(ctx =>
              {
                  var c = ctx.Resolve<IComponentContext>();
                  return t => { object o; return c.TryResolve(t, out o) ? o : null; };
              })
              .InstancePerLifetimeScope();

            // notification handlers
            builder
              .Register<MultiInstanceFactory>(ctx =>
              {
                  var c = ctx.Resolve<IComponentContext>();
                  return t => (IEnumerable<object>)c.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
              })
              .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(FaturasCommandHandler).GetTypeInfo().Assembly).AsImplementedInterfaces(); // via assembly scan

            return builder.Build();
        }


    }
}