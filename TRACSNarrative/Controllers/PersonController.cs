using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TRACSNarrative.Data;
using TRACSNarrative.Models;

namespace TRACSNarrative.Controllers
{
    [Authorize(Policy = "SuperUser")]
    public class PersonController : Controller
    {
        private readonly NarrativeContext _context;

        public PersonController(NarrativeContext context)
        {
            _context = context;
        }

        // GET: Person
        public async Task<IActionResult> Index(string PerNo, string PerLastName)
        {
            var perlist = await _context.Person.Where(r => r.PerNo == PerNo || r.PerLastName == PerLastName).OrderBy(r => r.PerLastName).ToListAsync();
            var foundperson = perlist.FirstOrDefault();
            if (foundperson == null)
            {
                TempData["NoResults"] = "No results found for search criteria.";
                return RedirectToAction(nameof(Search));
            }
            //return View(await _context.Person.Where(r => r.PerNo == PerNo || r.PerLastName == PerLastName).OrderBy(r => r.PerLastName).ToListAsync());
            return View(perlist);
        }

        // GET: Person/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person
                .FirstOrDefaultAsync(m => m.PerNo == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }
        [HttpPost]
        public async Task<IActionResult> Details(string PerNo, string PerLastName)
        {
            if (string.IsNullOrEmpty(PerNo) && string.IsNullOrEmpty(PerLastName))
            {
                return NotFound();
            }

            var person = await _context.Person
                .FirstOrDefaultAsync(m => m.PerNo == PerNo || m.PerLastName == PerLastName);
            if (person == null)
            {
                //return NotFound();
                TempData["NoResults"] = "No results found for search criteria.";
                return RedirectToAction(nameof(Search));
            }

            //_logger.LogInformation("User {User} DELETING TRACS Narrative: {Narrative}", @User.Identity.Name, narrative.NrtvSequenceNmbr);

            return View(person);
        }

        // GET: Person/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PerNo,PerLastName,PerFirstName,PerMi,PerSuffixName,PerGoesByName,PerBirthDate,CitznCode,RaceCode,PerSexCode,DcsdPerDeathDate,DcsdPerDeathFlag,SsnNmbr,PnaNmbr,PerMfInSync,JobsStatDescShort,PerComment,PerInsertDate,PerInsertBy,LastUpdateBrOffCode,LastUpdateDtTm,LastUpdateBy,PerEducCode,PerJasFlag,PerVeteranFlag,PerCommentDate,PerDisabilityCode,PerDisAccModCode,PerDisAccModText,PerEmailAddress,PerAbawdCode,PerAbawdLastUpdateDtTm,IeIndividualId")] Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        // GET: Person/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        // POST: Person/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PerNo,PerLastName,PerFirstName,PerMi,PerSuffixName,PerGoesByName,PerBirthDate,CitznCode,RaceCode,PerSexCode,DcsdPerDeathDate,DcsdPerDeathFlag,SsnNmbr,PnaNmbr,PerMfInSync,JobsStatDescShort,PerComment,PerInsertDate,PerInsertBy,LastUpdateBrOffCode,LastUpdateDtTm,LastUpdateBy,PerEducCode,PerJasFlag,PerVeteranFlag,PerCommentDate,PerDisabilityCode,PerDisAccModCode,PerDisAccModText,PerEmailAddress,PerAbawdCode,PerAbawdLastUpdateDtTm,IeIndividualId")] Person person)
        {
            if (id != person.PerNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.PerNo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        // GET: Person/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person
                .FirstOrDefaultAsync(m => m.PerNo == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var person = await _context.Person.FindAsync(id);
            _context.Person.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Person/Search
        //public async Task<IActionResult> Search()
        public IActionResult Search()
        {
            return View();
        }

        private bool PersonExists(string id)
        {
            return _context.Person.Any(e => e.PerNo == id);
        }
    }
}
