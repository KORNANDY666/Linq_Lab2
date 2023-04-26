using Linq_Lab2.Data;
using Linq_Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Linq_Lab2.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext context;
        public SearchController(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<IActionResult> Index()
        {
            List<SearchViewModel> list = new List<SearchViewModel>();
                        var items = await (from t in context.Teacher
                           join sc in context.SchoolConnection on t.TeacherId equals sc.FK_TeacherId
                           join c in context.Course on sc.FK_CourseId equals c.CourseId
                           where c.Subjects == "Programming 1"
                           group t by t.TeacherId into g
                           select new
                              {
                               TeacherId = g.Key,
                               FirstName = g.First().FirstName,
                               LastName = g.First().LastName,
                                                           

                               }).ToListAsync();
            
            foreach (var item in items)
            {
                SearchViewModel listItem = new SearchViewModel();
                listItem.TFirstName = item.FirstName;
                listItem.TLastName = item.LastName;
                list.Add(listItem);
            }

            return View(list);

        }

        public async Task<IActionResult> SearchStud()
        {
            List<SearchViewModel> list = new List<SearchViewModel>();
            var student = await (from sc in context.SchoolConnection
                                 join t in context.Teacher on sc.FK_TeacherId equals t.TeacherId into tempTe
                                 from te in tempTe.DefaultIfEmpty()
                                 join s in context.Student on sc.FK_StudentId equals s.StudentId into tempSt
                                 from st in tempSt.DefaultIfEmpty()
                                 join c in context.Course on sc.FK_CourseId equals c.CourseId into tempC
                                 from co in tempC.DefaultIfEmpty()
                                 join cl in context.SchoolClass on sc.FK_SchoolClassId equals cl.SchoolClassId into tempCl
                                 from scl in tempCl.DefaultIfEmpty()
                                 select new SearchViewModel
                                 {
                                     SFirstName = st.FirstName,
                                     SLastName = st.LastName,
                                     TFirstName =  te.FirstName,
                                     TLastName = te.LastName,
                                     Course = co.Subjects
                                 }).ToListAsync();
            foreach (var item in student)
            {
                SearchViewModel listItem = new SearchViewModel();
                listItem.SFirstName = item.SFirstName;
                listItem.SLastName = item.SLastName;
                listItem.TFirstName = item.TFirstName;
                listItem.TLastName = item.TLastName;
                listItem.Course = item.Course;

                list.Add(listItem);
            }

            return View(list);

        }


        public async Task<IActionResult> Programming()
        {
              List<SearchViewModel> list = new List<SearchViewModel>();
            var items = await (from te in context.Teacher
                               join sc in context.SchoolConnection on te.TeacherId equals sc.FK_TeacherId
                               join c in context.Course on sc.FK_CourseId equals c.CourseId
                               join s in context.Student on sc.FK_StudentId equals s.StudentId
                               where c.Subjects == "Programming 1"
                               select new SearchViewModel
                               {
                                   TFirstName = te.FirstName,
                                   TLastName = te.LastName,
                                   SFirstName = s.FirstName,
                                   SLastName = s.LastName,
                                   Course = c.Subjects,

                               }).ToListAsync();
           
            foreach (var item in items)
            {
                SearchViewModel listItem = new SearchViewModel();
                listItem.TFirstName = item.TFirstName;
                listItem.TLastName = item.TLastName;
                listItem.SFirstName = item.SFirstName;
                listItem.SLastName= item.SLastName;
                listItem.Course = item.Course;
                list.Add(listItem);
            }

            return View(list);

             }




    }       
}
