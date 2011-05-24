﻿using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glimpse.Core.Extensibility;

namespace Glimpse.Core.Plugin
{
    [GlimpsePlugin(SessionRequired = true)]
    internal class Session : IGlimpsePlugin, IProvideGlimpseHelp
    {
        public string Name
        {
            get { return "Session"; }
        }

        public object GetData(HttpApplication application)
        {
            var session = application.Session;

            var result = new List<object[]>
                             {
                                 new[] {"Key", "Value", "Type"}
                             };

            result.AddRange(from object key in session.Keys
                            let value = session[key.ToString()]
                            let type = value.GetType()
                            select new[] {key.ToString(), value, type.ToString()});

            if (result.Count > 1) return result;

            return null;
        }

        public void SetupInit(HttpApplication application)
        {
        }

        public string HelpUrl
        {
            get { return "http://getGlimpse.com/Help/Plugin/Session"; }
        }
    }
}