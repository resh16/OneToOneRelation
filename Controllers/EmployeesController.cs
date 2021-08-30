using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OneToOneRelation.Models;



namespace OneToOneRelation.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly DataContext _context;

        public EmployeesController(DataContext context)
        {
            _context = context;
        }

        // GET: Employees
        //public async Task<IActionResult> Index()
        //{
        //    var dataContext = _context.employee.Include(e => e.dept);
        //    return View(await dataContext.ToListAsync());
        //}

        public IActionResult Index()
        {
            var dataContext = _context.employee.Where(e=>e.DelStatus=='A').ToList();
            return View(dataContext);
        }

        //[HttpGet]
        //public IActionResult Index(string searchText, string sortOrder)
        //{
        //    ViewData["NameSortParam"] = sortOrder == "Name" ? "name_desc" : "name_asc";
        //    ViewData["DesignationSortParam"] = sortOrder == "Designation" ? "design_desc" : "design_asc";
        //    ViewData["DateSortParam"] = sortOrder == "HireDate" ? "date_desc" : "date_asc";
        //    ViewData["CurrentSearch"] = searchText;

        //    var employee = from emp in _context.employee where emp.DelStatus == 'A' select emp;
        //    if (!string.IsNullOrEmpty(searchText))
        //    {
        //        employee = employee.Where(x => x.Name.ToLower().Contains(searchText.ToLower()));
        //    }

        //    switch (sortOrder)
        //    {
        //        case "name_asc":
        //            employee = employee.OrderBy(x => x.Name);
        //            break;

        //        case "name_desc":
        //            employee = employee.OrderByDescending(x => x.Name);
        //            break;
        //        case "design_asc":
        //            employee = employee.OrderBy(x => x.Designation);
        //            break;
        //        case "design_desc":
        //            employee = employee.OrderByDescending(x => x.Designation);
        //            break;
        //        case "date_asc":
        //            employee = employee.OrderBy(x => x.HireDate);
        //            break;
        //        case "date_desc":
        //            employee = employee.OrderByDescending(x => x.HireDate);
        //            break;
        //        default:
        //            employee = employee.OrderBy(x => x.Id);
        //            break;

        //    }

        //    return View(employee.ToList());


        //}


        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.departments, "DepartmentId", "DepartmentId");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Designation,HireDate,DelStatus,DepartmentId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.departments, "DepartmentId", "DepartmentId", employee.DepartmentId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.departments, "DepartmentId", "DepartmentId", employee.DepartmentId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Designation,HireDate,DelStatus,DepartmentId")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
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
            ViewData["DepartmentId"] = new SelectList(_context.departments, "DepartmentId", "DepartmentId", employee.DepartmentId);
            return View(employee);
        }

        private bool EmployeeExists(int id)
        {
            throw new NotImplementedException();
        }

        public IActionResult Delete(int? id)
        {
            var emp = _context.employee.FirstOrDefault(x => x.Id == id);

            if (emp == null)
            {
                return NotFound();
            }
            _context.employee.Remove(emp);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        
    }
}
