using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _14112018.Models;
using _14112018.Contexts;
using System.Linq.Dynamic.Core;
using _14112018.Domains;
using Microsoft.EntityFrameworkCore;

namespace _14112018.Controllers
{
    public class HomeController : Controller
    {
        private readonly _14112018DbContext _db;

        public HomeController(_14112018DbContext _db)
        {
            this._db = _db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> LoadData()
        {
            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
                // Skiping number of Rows count
                var start = Request.Form["start"].FirstOrDefault();
                // Paging Length 10,20
                var length = Request.Form["length"].FirstOrDefault();
                // Sort Column Name
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                // Sort Column Direction ( asc ,desc)
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                // Search Value from (Search box)
                var searchValue = Request.Form["search[value]"].FirstOrDefault();

                //Paging Size (10,20,50,100)
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                // Getting all  data
                var topics = _db.Topics.Select(n => new Topic
                {
                    Id = n.Id,
                    Title = n.Title,
                    Content = n.Content
                });

                //Sorting
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    topics = topics.OrderBy(sortColumn + " " + sortColumnDirection);
                }
                //Search
                if (!string.IsNullOrEmpty(searchValue))
                {
                    topics = topics.Where(m => m.Title == searchValue || m.Content == searchValue);
                }

                //total number of rows count 
                recordsTotal = topics.Count();
                //Paging 
                var data = topics.Skip(skip).Take(pageSize).ToList();
              
                return await Task.Run(() =>
                Json(new
                {
                    draw = draw,
                    recordsFiltered = recordsTotal,
                    recordsTotal = recordsTotal,
                    data = data
                }));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id==0)
                {
                    return RedirectToAction(nameof(Index));
                }

                var result = _db.Topics.SingleOrDefaultAsync(n => n.Id == id);

                if (result.Result != null)
                {
                    _db.Topics.Remove(result.Result);
                     await _db.SaveChangesAsync();
                    return Json(data: true);
                }
                else
                {
                    return Json(data: false);
                }
               
            }
            catch (Exception ex)
            {
                return Json(new { data = false, message = ex.Message });
            }
        }
      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
