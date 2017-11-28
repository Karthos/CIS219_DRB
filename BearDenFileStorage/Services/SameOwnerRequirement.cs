using Microsoft.AspNetCore.Authorization;

namespace BearDenFileStorage
{
    public class SameOwnerRequirement : IAuthorizationRequirement
    {
    }
}