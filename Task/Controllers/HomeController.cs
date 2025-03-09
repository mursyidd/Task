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
        List<MST_APPLICATION_TBL> Applications = new List<MST_APPLICATION_TBL>();

        Applications = await _db.MST_APPLICATION_TBL.Where(x => x.ActiveStatus == "Y").ToListAsync();

        return View(Applications);
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

            var existingRecord = await _db.SESSION_A_APPL_DTL_TBL
                                  .FirstOrDefaultAsync(a => a.MST_REF_ID == model.MST_REF_ID);

            if (existingRecord != null)
            {
                // Update existing record
                existingRecord.APPL_NAME = model.APPL_NAME;
                existingRecord.APPL_EMAIL = model.APPL_EMAIL;
                existingRecord.APPL_PHONE = model.APPL_PHONE;

                _db.Update(existingRecord);
                await _db.SaveChangesAsync();
                return Ok(new { message = "Data updated successfully!" });
            }
            else
            {
                // Insert new record
                _db.SESSION_A_APPL_DTL_TBL.Add(model);
                await _db.SaveChangesAsync();
                return Ok(new { message = "Data saved successfully!" });
            }
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

            var existingRecord = await _db.SESSION_B_EMPL_DTL_TBL
                                  .FirstOrDefaultAsync(a => a.MST_REF_ID == model.MST_REF_ID);

            if (existingRecord != null)
            {
                // Update existing record
                existingRecord.EMPL_TITLE = model.EMPL_TITLE;
                existingRecord.EMPL_EXP = model.EMPL_EXP;
                existingRecord.EMPL_COMP_NAME = model.EMPL_COMP_NAME;

                _db.Update(existingRecord);
                await _db.SaveChangesAsync();
                return Ok(new { message = "Data updated successfully!" });
            }
            else
            {
                // Insert new record
                _db.SESSION_B_EMPL_DTL_TBL.Add(model);
                await _db.SaveChangesAsync();
                return Ok(new { message = "Data saved successfully!" });
            }
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

            var existingRecord = await _db.SESSION_C_QUAL_DTL_TBL
                                  .FirstOrDefaultAsync(a => a.MST_REF_ID == model.MST_REF_ID);

            if (existingRecord != null)
            {
                // Update existing record
                existingRecord.QUAL = model.QUAL;
                existingRecord.CERT = model.CERT;
                existingRecord.SKILL = model.SKILL;

                _db.Update(existingRecord);
                await _db.SaveChangesAsync();
                return Ok(new { message = "Data updated successfully!" });
            }
            else
            {
                // Insert new record
                _db.SESSION_C_QUAL_DTL_TBL.Add(model);
                await _db.SaveChangesAsync();
                return Ok(new { message = "Data saved successfully!" });
            }
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

            var existingRecord = await _db.SESSION_D_PAST_EMPL_DTL_TBL
                                  .FirstOrDefaultAsync(a => a.MST_REF_ID == model.MST_REF_ID);

            if (existingRecord != null)
            {
                existingRecord.PAST_COMP_NAME = model.PAST_COMP_NAME;
                existingRecord.PAST_JOB_TITLE = model.PAST_JOB_TITLE;
                existingRecord.PAST_EXP = model.PAST_EXP;

                _db.Update(existingRecord);
                await _db.SaveChangesAsync();
                return Ok(new { message = "Data updated successfully!" });
            }
            else
            {
                _db.SESSION_D_PAST_EMPL_DTL_TBL.Add(model);
                await _db.SaveChangesAsync();
                return Ok(new { message = "Data saved successfully!" });
            }
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

            var existingRecord = await _db.SESSION_E_DOC_DTL_TBL
                                  .FirstOrDefaultAsync(a => a.MST_REF_ID == model.MST_REF_ID);

            if (existingRecord != null)
            {
                existingRecord.DOC_RESUME = model.DOC_RESUME;
                existingRecord.DOC_COVER = model.DOC_COVER;
                existingRecord.AGREEMENT = model.AGREEMENT;

                _db.Update(existingRecord);
                await _db.SaveChangesAsync();
                return Ok(new { message = "Data updated successfully!" });
            }
            else
            {
                _db.SESSION_E_DOC_DTL_TBL.Add(model);
                await _db.SaveChangesAsync();
                return Ok(new { message = "Data saved successfully!" });
            }
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

    public async Task<object?> getDataSession(string MST_REF_ID, int SESSION_ID)
    {
        if (SESSION_ID == 2)
        {
            return await _db.SESSION_A_APPL_DTL_TBL
                        .FirstOrDefaultAsync(a => a.MST_REF_ID == MST_REF_ID);
        } else if (SESSION_ID == 3)
        {
            return await _db.SESSION_B_EMPL_DTL_TBL
                        .FirstOrDefaultAsync(a => a.MST_REF_ID == MST_REF_ID);
        } else if (SESSION_ID == 4)
        {
            return await _db.SESSION_C_QUAL_DTL_TBL
                        .FirstOrDefaultAsync(a => a.MST_REF_ID == MST_REF_ID);
        }
        else if (SESSION_ID == 5)
        {
            return await _db.SESSION_D_PAST_EMPL_DTL_TBL
                        .FirstOrDefaultAsync(a => a.MST_REF_ID == MST_REF_ID);
        }
        else if (SESSION_ID == 6)
        {
            return await _db.SESSION_E_DOC_DTL_TBL
                        .FirstOrDefaultAsync(a => a.MST_REF_ID == MST_REF_ID);
        }

        return null;
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

    [HttpPost]
    public async Task<string> saveToMaster(string ID, int stageID, int sessionID)
    {
        var existingRecord = await _db.MST_APPLICATION_TBL
                                          .FirstOrDefaultAsync(a => a.ApplicationID == ID);
        var name = await _db.SESSION_A_APPL_DTL_TBL
                .Where(a => a.MST_REF_ID == ID)
                .Select(a => a.APPL_NAME)
                .FirstOrDefaultAsync() ?? "System";

        if (existingRecord != null)
        {
            existingRecord.StageID = stageID;
            existingRecord.SessionID = sessionID;
            existingRecord.UpdatedDate = DateTime.UtcNow;
            existingRecord.UpdatedBy = name;
            existingRecord.ActiveStatus = "Y";


            _db.MST_APPLICATION_TBL.Update(existingRecord);
            await _db.SaveChangesAsync();
        }
        else
        {
            // Create new record
            var newRecord = new MST_APPLICATION_TBL
            {
                ApplicationID = ID,
                StageID = stageID,
                SessionID = sessionID,
                CreatedDate = DateTime.UtcNow,
                CreatedBy = name,
                UpdatedDate = DateTime.UtcNow,
                UpdatedBy = name,
                ActiveStatus = "Y",
            };

            await _db.MST_APPLICATION_TBL.AddAsync(newRecord);
            await _db.SaveChangesAsync();
        }

        return ID;
    }

    [HttpPost]
    public async Task<IActionResult> DeleteApplication(int id)
    {
        var MST_APPLICATION_TBL = await _db.MST_APPLICATION_TBL.FindAsync(id);
        if (MST_APPLICATION_TBL != null)
        {
            MST_APPLICATION_TBL.ActiveStatus = "N";
            _db.Update(MST_APPLICATION_TBL);
            await _db.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Welcome));
    }
}
