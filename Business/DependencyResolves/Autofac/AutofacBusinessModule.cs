using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolves.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<CharacterManager>().As<ICharacterService>().SingleInstance();
            builder.RegisterType<EfCharacterDal>().As<ICharacterDal>().SingleInstance();

            builder.RegisterType<EnemyManager>().As<IEnemyService>().SingleInstance();
            builder.RegisterType<EfEnemyDal>().As<IEnemyDal>().SingleInstance();            
            
            builder.RegisterType<GameManager>().As<IGameService>().SingleInstance();
            builder.RegisterType<EfGameDal>().As<IGameDal>().SingleInstance();            
            
            builder.RegisterType<StoreManager>().As<IStoreService>().SingleInstance();
            builder.RegisterType<EfStoreDal>().As<IStoreDal>().SingleInstance();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}