// Add  OA roles from database to AD claims.﻿
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TRACSNarrative.Data;
using System.Diagnostics;

namespace TRACSNarrative
{
    public class ClaimsTransformer : IClaimsTransformation
    {
        private readonly UserContext _context;

        public ClaimsTransformer(UserContext context)
        {      
            _context = context;
        }

        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {

            var identity = (ClaimsIdentity)principal.Identity;
            var userName = identity.Name;
            var roles = _context.Role.Where(r => r.UserRoles.Any(u => u.User.UserName == userName)).Select(r => r.RoleId);
            foreach (var role in roles)
            {
                var claim = new Claim("Role", role.ToString().Trim());
                identity.AddClaim(claim);
            }
            return Task.FromResult(principal);
        }
    }
}

