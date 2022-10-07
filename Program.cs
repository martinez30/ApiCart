using ApiCart;

public class Program
{
    public static void Main(string[] args)
    {
        CreateBuilder(args).Build().Run();
    }

    //Construtor padrao com base startup
    public static IHostBuilder CreateBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(builder =>
            {
                builder.UseStartup<Startup>();
            });
}
