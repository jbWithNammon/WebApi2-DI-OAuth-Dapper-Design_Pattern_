using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ESN.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ESN.Api.DIExtension
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ICustomerBLL>().ImplementedBy<CustomerBLL>().LifestylePerWebRequest());
            container.Register(Component.For<IProductBLL>().ImplementedBy<ProductBLL>().LifestylePerWebRequest());
            container.Register(Component.For<ICourseBLL>().ImplementedBy<CourseBLL>().LifestylePerWebRequest());
            container.Register(Component.For<ICourseListBLL>().ImplementedBy<CourseListBLL>().LifestylePerWebRequest());
            container.Register(Component.For<ICategoryManagementBLL>().ImplementedBy<CategoryManagementBLL>().LifestylePerWebRequest());
            container.Register(Component.For<IMediaTypeBLL>().ImplementedBy<MediaTypeBLL>().LifestylePerWebRequest());
            container.Register(Component.For<ICourseContentBLL>().ImplementedBy<CourseContentBLL>().LifestylePerWebRequest());
            container.Register(Component.For<IExaminationBLL>().ImplementedBy<ExaminationBLL>().LifestylePerWebRequest());
            container.Register(Component.For<IEmployeeBLL>().ImplementedBy<EmployeeBLL>().LifestylePerWebRequest());
            container.Register(Component.For<IDepartmentBLL>().ImplementedBy<DepartmentBLL>().LifestylePerWebRequest());
            container.Register(Component.For<IDivisionBLL>().ImplementedBy<DivisionBLL>().LifestylePerWebRequest());
            container.Register(Component.For<IPositionBLL>().ImplementedBy<PositionBLL>().LifestylePerWebRequest());
            container.Register(Component.For<IWorkExperienceBLL>().ImplementedBy<WorkExperienceBLL>().LifestylePerWebRequest());
        }
    }
}