namespace KanbanApp.API.Configurations
{
    public class CorsConfiguration
    {
        public static void AddCorsConfiguration(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("KanbanPolicy", builder =>
                {
                    builder.WithOrigins("http://localhost:44334",
                                        "https://localhost:44334")
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
        }

        public static void UseCorsConfiguration(IApplicationBuilder app)
        {
            app.UseCors("KanbanPolicy");
        }
    }
}