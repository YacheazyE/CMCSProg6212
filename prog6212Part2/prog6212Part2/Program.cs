//References
//1.	Http Post method in Asp.net Core Web API | Asp.net core Web API 8.0 - Just Pick and Learn. 2024. YouTube video, added by Just Pick and Learn. [Online]. Available at: https://www.youtube.com/watch?v=wPN1oR7c7JE  [Accessed 16 October 2024]
//2.	MicrosoftLearn. 2024. Part 6, controller methods and views in ASP.NET Core, 26/07/2024. [Online]. Available at: https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/controller-methods-views?view=aspnetcore-8.0 [Accessed 16 October 2024].
//3.	How to Convert API JSON to C# Classes using ASP .NET Core in MVC- CodeS. 2024. YouTube video, added by CodeS. [Online]. Available at: https://www.youtube.com/watch?v=ZsTLTmnuvCA&t=606s  [Accessed 16 October 2024]
//4.	How to use IWebHostEnvironment in Class Library Project | ASP.NET CORE-ASP.NET MVC. 2024. YouTube video, added by ASP.NET MVC. [Online]. Available at: https://www.youtube.com/watch?v=sVyNC6oB6ig  [Accessed 16 October 2024]
//5.	How to access IWebHostEnvironment in ASP.NET 6.0, 7.0 OR Higer Version-ASP.NET MVC. 2024. YouTube video, added by ASP.NET MVC. [Online]. Available at: https://www.youtube.com/watch?v=sVyNC6oB6ig  [Accessed 16 October 2024]
//6.	MicrosoftLearn. 2024. Part 4, add a model to an ASP.NET Core MVC app, 26/07/2024. [Online]. Available at: https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/adding-model?view=aspnetcore-8.0&tabs=visual-studio  [Accessed 16 October 2024].
//7.	ViewModels in ASP.NET MVC applications - This is how it works-tutorialsEU - C#. 2024. YouTube video, added by tutorialsEU - C# . [Online]. Available at: https://www.youtube.com/watch?v=NfUccG5faBQ  [Accessed 16 October 2024]
//8.	MicrosoftLearn. 2024. HtmlForm.Enctype Property, 2024. [Online]. Available at: https://learn.microsoft.com/en-us/dotnet/api/system.web.ui.htmlcontrols.htmlform.enctype?view=netframework-4.8.1  [Accessed 17 October 2024].
//9.	MicrosoftLearn. 2024. Upload files in ASP.NET Core, 10/01/2024. [Online]. Available at: https://learn.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads?view=aspnetcore-8.0   [Accessed 17 October 2024].
//10.	TutorialsTeacher. 2024. Integrate Controller, View and Model, 2024. [Online]. Available at: https://www.tutorialsteacher.com/mvc/integrate-controller-view-model  [Accessed 17 October 2024]
//11.	C#Corner. 2024. GET and POST Calls to Controller's Method in MVC, 2 April 2024. [Online]. Available at: https://www.c-sharpcorner.com/UploadFile/abhikumarvatsa/jquery-ajax-get-and-post-calls-to-controllers-method-in-mvc/ [Accessed 17 October 2024]
//12.	26 - Consume GET Request In ASP.Net MVC | ASP.Net Web API- Just Pick and Learn. 2024. YouTube video, added by Code Semantic. [Online]. Available at: https://www.youtube.com/watch?v=34bJ547hBHQ  [Accessed 16 October 2024]
//13.	C#Corner. 2024. HTML5 anchor Tag, 28 October 2019. [Online]. Available at: https://www.c-sharpcorner.com/UploadFile/667ddf/html5-anchor-tag/  [Accessed 18 October 2024]
//14.	MicrosoftLearn. 2024. Creating an Action (C#), 11 July 2022. [Online]. Available at: https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/controllers-and-routing/creating-an-action-cs   [Accessed 18 October 2024]
// 


using Microsoft.EntityFrameworkCore;
using prog6212Part2.Models;

namespace prog6212Part2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args); // Initialize the web application builder

            // Add services to the container, enabling MVC (Model-View-Controller) architecture
            builder.Services.AddControllersWithViews();

            var app = builder.Build(); // Build the app using the configuration


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment()) // Check if the app is not in development mode
            {
                app.UseExceptionHandler("/Home/Error"); // Use error handling middleware for production
                // Use HTTP Strict Transport Security (HSTS) to enforce secure (HTTPS) connections for 30 days
                app.UseHsts();
            }

            app.UseHttpsRedirection(); // Redirect all HTTP requests to HTTPS
            app.UseStaticFiles(); // Enable serving static files (e.g., CSS, JavaScript)

            app.UseRouting(); // Enable routing to match incoming HTTP requests to endpoints

            app.UseAuthorization(); // Enable authorization for secured parts of the application

            // Define the default route pattern for controllers and actions
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"); // Default to the "Home" controller and "Index" action

            app.Run(); // Run the application
        }
    }
}
