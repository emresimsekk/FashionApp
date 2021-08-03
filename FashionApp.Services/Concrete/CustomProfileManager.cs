using FashionApp.Entities.Concrete;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FashionApp.Services.Concrete
{
    public class CustomProfileManager : IProfileService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public CustomProfileManager(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var subId = context.Subject.GetSubjectId();
            var user = await _userManager.FindByIdAsync(subId);

            var claims = new List<Claim>()
            {
                new Claim("UserId",subId),
                //new Claim(JwtRegisteredClaimNames.Email,user.Email ),

            };
            
            context.AddRequestedClaims(claims);
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var subId = context.Subject.GetSubjectId();

            var user = await _userManager.FindByIdAsync(subId);
            context.IsActive = user != null ? true : false;
        }
    }
}
