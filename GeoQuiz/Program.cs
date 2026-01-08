using Microsoft.Extensions.Configuration;
using GeoQuiz;



namespace GeoQuiz

{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
			var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
	        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
	        .Build();

			DatabaseConfig.ConnectionString =
				config.GetConnectionString("SupabaseDb")
				?? throw new Exception("Connection string 'SupabaseDb' fehlt in appsettings.json");

			Application.Run(new LoginForm());
        }
    }
}