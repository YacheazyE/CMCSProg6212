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

using Microsoft.AspNetCore.Mvc;
using prog6212Part2.Models;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace prog6212Part2.Controllers
{
    public class HomeController : Controller
    {
        // Logger for the HomeController to log messages
        private readonly ILogger<HomeController> _logger;

        // Web hosting environment for accessing web root path
        private readonly IWebHostEnvironment _webHostEnvironment;

        // Constructor to initialize logger and web hosting environment
        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger; // Assign logger to the private field
            _webHostEnvironment = webHostEnvironment; // Assign web host environment to the private field
        }

        // In-memory database to store claims
        private static List<LecturerClaims> claimsDatabase = new List<LecturerClaims>();


        // Action method to display the main index view with the claims database
        public IActionResult Index()
        {
            return View(claimsDatabase); // Pass the claims database to the view
        }

 
        // Action method to display reviewed claims
        public IActionResult ReviewedClaimsView()
        {
            return View(claimsDatabase); // Pass the claims database to the view
        }

        // Action method to handle form submissions for storing claims 
        [HttpPost]
        public IActionResult StoreDatabase(IFormFile ClaimFileName, string LecturerName, string AddNotes, int HoursWorked, int HourlyRate)
        {
            // Check if the uploaded file is not null and has content
            if (ClaimFileName != null && ClaimFileName.Length > 0)
            {
                // Get the file name and create a path to save it
                var FileName = Path.GetFileName(ClaimFileName.FileName);
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "DatabaseFile", FileName);

                // Save the uploaded file to the server
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    ClaimFileName.CopyTo(stream); // Copy the file stream to the new file
                }

                // Create a new claim and add it to the claims database
                claimsDatabase.Add(new LecturerClaims
                {
                    claimID = claimsDatabase.Count + 1, // Auto-increment claim ID
                    claimFileName = FileName, // Store the uploaded file name
                    claimAdditionalNotes = AddNotes, // Store additional notes
                    claimLecturerName = LecturerName, // Store the lecturer's name
                    claimHourlyRate = HourlyRate, // Store the hourly rate
                    claimHoursWorked = HoursWorked, // Store hours worked
                    claimDate = DateTime.Now, // Store the current date as the claim date
                    claimStatus = false
                });
            }
            // Redirect to the LecturerView action
            return RedirectToAction("LecturerView");
        }

        // Action method to read a file from the server
        public ActionResult ReadFile(string newFileName)
        {
            var path = Path.Combine(_webHostEnvironment.WebRootPath, "DatabaseFile", newFileName); // Create the file path
            var fileBytes = System.IO.File.ReadAllBytes(path); // Read all bytes from the file
            return File(fileBytes, "application/octet-stream", newFileName); // Return the file for download
        }


        // Action method to display the Admin view with claims
        public IActionResult AdminView()
        {
            return View(claimsDatabase); // Pass the claims database to the view
        }

        public IActionResult Login()
        {
            return View();
        }

        // Action method to display the Lecturer view with claims
        public IActionResult LecturerView()
        {
            return View(claimsDatabase); // Pass the claims database to the view
        }

        // Action method to handle error responses
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }); // Pass the error model to the view
        }

        // Action method to review claims and update their status
        [HttpPost]

        public IActionResult ReviewClaimsView(int claimId, bool approve)
        {
            var claim = claimsDatabase.FirstOrDefault(c => c.claimID == claimId);

            if (claim != null)
            {
                claim.claimStatus = approve; // Update claim status to approved or rejected
            }

            return RedirectToAction("AdminView");
        }
    }
}

