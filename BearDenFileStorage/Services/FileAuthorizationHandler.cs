using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;





//https://docs.microsoft.com/en-us/aspnet/core/security/authorization/resourcebased?tabs=aspnetcore1x




namespace BearDenFileStorage
{
    public class FileAuthorizationHandler :
    AuthorizationHandler<SameOwnerRequirement, UserFileInfo>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       SameOwnerRequirement requirement,
                                                       UserFileInfo resource)
        {
            if (context.User.Identity?.Name == resource.Owner)
            {
                context.Succeed(requirement);
            }

            //TODO: Use the following if targeting a version of
            //.NET Framework older than 4.6:
            //      return Task.FromResult(0);
            return Task.CompletedTask;
        }

       
    }
}
