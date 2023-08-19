using Microsoft.AspNetCore.Mvc;
using ReadFromExcelDemo.Models;
using ReadFromExcelDemo.Utilities;
using System.Diagnostics;
using System.Globalization;

namespace ReadFromExcelDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            string excelFileName = "employees.xlsx";
            string excelFilePath = Path.Combine(_webHostEnvironment.WebRootPath, excelFileName);

            var excelReader = new ExcelReader<Employee>(excelFilePath);

            var employees = excelReader.ReadData((worksheet, row) =>
            {
                return new Employee
                {
                    Id = Convert.ToInt32(worksheet.Cells[row, 1].Value),
                    Name = worksheet.Cells[row, 2].Value.ToString() ?? string.Empty,
                    StartDate = DateTime.ParseExact(worksheet.Cells[row, 3].Text, "M/d/yyyy", CultureInfo.InvariantCulture),
                    Email = worksheet.Cells[row, 4].Value.ToString() ?? string.Empty,
                    Salary = Convert.ToDecimal(worksheet.Cells[row, 5].Value),
                    Manager = worksheet.Cells[row, 6].Value.ToString() ?? string.Empty,
                    Department = worksheet.Cells[row, 7].Value.ToString() ?? string.Empty
                };
            });
            return View(employees);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}