﻿using System;
using System.Linq;
using System.Configuration;

namespace Load_bank_files.Class.config
{
    public class ConfigurationSettings
    {
        protected static object GetAppSetting(Type expectedType, string key)
        {
			try
			{
				string value = ConfigurationManager.AppSettings.Get(key);
				if (expectedType == typeof(int))
					return int.Parse(value);
				if (expectedType == typeof(string))
					return value;

				throw new Exception("Type not supported.");
			}
			catch (Exception ex)
			{
				throw new Exception(string.Format("Config key:{0} was expected to be of type {1} but was not.",
					key, expectedType), ex);
			}
		}
    }
}
