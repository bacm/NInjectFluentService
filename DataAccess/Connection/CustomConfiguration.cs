using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Mapping;
using NHibernate.Cfg;

namespace DataAccess.Connection
{
    public abstract class CustomConfiguration : ICustomConfiguration
    {
        protected static string ConfigFile = @"C:\Users\Bruno\Documents\factory";
        protected abstract IPersistenceConfigurer CreatePersistenceConfigurer();

        private static Configuration _configuration;

        public Configuration Configuration
        {
            get
            {
                if (_configuration == null)
                {
                    if (File.Exists(ConfigFile) && IsConfigurationFileValid())
                    {
                        _configuration = LoadConfigurationFromFile();
                        if (_configuration != null)
                        {
                            return _configuration;
                        }
                    }

                    _configuration =
                        Fluently.Configure()
                                .Database(CreatePersistenceConfigurer)
                                .Mappings(m => m.FluentMappings.AddFromAssembly(typeof (PersonMap).Assembly)
                                                .Conventions.Add(
                                                    FluentNHibernate.Conventions.Helpers.DefaultLazy.Never()))
                                .Cache(c => c.UseQueryCache())
                                .BuildConfiguration();

                    SaveConfigurationToFile();
                }
                return _configuration;
            }
        }

        private static Configuration LoadConfigurationFromFile()
        {
            var file = File.Open(ConfigFile, FileMode.Open);
            var bf = new BinaryFormatter();
            var config = bf.Deserialize(file) as Configuration;
            file.Close();
            return config;
        }

        private static void SaveConfigurationToFile()
        {
            var file = File.Open(ConfigFile, FileMode.Create);
            var bf = new BinaryFormatter();
            bf.Serialize(file, _configuration);
            file.Close();
        }

        private static Boolean IsConfigurationFileValid()
        {
            var ass = Assembly.GetCallingAssembly();
            var configInfo = new FileInfo(ConfigFile);
            var assInfo = new FileInfo(ass.Location);
            if (configInfo.LastWriteTime < assInfo.LastWriteTime)
                return false;
            return true;
        }
    }
}