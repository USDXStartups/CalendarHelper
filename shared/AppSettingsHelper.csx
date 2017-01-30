#load "LogHelper.csx"
#load "FunctionNameHelper.csx"

using System.Configuration;

public static class AppSettingsHelper
{
    public static string GetAppSetting(string SettingName, bool LogValue = true )
    {

        string SettingValue = "";
        string methodName = this.GetType().FullName;

        try
        {
            SettingValue = ConfigurationManager.AppSettings[SettingName].ToString();

            if ((!String.IsNullOrEmpty(SettingValue)) && LogValue)
            {
                LogHelper.Info($"{FunctionnameHelper} {GetFunctionName()} {methodName} Retreived AppSetting {SettingName} with a value of {SettingValue}");    
            }
            else if((!String.IsNullOrEmpty(SettingValue)) && !LogValue)
            {
                 LogHelper.Info($"{FunctionnameHelper} {methodName} Retreived AppSetting {SettingName} but logging value was turned off");  
            }
            else if(!String.IsNullOrEmpty(SettingValue))
            {
                LogHelper.Info($"{FunctionnameHelper} {methodName} AppSetting {SettingName} was null or empty");
            }

        }
        catch (ConfigurationErrorsException ex)
        {
            LogHelper.Error($"{FunctionnameHelper} {methodName} Unable to find AppSetting {SettingName} with exception of {ex.Message}");
        }
        catch (System.Exception ex)
        {
            LogHelper.Error($"{FunctionnameHelper} {methodName} Looking for AppSetting {SettingName} caused an exception of {ex.Message}");
        }

        return SettingValue;

    }

}