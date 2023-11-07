using Frontend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Frontend.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "http://localhost:7029/api";

        public EmployeesController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/employees");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var employees = JsonSerializer.Deserialize<List<Employee>>(content);
            return View(employees);
        }
 

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
