using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<ParticipantManager>().As<IParticipantService>().SingleInstance();
            //builder.RegisterType<EFParticipantDal>().As<IParticipantDal>().SingleInstance();
            builder.RegisterType<ProductDetailDal>().As<IProductDetailDal>().SingleInstance();
            builder.RegisterType<ProductDetailManager>().As<IProductDetailService>().SingleInstance();
            builder.RegisterType<MailManager>().As<IMailService>().SingleInstance();






        }
    }
}
