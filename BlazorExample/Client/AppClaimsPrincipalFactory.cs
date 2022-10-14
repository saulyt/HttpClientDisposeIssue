using BlazorExample.Shared;
using Csla;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;
using System.Security.Claims;
using System.Security.Principal;

namespace BlazorExample.Client
{
    public class AppClaimsPrincipalFactory<TAccount> : AccountClaimsPrincipalFactory<TAccount> where TAccount : RemoteUserAccount
    {
        private readonly IServiceProvider _serviceProvider;
        public AppClaimsPrincipalFactory(IAccessTokenProviderAccessor accessor, IServiceProvider serviceProvider)
        : base(accessor)
        {
            _serviceProvider = serviceProvider;
        }

        public async override ValueTask<ClaimsPrincipal> CreateUserAsync(TAccount account, RemoteAuthenticationUserOptions options)
        {
            var user = await base.CreateUserAsync(account, options);
            //getting any DataPortal<T> over here will cause the HttpClient to get disposed when
            //a DataPortal<T>.CreateAsync() that is set to RunLocal is used anywhere in the app. See ListPerson.razor for example
            var userPortal = _serviceProvider.GetService<IDataPortal<UserEdit>>();

            if (account != null)
            {
                var identity = user.Identity as ClaimsIdentity;
                //fetch user with userPortal.FetchAsync
                //add claims from fetched user
            }
            return user;
        }


    }
}
