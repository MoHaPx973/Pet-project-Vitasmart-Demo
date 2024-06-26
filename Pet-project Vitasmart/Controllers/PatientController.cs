using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pet_project_Vitasmart.Adapter;
using Pet_project_Vitasmart.Models;
using Pet_project_Vitasmart.Models.InputModels;

namespace Pet_project_Vitasmart.Controllers
{
    public class PatientController : Controller
    {
        private readonly PetProjectDbContext _dbContext;

        public PatientController(PetProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("GetAllPatient")]
        public async Task<IActionResult> GetAllPatient()
        {
            var patient = await _dbContext.Patients.ToListAsync();
            return Json(patient);
        }

        [HttpPost("CreatePatient")]
        public async Task<IActionResult> CreatePatient(InputPatient newPatient)
        {
            try
            {
                //Patient patient = new Patient("ф2", "и2", "о2", new DateOnly(2002, 01, 22), "11111");
                Patient patient = new(newPatient.Surname, newPatient.Name, newPatient.Patronymic, newPatient.Birthdate, newPatient.PhoneNumber);
                try
                {
                    _dbContext.Add(patient);
                    await SaveChanges();
                }
                catch (Exception ex)
                {
                    return BadRequest($"ошибка при записи в базу данных: {ex.Message}");
                }
                return Json(newPatient);
            }
            catch(Exception ex)
            {
                return BadRequest(new { errorMessage = ex.Message });
            }
        }

        [HttpGet("GetPatientsByName/{name}")]
        public async Task<IActionResult> GetPatientsByName(string name)
        {
            List<Patient> patients = new();
            List<Patient> findPatients = new();
            findPatients = await _dbContext.Patients.ToListAsync();

            string[] properties = { "Surname", "Name", "Patronymic" };

            foreach (string prop in properties)
            {
                var filteredPatients = findPatients.Where(p => p.GetType().GetProperty(prop).GetValue(p)?.ToString().IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                patients.AddRange(filteredPatients);

                findPatients = findPatients.Except(filteredPatients).ToList();
            }
            return Json(patients);
        }

        // Вспомогательные методы
        private async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
