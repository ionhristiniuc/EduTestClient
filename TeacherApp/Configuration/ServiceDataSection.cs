using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace TeacherApp.Configuration
{
    public class ServiceDataSection : ConfigurationSection
    {
        [ConfigurationProperty("serviceUrl", IsRequired = true)]
        public string ServiceUrl
        {
            get
            {
                return (string) this["serviceUrl"];
            }
            set
            {
                this["serviceUrl"] = value;
            }
        }

        [ConfigurationProperty("authPath", IsRequired = true)]
        public string AuthPath
        {
            get
            {
                return (string)this["authPath"];
            }
            set
            {
                this["authPath"] = value;
            }
        }

        [ConfigurationProperty("clientId", IsRequired = true)]
        public string ClientId
        {
            get
            {
                return (string)this["clientId"];
            }
            set
            {
                this["clientId"] = value;
            }
        }

        [ConfigurationProperty("clientSecret", IsRequired = true)]
        public string ClientSecret
        {
            get
            {
                return (string)this["clientSecret"];
            }
            set
            {
                this["clientSecret"] = value;
            }
        }
    }
}