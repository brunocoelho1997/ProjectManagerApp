using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProjectManagerApp2.Controllers.RolesController.DTO;
using System.Net.Http;
using System.Web.Http.Routing;

namespace ProjectManagerApp2.Controllers.RolesController.Converter
{
    public class RoleDTOFactory
    {
        private UrlHelper _UrlHelper;

        public RoleDTOFactory(HttpRequestMessage request)
        {
            _UrlHelper = new UrlHelper(request);
        }
        public RoleReturnDTO Create(IdentityRole appRole)
        {

            return new RoleReturnDTO
            {
                Url = _UrlHelper.Link("GetRoleById", new { id = appRole.Id }),
                Id = appRole.Id,
                Name = appRole.Name
            };
        }
    }
}