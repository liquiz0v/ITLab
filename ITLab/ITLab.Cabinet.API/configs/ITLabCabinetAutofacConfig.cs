using Autofac;
using ITLab.Cabinet.Logic.Helpers.Sql;
using ITLab.Cabinet.Logic.Queries;
using ITLab.Cabinet.Logic.Queries.Interfaces;
using ITLab.Cabinet.Logic.ReadServices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using ITLab.Cabinet.Database.Models;
using ITLab.Cabinet.Logic.ReadServices.Interfaces;
using ITLab.Cabinet.Logic.Repository;
using ITLab.Cabinet.Logic.Repository.Interfaces;
using ITLab.Cabinet.Logic.WriteServices;
using ITLab.Cabinet.Logic.WriteServices.Interfaces;
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

            builder.Register(c => new StudentReadService(c.Resolve<IStudentQueries>()))
                .As<IStudentReadService>()
                .InstancePerLifetimeScope();

            builder.Register(c => new CoursesQueries(c.Resolve<IConnectionStringHelper>()))
                .As<ICoursesQueries>()
                .InstancePerLifetimeScope();

            builder.Register(c => new LessonsQueries(c.Resolve<IConnectionStringHelper>()))
                .As<ILessonsQueries>()
                .InstancePerLifetimeScope();
           
            builder.Register(c => new CoursesReadService(c.Resolve<ICoursesQueries>()))
                .As<ICoursesReadService>()
                .InstancePerLifetimeScope();

            builder.Register(c => new CoursesRepository())
                .As<ICoursesRepository>()
                .InstancePerLifetimeScope();

            builder.Register(c => new StudentRepository())
                .As<IStudentRepository>()
                .InstancePerLifetimeScope();

            builder.Register(c => new CoursesWriteService(c.Resolve<ICoursesRepository>(), c.Resolve<ICoursesQueries>()))
                .As<ICoursesWriteService>()
                .InstancePerLifetimeScope();

            builder.Register(c => new StudentWriteService(c.Resolve<IStudentRepository>(), c.Resolve<IStudentQueries>()))
                .As<IStudentWriteService>()
                .InstancePerLifetimeScope();

            builder.Register(c => new LessonsReadService(c.Resolve<ILessonsQueries>()))
                .As<ILessonsReadService>()
                .InstancePerLifetimeScope();
        }

        public static ContainerBuilder ContainerBuilderConfig(ContainerBuilder builder)
        {
            builder.RegisterType<ConnectionStringHelper>();
            builder.RegisterType<StudentQueries>();
            builder.RegisterType<StudentReadService>();
            builder.RegisterType<CoursesQueries>();
            builder.RegisterType<CoursesReadService>();
            builder.RegisterType<CoursesRepository>();
            builder.RegisterType<StudentRepository>();
            builder.RegisterType<CoursesWriteService>();
            builder.RegisterType<StudentWriteService>();

            builder.RegisterType<LessonsQueries>();
            builder.RegisterType<LessonsReadService>();

            return builder;
        }
    }
}
