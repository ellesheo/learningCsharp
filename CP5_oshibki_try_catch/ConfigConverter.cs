using System;
using System.Collections.Generic;
using System.Text;

namespace CP5_oshibki_try_catch
{
    public class ConfigConverter
    {
        public int GetInt(Dictionary<string, string> config, string key)
        {
            try
            {
                return int.Parse(config[key]);
            }
            catch (KeyNotFoundException ex)
            {
                var wrapped = new InvalidOperationException(
                    $"Нет настройки {key}", ex);
                wrapped.Data["ConfigKey"] = key;
                throw wrapped;
            }
            catch (FormatException ex)
            {
                var wrapped = new InvalidOperationException(
                    $"Настройка {key} не число", ex);
                wrapped.Data["ConfigKey"] = key;
                wrapped.Data["RawValue"] = config[key];
                throw wrapped;
            }
        }
    }
}