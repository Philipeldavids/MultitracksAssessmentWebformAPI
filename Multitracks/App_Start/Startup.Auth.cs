using Newtonsoft.Json.Serialization;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;

namespace Multitracks
{
	public partial class Startup
	{
		public void ConfigureAuth(IAppBuilder app)
		{
			var config = new HttpConfiguration();

			WebApiConfig.Register(config);

            config.Formatters.Remove(config.Formatters.XmlFormatter);
			config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
			config.Formatters.JsonFormatter.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;

			app.UseWebApi(config);
		}

	}
}