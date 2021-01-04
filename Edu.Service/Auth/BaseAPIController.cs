using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Edu.Tools;
using System.Web.Http;
using Edu.Service;

namespace Edu.Service
{
    public class BaseAPIController : ApiController
    {
        protected UnitOfWork unitOfWork = new UnitOfWork();

    }
}
