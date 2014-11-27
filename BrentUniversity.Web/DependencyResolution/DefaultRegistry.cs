using System.Web;
using BrentUniversity.Data;
using BrentUniversity.Repository;
using BrentUniversity.Repository.Base;
using BrentUniversity.Service;
using BrentUniversity.Service.Base;
using BrentUniversity.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using StructureMap.Web;
using System.Data.Entity;

namespace BrentUniversity.Web.DependencyResolution {
	
    public class DefaultRegistry : Registry {
        #region Constructors and Destructors

        public DefaultRegistry() {
            Scan(
                scan => {
                    scan.LookForRegistries();
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
					scan.With(new ControllerConvention());
                });
            
            For<IUnitOfWork>().HybridHttpOrThreadLocalScoped().Use<UnitOfWork>();
            For<IDbContext>().HybridHttpOrThreadLocalScoped().Use<UniversityContext>();
            For<IStudentService>().HybridHttpOrThreadLocalScoped().Use<StudentService>();
            For<DbContext>().HybridHttpOrThreadLocalScoped().Use(() => new ApplicationDbContext());
            For<IAuthenticationManager>().Use(o => HttpContext.Current.GetOwinContext().Authentication);
            For(typeof(IGenericRepository<>)).HybridHttpOrThreadLocalScoped().Use(typeof(GenericRepository<>));
            For<IUserStore<ApplicationUser>>().HybridHttpOrThreadLocalScoped().Use<UserStore<ApplicationUser>>();
        }
        #endregion
    }
}