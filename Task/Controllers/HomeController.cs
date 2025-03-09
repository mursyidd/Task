using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Task.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Newtonsoft.Json;

namespace Task.Controllers;

// [Route("[controller]/[action]")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _db;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
    {
        _logger = logger;
        _db = db;
    }

    public async Task<IActionResult> Welcome()
    {
        ReviewModel review = new ReviewModel();

        return View(review);
    }

    // GET: People
    public async Task<IActionResult> Index()
    {
        var people = await _db.People.Where(p => !p.IsDeleted).ToListAsync();
        return View(people);
    }

    // GET: People/Details/5
    public async Task<IActionResult> View(int id)
    {
        var person = await _db.People.FindAsync(id);
        if (person == null || person.IsDeleted)
        {
            return NotFound();
        }
        return View(person);
    }

    // GET: People/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: People/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Person person)
    {
        if (ModelState.IsValid)
        {
            _db.People.Add(person);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(person);
    }

    // GET: People/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var person = await _db.People.FindAsync(id);
        if (person == null || person.IsDeleted)
        {
            return NotFound();
        }
        return View(person);
    }

    // POST: People/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Person person)
    {
        if (id != person.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _db.Update(person);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(person);
    }

    // POST: People/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var person = await _db.People.FindAsync(id);
        if (person != null)
        {
            person.IsDeleted = true;
            _db.Update(person);
            await _db.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }

    public IActionResult CreateSecA()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateSecA(string Data)
    {
        if (string.IsNullOrWhiteSpace(Data))
        {
            return BadRequest(new { message = "Invalid data" });
        }

        SESSION_A_APPL_DTL_TBL model = new SESSION_A_APPL_DTL_TBL();
        try
        {
            model = JsonConvert.DeserializeObject<SESSION_A_APPL_DTL_TBL>(Data);
        }
        catch (JsonException)
        {
            return BadRequest(new { message = "Invalid JSON format" });
        }

        try
        {
            if (string.IsNullOrEmpty(model.APPL_NAME) || string.IsNullOrEmpty(model.APPL_EMAIL) || string.IsNullOrEmpty(model.APPL_PHONE))
            {
                return BadRequest(new { message = "Please check your form!" });
            }

            _db.SESSION_A_APPL_DTL_TBL.Add(model);
            await _db.SaveChangesAsync();
            return Ok(new { message = "Data saved successfully!" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Internal server error", error = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateSecB(string Data)
    {
        if (string.IsNullOrWhiteSpace(Data))
        {
            return BadRequest(new { message = "Invalid data" });
        }

        SESSION_B_EMPL_DTL_TBL model = new SESSION_B_EMPL_DTL_TBL();
        try
        {
            model = JsonConvert.DeserializeObject<SESSION_B_EMPL_DTL_TBL>(Data);
        }
        catch (JsonException)
        {
            return BadRequest(new { message = "Invalid JSON format" });
        }

        try
        {
            if (string.IsNullOrEmpty(model.EMPL_TITLE) || string.IsNullOrEmpty(model.EMPL_EXP) || string.IsNullOrEmpty(model.EMPL_COMP_NAME))
            {
                return BadRequest(new { message = "Please check your form!" });
            }

            _db.SESSION_B_EMPL_DTL_TBL.Add(model);
            await _db.SaveChangesAsync();
            return Ok(new { message = "Data saved successfully!" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Internal server error", error = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateSecC(string Data)
    {
        if (string.IsNullOrWhiteSpace(Data))
        {
            return BadRequest(new { message = "Invalid data" });
        }

        SESSION_C_QUAL_DTL_TBL model = new SESSION_C_QUAL_DTL_TBL();
        try
        {
            model = JsonConvert.DeserializeObject<SESSION_C_QUAL_DTL_TBL>(Data);
        }
        catch (JsonException)
        {
            return BadRequest(new { message = "Invalid JSON format" });
        }

        try
        {
            if (string.IsNullOrEmpty(model.QUAL) || string.IsNullOrEmpty(model.CERT) || string.IsNullOrEmpty(model.SKILL))
            {
                return BadRequest(new { message = "Please check your form!" });
            }

            _db.SESSION_C_QUAL_DTL_TBL.Add(model);
            await _db.SaveChangesAsync();
            return Ok(new { message = "Data saved successfully!" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Internal server error", error = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateSecD(string Data)
    {
        if (string.IsNullOrWhiteSpace(Data))
        {
            return BadRequest(new { message = "Invalid data" });
        }

        SESSION_D_PAST_EMPL_DTL_TBL model = new SESSION_D_PAST_EMPL_DTL_TBL();
        try
        {
            model = JsonConvert.DeserializeObject<SESSION_D_PAST_EMPL_DTL_TBL>(Data);
        }
        catch (JsonException)
        {
            return BadRequest(new { message = "Invalid JSON format" });
        }

        try
        {
            if (string.IsNullOrEmpty(model.PAST_COMP_NAME) || string.IsNullOrEmpty(model.PAST_JOB_TITLE) || string.IsNullOrEmpty(model.PAST_EXP))
            {
                return BadRequest(new { message = "Please check your form!" });
            }

            _db.SESSION_D_PAST_EMPL_DTL_TBL.Add(model);
            await _db.SaveChangesAsync();
            return Ok(new { message = "Data saved successfully!" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Internal server error", error = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> UploadFile(IFormFile RESUME, IFormFile COVER_LETTER)
    {
        if (RESUME == null || COVER_LETTER == null)
        {
            return BadRequest(new { message = "No file uploaded" });
        }

        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
        if (!Directory.Exists(uploadsFolder))
        {
            Directory.CreateDirectory(uploadsFolder);
        }

        var filePath1 = Path.Combine(uploadsFolder, RESUME.FileName);
        using (var stream = new FileStream(filePath1, FileMode.Create))
        {
            await RESUME.CopyToAsync(stream);
        }

        var filePath2 = Path.Combine(uploadsFolder, COVER_LETTER.FileName);
        using (var stream = new FileStream(filePath2, FileMode.Create))
        {
            await COVER_LETTER.CopyToAsync(stream);
        }

        return Ok(new { message = "Files uploaded successfully!", ResumeFileName = RESUME.FileName, CoverFileName = COVER_LETTER.FileName });
    }

    [HttpPost]
    public async Task<IActionResult> CreateSecE(string Data)
    {
        if (string.IsNullOrWhiteSpace(Data))
        {
            return BadRequest(new { message = "Invalid data" });
        }

        SESSION_E_DOC_DTL_TBL model;
        try
        {
            model = JsonConvert.DeserializeObject<SESSION_E_DOC_DTL_TBL>(Data);
        }
        catch (JsonException)
        {
            return BadRequest(new { message = "Invalid JSON format" });
        }

        try
        {
            if (string.IsNullOrEmpty(model.DOC_RESUME) || string.IsNullOrEmpty(model.DOC_COVER) || !model.AGREEMENT)
            {
                return BadRequest(new { message = "Please check your form!" });
            }

            _db.SESSION_E_DOC_DTL_TBL.Add(model);
            await _db.SaveChangesAsync();
            return Ok(new { message = "Data saved successfully!" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Internal server error", error = ex.Message });
        }
    }

    public async Task<ReviewModel> getAllInfo(string MST_REF_ID)
    {
        ReviewModel review = new ReviewModel();

        review.SESSION_A = await _db.SESSION_A_APPL_DTL_TBL.Where(x => x.MST_REF_ID == MST_REF_ID).FirstOrDefaultAsync();
        review.SESSION_B = await _db.SESSION_B_EMPL_DTL_TBL.Where(x => x.MST_REF_ID == MST_REF_ID).FirstOrDefaultAsync();
        review.SESSION_C = await _db.SESSION_C_QUAL_DTL_TBL.Where(x => x.MST_REF_ID == MST_REF_ID).FirstOrDefaultAsync();
        review.SESSION_D = await _db.SESSION_D_PAST_EMPL_DTL_TBL.Where(x => x.MST_REF_ID == MST_REF_ID).FirstOrDefaultAsync();
        review.SESSION_E = await _db.SESSION_E_DOC_DTL_TBL.Where(x => x.MST_REF_ID == MST_REF_ID).FirstOrDefaultAsync();

        return review;
    }

    [HttpPost]
    public async Task<IActionResult> Download(string filename)
    {
        var filePath = Path.Combine("wwwroot/uploads/", filename);
        if (!System.IO.File.Exists(filePath))
        {
            return NotFound(new { message = "File not found" });
        }

        var content = await System.IO.File.ReadAllBytesAsync(filePath);
        return File(content, "application/pdf", filename);
    }

    public async Task<string> getLatestMST_REF_ID()
    {
        string latestMstRefId = await _db.SESSION_A_APPL_DTL_TBL
            .FromSqlRaw("SELECT TOP 1 MST_REF_ID FROM SESSION_A_APPL_DTL_TBL ORDER BY MST_REF_ID DESC")
            .Select(x => x.MST_REF_ID)
            .FirstOrDefaultAsync() ?? "0";

        long refIdNum = long.Parse(latestMstRefId);
        refIdNum = refIdNum + 1;

        return refIdNum.ToString();
    }
}
