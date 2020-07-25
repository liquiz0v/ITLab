using Autofac;
using ITLab.Cabinet.Logic.Helpers.Sql;
using ITLab.Cabinet.Logic.Queries;
using ITLab.Cabinet.Logic.Queries.Interfaces;
using ITLab.Cabinet.Logic.Services;
using ITLab.Cabinet.Logic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ITLab.Cabinet.API.configs
{
    public class ITLabCabinetAutofacConfig : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new ConnectionStringHelper(c.Resolve<IConfiguration>())) // ConfigurationManager.ConnectionStrings["CabinetConnection"].ConnectionString
                .As<IConnectionStringHelper>()
                .InstancePerLifetimeScope();

            builder.Register(c => new StudentQueries(c.Resolve<IConnectionStringHelper>()))
                .As<IStudentQueries>()
                .InstancePerLifetimeScope();

            builder.Register(c => new StudentService(c.Resolve<IStudentQueries>()))
                .As<IStudentService>()
                .InstancePerLifetimeScope();

            builder.Register(c => new CoursesQueries(c.Resolve<IConnectionStringHelper>()))
                .As<ICoursesQueries>()
                .InstancePerLifetimeScope();

            builder.Register(c => new CoursesService(c.Resolve<ICoursesQueries>()))
                .As<ICoursesService>()
                .InstancePerLifetimeScope();
        }

        public static ContainerBuilder ContainerBuilderConfig(ContainerBuilder builder)
        {
            builder.RegisterType<ConnectionStringHelper>();
            builder.RegisterType<StudentQueries>();
            builder.RegisterType<StudentService>();
            builder.RegisterType<CoursesQueries>();
            builder.RegisterType<CoursesService>();

            return builder;
        }
    }
}
