using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pet_project_Vitasmart.Adapter;
using Pet_project_Vitasmart.Models;
using Pet_project_Vitasmart.Models.InputModels;

namespace Pet_project_Vitasmart.Controllers
{
    public class VisitController : Controller
    {
        private readonly PetProjectDbContext _dbContext;
        public VisitController(PetProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("Visit/{id}")]
        public IActionResult Index(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpGet("GetAllVisits")]
        public async Task<IActionResult> GetAllVisits()
        {
            var visits = await _dbContext.Visits.Include(p => p.PatientVisit).Include(i => i.Diagnosis).ToListAsync();
            return Json(visits);
        }
        [HttpGet("GetVisitsByPatientId/{patientId}")]
        public async Task<IActionResult> GetVisitsByPatientId(int patientId)
        {
            List<Visit> visits = await GetVisitsByPatientIdDb(patientId);
            if (visits == null) return BadRequest("Пациент не найден");
            return Json(visits);
        }

        [HttpPost("CreateVisits")]
        public async Task<IActionResult> CreateVisits(VisitDataInput newVisitData)
        {
            var patient = await _dbContext.Patients.SingleOrDefaultAsync(p => p.Id == newVisitData.PatientId);
            if (patient == null) return BadRequest("Пациент не найден");
            var icd = await _dbContext.ICDs.SingleOrDefaultAsync(p => p.Code == newVisitData.ICDCode);
            if (icd == null) return BadRequest("МКБ-10 не найдена");

            Visit newVisit = new(newVisitData.DateVisit, newVisitData.ICDCode, icd, newVisitData.PatientId, patient);
            try
            {
                _dbContext.Visits.Add(newVisit);
                await SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest($"ошибка при записи в базу данных: {ex.Message}");
            }
            return Json(newVisit);
        }
        // вспомогательные методы
        private async Task<List<Visit>> GetVisitsByPatientIdDb(int patientId)
        {
            var patient = await _dbContext.Patients.SingleOrDefaultAsync(p => p.Id == patientId);
            if (patient == null) return null;
            return await _dbContext.Visits.Where(p => p.PatientId == patient.Id).Include(p => p.PatientVisit).Include(i => i.Diagnosis).ToListAsync();
        }
        private async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
