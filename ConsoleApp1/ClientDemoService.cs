using contract;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Modeling;

namespace ConsoleApp1
{
    public class ClientDemoService : ITransientDependency
    {

        private readonly IUser _user;

        private readonly AbpRemoteServiceOptions _remoteServiceOptions;

        public ClientDemoService(IUser productAppService, IOptions<AbpRemoteServiceOptions> remoteServiceOptions)
        {
            _remoteServiceOptions = remoteServiceOptions.Value;
            _user = productAppService;
        }

        public async Task RunAsync()
        {
            var url = GetServerUrl();
            await TestProductService();
        }




        /// <summary>
        /// Shows how to use application service interfaces (IProductAppService in this sample)
        /// to call a remote service which is possible by the dynamic http client proxy system.
        /// No need to use IIdentityModelAuthenticationService since the dynamic http client proxy
        /// system internally uses it. You just inject a service (IProductAppService)
        /// and call a method (GetListAsync) like a local method.
        /// </summary>
        private async Task TestProductService()
        {
            Console.WriteLine();
            Console.WriteLine("*** TestProductService ************************************");

            try
            {
                var output = _user.GetUser();
                Console.WriteLine(output.Email);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private string GetServerUrl()
        {
            return _remoteServiceOptions.RemoteServices.Default.BaseUrl.EnsureEndsWith('/');
        }
    }
}
