using Contracts;
using Microsoft.AspNetCore.Http;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class UserProviderService : IUserProviderService
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly ILoggerManager _logger;


        public UserProviderService(IHttpContextAccessor httpContext, ILoggerManager logger)
        {
            _httpContext = httpContext ?? throw new ArgumentNullException(nameof(httpContext));
            _logger = logger;
        }

        public string GetUserId()
        {
            return _httpContext.HttpContext.User.Claims
                .First(i => i.Type == ClaimTypes.NameIdentifier).Value;
        }

    }
}
