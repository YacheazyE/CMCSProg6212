using Microsoft.AspNetCore.Mvc;
using prog6212Part2.Models;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using System.Security.Claims;

namespace prog6212Part2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }
        private static List<LecturerClaims> claimsDatabase = new List<LecturerClaims>();
        
        public IActionResult Index()
        {
            return View(claimsDatabase);
        } 
        
        public IActionResult ReviewedClaimsView()
        {
            return View(claimsDatabase);
        }

        [HttpPost]
        public IActionResult StoreDatabase(IFormFile ClaimFileName, string LecturerName, string AddNotes, int HoursWorked, int HourlyRate)
        {
            if (ClaimFileName != null && ClaimFileName.Length > 0)
            {
                var FileName = Path.GetFileName(ClaimFileName.FileName);
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "DatabaseFile", FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    ClaimFileName.CopyTo(stream);
                }
                claimsDatabase.Add(new LecturerClaims
                {
                    claimID = claimsDatabase.Count + 1,
                    claimFileName = FileName,
                    claimAdditionalNotes = AddNotes,
                    claimLecturerName = LecturerName,
                    claimHourlyRate = HourlyRate,
                    claimHoursWorked = HoursWorked,
                    claimDate = DateTime.Now,
                });

            }
            return RedirectToAction("LecturerView");
        }

        public ActionResult ReadFile(string newFileName)
        {
            var path = Path.Combine(_webHostEnvironment.WebRootPath, "DatabaseFile", newFileName);
            var fileBytes = System.IO.File.ReadAllBytes(path);
            return File(fileBytes, "application/octet-stream", newFileName);
        } 


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AdminView()
        {
            return View(claimsDatabase);
        }

        public IActionResult LecturerView()
        {

            return View(claimsDatabase);    
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult ReviewClaimsView(int claimId, bool approve)
        {
            var claim = claimsDatabase.FirstOrDefault(c => c.claimID == claimId);

            if (claim != null)
            {
                claim.claimStatus = approve;
            }

            return RedirectToAction("AdminView");
        }


    }
}
