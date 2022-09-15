using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.Extensions.FileProviders;
using System.Reflection;

namespace AreaDemo_Core.Extensions
{
    public static class IServiceCollectionExtensions
    {
        //public static void ConfigureCompositeFileProvider(this IServiceCollection services, IWebHostEnvironment env)
        //{
        //    var physicalProvider = env.ContentRootFileProvider;
        //    var manifestEmbeddedProvider =
        //        new ManifestEmbeddedFileProvider(typeof(NewArea_Core.Controllers.NewAreaController).Assembly);
        //    var compositeProvider =
        //        new CompositeFileProvider(physicalProvider, manifestEmbeddedProvider);

        //    services.AddSingleton<IFileProvider>(compositeProvider);    
        //}

        public static void AddMvcWithExternalAreas(this IServiceCollection services)
        {
            var areas = AppDomain.CurrentDomain.GetAssemblies().Where(w => w.ManifestModule.Name.Contains("NewArea")).ToList();

            var appParts = areas.Where(w => !w.FullName.Contains(".Views.")).Select((ass) => new AssemblyPart(ass)).ToList();

            services.AddControllersWithViews()
                .ConfigureApplicationPartManager(apm =>
                    appParts.ForEach(part => apm.ApplicationParts.Add(part)));
        }

        //public static void AddMvcWithExternalAreas(this IServiceCollection services)
        //{
        //    var areas = AppDomain.CurrentDomain.GetAssemblies().Where(w => w.ManifestModule.Name.Contains("NewArea"))
        //        .Concat(new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).GetDirectories()
        //        .First(w => w.Name == "OptionalAreas").GetFiles().Where(w => w.Name.Contains("NewArea")).Select(s => Assembly.LoadFrom(s.FullName)));

        //    var appParts = areas.Where(w => !w.FullName.Contains(".Views.")).Select((ass) => new AssemblyPart(ass)).ToList();
        //    var fileProviders = areas.Where(w => w.FullName.Contains(".Views.")).Select((ass) => new EmbeddedFileProvider(ass)).ToList();
        //    services.AddControllersWithViews()
        //        .ConfigureApplicationPartManager(apm => 
        //            appParts.ForEach(part => apm.ApplicationParts.Add(part)));

        //    services.Configure<MvcRazorRuntimeCompilationOptions>(options => 
        //        fileProviders.ForEach(provider => options.FileProviders.Add(provider)));
        //}
    }
}
