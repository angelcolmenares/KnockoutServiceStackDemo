using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ServiceStack.CacheAccess;
using ServiceStack.CacheAccess.Providers;
using ServiceStack.Common.Web;
using ServiceStack.Configuration;
using ServiceStack.Mvc;
using ServiceStack.WebHost.Endpoints;
using KnockoutServiceStackDemo.Controllers;
using KnockoutServiceStackDemo.Models;

namespace KnockoutServiceStackDemo
{
	public class AppHost:AppHostBase
	{
		public AppHost (): base("StarterTemplate ASP.NET Host", typeof(HomeController).Assembly) { }

		//public static AppConfig Config;

		public override void Configure(Funq.Container container)
		{
			//Set JSON web services to return idiomatic JSON camelCase properties
			ServiceStack.Text.JsConfig.EmitCamelCaseNames = true;

			//Register Typed Config some services might need to access
			//var appSettings = new AppSettings();
			//Config = new AppConfig(appSettings);
			//container.Register(Config);

			//Register all your dependencies: 

			//Register a external dependency-free 
			//container.Register<ICacheClient>(new MemoryCacheClient());
			//Configure an alt. distributed peristed cache that survives AppDomain restarts. e.g Redis
			//container.Register<IRedisClientsManager>(c => new PooledRedisClientManager("localhost:6379"));

			var model = new GiftListModel
			  {
			    Gifts = new List<GiftModel>
			        {
			          new GiftModel {Title = "Tall Hat", Price = 49.95},
			          new GiftModel {Title = "Long Cloak", Price = 78.25}
			        }
			  };
			container.Register<GiftListModel>( model);

			//Enable Authentication an Registration
			//ConfigureAuth(container);

			//Create you're own custom User table
			//var dbFactory = container.Resolve<IDbConnectionFactory>();
			//dbFactory.Exec(dbCmd => dbCmd.CreateTable<User>(overwrite: true));

			//Register application services
			//container.Register(new TodoRepository());
			//container.Register<ITwitterGateway>(new TwitterGateway());

			//Configure Custom User Defined REST Paths for your services
			//ConfigureServiceRoutes();

			//Change the default ServiceStack configuration
			//const Feature disableFeatures = Feature.Jsv | Feature.Soap;
			SetConfig(new EndpointHostConfig {
				//EnableFeatures = Feature.All.Remove(disableFeatures),
				AppendUtf8CharsetOnContentTypes = new HashSet<string> { ContentType.Html },
				DebugMode = true, //Show StackTraces in service responses during development
			});

			//Set MVC to use the same Funq IOC as ServiceStack
			ControllerBuilder.Current.SetControllerFactory(new FunqControllerFactory(container));
			//ServiceStackController.CatchAllController = reqCtx => container.TryResolve<HomeController>();
		}
	}
}

