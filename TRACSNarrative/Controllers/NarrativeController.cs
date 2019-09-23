using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TRACSNarrative.Models;
using TRACSNarrative.Data;
using Microsoft.Extensions.Logging;

namespace TRACSNarrative.Controllers
{ 
    [Authorize(Policy = "SuperUser")]
    public class NarrativeController : Controller
    {
        private readonly NarrativeContext _context;
        private readonly ILogger _logger;

        public NarrativeController(NarrativeContext context, ILogger<NarrativeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Narrative
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Narrative.ToListAsync());
        //}

        // GET: Narrative/List/5
        public async Task<IActionResult> List(string id)
        {
            
            TempData["PerNo"] = _context.Person.Where(n => n.PerNo == id).FirstOrDefault().PerNo;
            TempData["PerLastName"] = _context.Person.Where(n => n.PerNo == id).FirstOrDefault().PerLastName;
            TempData["PerFirstName"] = _context.Person.Where(n => n.PerNo == id).FirstOrDefault().PerFirstName;
             return View(await _context.Narrative.Where(r => r.PerNo == id).OrderByDescending(r => r.NrtvEntryDate).ToListAsync());
        }

        // GET: Narrative/Details/5/1
        [HttpGet("Narrative/Details/{id1}/{id2}"), ActionName("Details")]
        public async Task<IActionResult> Detail(string id1, int id2)
        {
            if (string.IsNullOrEmpty(id1) || id2 <= 0)
            {
                return NotFound();
            }

            var narrative = await _context.Narrative
                .Include(n => n.NarrativeText)
                .Include(n => n.Person)
                .FirstOrDefaultAsync(m => m.BrOffCode == id1 && m.NrtvSequenceNmbr == id2);
            if (narrative == null)
            {
                //return NotFound();
                TempData["NoResults"] = "No results found for search criteria.";
                return RedirectToAction(nameof(Search));
            }

            return View(narrative);
        }

        [HttpPost]
        public async Task<IActionResult> Details(string BrOffCode, int NrtvSequenceNmbr)
        {
            if (string.IsNullOrEmpty(BrOffCode)  || NrtvSequenceNmbr <= 0)
            {
                return NotFound();
            }
            
            var narrative = await _context.Narrative
                .Include(n => n.NarrativeText)     
                .Include(n => n.Person)
                .FirstOrDefaultAsync(m => m.BrOffCode == BrOffCode && m.NrtvSequenceNmbr == NrtvSequenceNmbr);
            if (narrative == null)
            {
                //return NotFound();
                TempData["NoResults"] = "No results found for search criteria.";
                return RedirectToAction(nameof(Search));
            }

            //_logger.LogInformation("User {User} DELETING TRACS Narrative: {Narrative}", @User.Identity.Name, narrative.NrtvSequenceNmbr);

            return View(narrative);
        }

        // GET: Narrative/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: Narrative/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("PerNo,BrOffCode,NrtvSequenceNmbr,ContTypeCode,NrtvTypeCode,TracsAuthRacfId,NrtvEntryDate,NrtvTimeSpentHours,NrtvTimeSpentMinutes,NrtvStickyNote,TklrAttentionDate,NrtvEnteredOn,LastUpdateBrOffCode,LastUpdateDtTm,LastUpdateBy,NrtvPendedFlag,NrtvStatusCode,NrtvScrnsChkdFlag")] Narrative narrative)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(narrative);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(narrative);
        //}

        //// GET: Narrative/Edit/5
        //public async Task<IActionResult> Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var narrative = await _context.Narrative.FindAsync(id);
        //    if (narrative == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(narrative);
        //}

        // GET: Narrative/Search
        //public async Task<IActionResult> Search()
        public IActionResult Search()
        {   
            return View();
        }

        // POST: Narrative/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(string id, [Bind("PerNo,BrOffCode,NrtvSequenceNmbr,ContTypeCode,NrtvTypeCode,TracsAuthRacfId,NrtvEntryDate,NrtvTimeSpentHours,NrtvTimeSpentMinutes,NrtvStickyNote,TklrAttentionDate,NrtvEnteredOn,LastUpdateBrOffCode,LastUpdateDtTm,LastUpdateBy,NrtvPendedFlag,NrtvStatusCode,NrtvScrnsChkdFlag")] Narrative narrative)
        //{
        //    if (id != narrative.BrOffCode)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(narrative);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!NarrativeExists(narrative.BrOffCode))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(narrative);
        //}

        // GET: Narrative/Delete/5
        [HttpGet("Delete/{id1}/{id2}")]
        public async Task<IActionResult> Delete(string id1, int id2)
        {
            if (id1 == null || id2 <= 0)
            {
                return NotFound();
            }

            var narrative = await _context.Narrative
                .Include(n => n.NarrativeText)
                .Include(n => n.Person)
                .FirstOrDefaultAsync(m => m.BrOffCode == id1 && m.NrtvSequenceNmbr == id2);
            if (narrative == null)
            {
                return NotFound();
            }

            return View(narrative);
        }

        // POST: Narrative/Delete/5
        [HttpPost("Delete/{id1}/{id2}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id1, int id2)
        {
            var narrative = await _context.Narrative.FindAsync(id1, id2);
            _context.Narrative.Remove(narrative);
            await _context.SaveChangesAsync();
            TempData["DeleteSuccess"] = "Narrative " + id1 + "/" + id2.ToString() + " has been deleted.";
           // _logger.LogInformation("User {User} DELETING TRACS Narrative: {Narrative}, Branch {Branch}", @User.Identity.Name, narrative.NrtvSequenceNmbr, narrative.BrOffCode);
            return RedirectToAction(nameof(Search));
        }

        private bool NarrativeExists(string id)
        {
            return _context.Narrative.Any(e => e.BrOffCode == id);
        }
        
    }
}
