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
        if (Data == null)
        {
            return BadRequest(new { message = "Invalid data" });
        }

        var model = JsonConvert.DeserializeObject<REF_SESSION_A_TBL>(Data);


        _db.REF_SESSION_A_TBL.Add(model);
        await _db.SaveChangesAsync();

        return Ok(new { message = "Data saved successfully!" });
    }
}
