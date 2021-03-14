﻿using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepsWebApp.Authentication
{
    public class AuthSchemaOptions : AuthenticationSchemeOptions
    {
        public AuthSchemaOptions()
        {
            ClaimsIssuer = AuthSchema.Issuer;
        }
    }
}
