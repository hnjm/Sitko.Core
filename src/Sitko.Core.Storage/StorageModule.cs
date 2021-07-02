using Microsoft.Extensions.DependencyInjection;
using Sitko.Core.App;

namespace Sitko.Core.Storage
{
    public interface IStorageModule : IApplicationModule
    {
    }

    public abstract class StorageModule<TStorage, TStorageOptions> : BaseApplicationModule<TStorageOptions>,
        IStorageModule
        where TStorage : Storage<TStorageOptions> where TStorageOptions : StorageOptions, new()
    {
        public override void ConfigureServices(ApplicationContext context, IServiceCollection services,
            TStorageOptions startupOptions)
        {
            base.ConfigureServices(context, services, startupOptions);
            services.AddSingleton<IStorage<TStorageOptions>, TStorage>();
            services.AddSingleton<TStorage>();
        }
    }
}
