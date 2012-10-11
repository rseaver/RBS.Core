using System;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using RBS.Core.config;

namespace RBS.Core.Domain.Tools
{
    public class NHSetupConfig : INHSetupConfig
    {
        public IPersistenceConfigurer DBConfiguration(string connectionString)
        {
            return MsSqlConfiguration
                .MsSql2008
                .ConnectionString(x => x.Is(connectionString))
                .UseOuterJoin()
                .ShowSql();
        }

        public Action<MappingConfiguration> MappingConfiguration()
        {
        	return (m => m.FluentMappings.AddFromAssemblyOf<Entity>()
        	             	.Conventions.Add(ForeignKey.EndsWith("Id"))
        	             	.Conventions.Add(DefaultLazy.Always())
        	             	.Conventions.Add(DefaultCascade.SaveUpdate()));
        }

        public void GenerateSchema(Configuration config)
        {
            new SchemaExport(config).Create(true, true);
        }
    }

}