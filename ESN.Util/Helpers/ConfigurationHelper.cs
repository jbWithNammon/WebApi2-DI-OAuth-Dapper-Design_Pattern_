using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESN.Util.Helpers
{
   public class ConfigurationHelper
    {
        public static string GetConnectString(string name)
        {
            var result = string.Empty;

            try
            {
                result = ConfigurationManager.ConnectionStrings[name].ConnectionString;
            }
            catch (Exception ex)
            {
                //Log.Error(ex);

                // Try to get from AppSettings
                try
                {
                    result = GetAppSettingValue<string>(name);
                }
                catch
                {
                    result = string.Format("ConnectionString {0} cannot be found, {1} ", name, ex.Message);
                }
            }

            return result;
        }
        public static string GetConnectProvider(string name)
        {
            var result = string.Empty;

            try
            {
                result = ConfigurationManager.ConnectionStrings[name].ProviderName;
            }
            catch (Exception ex)
            {
                //Log.Error(ex);
                result = string.Format("ConnectionProvider {0} cannot be found, {1}", name, ex.Message);
            }

            return result;
        }

        public static string GetAppSetting(string name)
        {
            var result = string.Empty;

            try
            {
                result = ConfigurationManager.AppSettings[name];
            }
            catch (Exception ex)
            {
                //Log.Error(ex);
                result = string.Format("AppSetting {0} cannot be found, {1}", name, ex.Message);
            }

            return result;
        }

        public static T GetAppSettingValue<T>(string name)
        {
            try
            {
                var appSettingValue = GetAppSetting(name);
                var converter = TypeDescriptor.GetConverter(typeof(T));

                if (!string.IsNullOrEmpty(appSettingValue))
                    return (T)converter.ConvertFromInvariantString(appSettingValue);

                return default(T);
            }
            catch (Exception ex)
            {
                //Log.Error(ex);
                return default(T);
            }
        }
    }
}
