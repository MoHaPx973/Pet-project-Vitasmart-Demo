using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pet_project_Vitasmart.Adapter;
using Pet_project_Vitasmart.Models;

namespace Pet_project_Vitasmart.Controllers
{
    public class ICDController : Controller
    {
        private readonly PetProjectDbContext _dbContext;

        public ICDController(PetProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetAllICDs")]
        public async Task<IActionResult> GetAllICDs()
        {
            var icd = await _dbContext.ICDs.ToListAsync();
            return Json(icd);
        }

        [HttpPost("CreateICD")]
        public async Task<IActionResult> CreateICD(ICD newIcd)
        {
            ICD icd = newIcd;
            try
            {
                _dbContext.Add(icd);
                await SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest($"ошибка при записи в базу данных: {ex.Message}");
            }
            return Json(icd);
        }
        [HttpGet("GetICDsByName/{name}")]
        public async Task<IActionResult> GetICDsByName(string name)
        {
            List<ICD> icd = new();
            IEnumerable<ICD> findICDs = await _dbContext.ICDs.ToListAsync();
            icd.AddRange(findICDs.Where(s => s.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0).ToList());
            return Json(icd);
        }

        // Вспомогательные методы
        private async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
