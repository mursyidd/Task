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
        return View();
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

        SESSION_A_APPL_DTL_TBL model;
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

        SESSION_B_EMPL_DTL_TBL model;
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

        SESSION_C_QUAL_DTL_TBL model;
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

        SESSION_D_PAST_EMPL_DTL_TBL model;
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
}
