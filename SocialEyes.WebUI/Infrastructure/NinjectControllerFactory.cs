using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Moq;
using SocialEyes.Domain.Abstract;
using SocialEyes.Domain.Entities;


namespace SocialEyes.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
                ? null
                : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            //we will add our bindings here later
            Mock<IEventRepository> mock = new Mock<IEventRepository>();
            mock.Setup(m => m.Events).Returns(new List<Event>{
                new Event {EventID = 1, Name = "Annual Golf Classic"},
                new Event {EventID = 2, Name = "Wine Tasting Evening"},
                new Event {EventID = 3, Name = "Surfing Weekend"}
            }.AsQueryable());

            ninjectKernel.Bind<IEventRepository>().ToConstant(mock.Object);
        }
    }
}