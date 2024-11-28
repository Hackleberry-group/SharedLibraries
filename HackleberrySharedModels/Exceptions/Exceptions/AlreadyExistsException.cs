using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HackleberrySharedModels.Exceptions
{
    public class AlreadyExistsException : ApiException
    {
        public override HttpStatusCode StatusCode { get; protected set; } = HttpStatusCode.Conflict;
    }
}
