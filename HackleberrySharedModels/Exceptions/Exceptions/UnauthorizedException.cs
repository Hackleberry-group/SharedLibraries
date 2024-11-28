﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HackleberrySharedModels.Exceptions
{
    public class UnauthorizedException : ApiException
    {
        public override HttpStatusCode StatusCode { get; protected set; } = HttpStatusCode.Unauthorized;
    }
}