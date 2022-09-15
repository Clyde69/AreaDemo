using AreaDemo_Core;

await Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults((webBuilder) =>
    {
        webBuilder.UseStartup<Startup>();
    })
    .Build()
    .RunAsync();