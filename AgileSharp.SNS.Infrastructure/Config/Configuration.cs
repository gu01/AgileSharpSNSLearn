using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using AgileSharp.SNS.Infrastructure.Logging;
using StructureMap;

namespace AgileSharp.SNS.Infrastructure.Config
{
    public class Configuration : IConfiguration
    {
        private string GetConfigurationSetting(string key)
        {
            string value = ConfigurationManager.AppSettings.Get(key);

            if (value == null)
            {
                ObjectFactory.GetInstance<ILogger>().Error(typeof(Configuration), string.Format("AppSetting: {0} is not configured.", key));
            }

            return value;
        }

        #region IConfiguration Members

        public string EmailFromAddress
        {
            get
            {
                return GetConfigurationSetting("EmailFromAddress");
            }
        }

        public string EmailVerifyAddress
        {
            get
            {
                return GetConfigurationSetting("EmailVerifyAddress");
            }
        }

        #endregion
    }
}
