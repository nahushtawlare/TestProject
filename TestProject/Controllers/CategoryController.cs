using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestProject.Infrastructure.IRepository;
using TestProject.Models;

namespace TestProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategory _services;

        public CategoryController(ICategory services)
        {
            _services = services;
        }

        // GET: CategoryController
        public ActionResult Index()
        {
            CategoryInfoModel model = new CategoryInfoModel();
            model.CategoriesList = _services.GetCategoryData();
            return View(model);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            CategoryInfo model = new CategoryInfo();    
            model=_services.GetCategoryById(id);
            return View(model);
        }

        // GET: CategoryController/Create
        public ActionResult AddEditCategory(int id)
        {
            CategoryInfo model = new CategoryInfo();
            model = _services.GetCategoryById(id);
            if(model == null)
            {
                return View();
            }
            else
            {
                return View(model);
            }
        }

        // POST: CategoryController/Create
        [HttpPost]
        public ActionResult Create(CategoryInfo infomodel)
        {
            CategoryInfo model=new CategoryInfo();
            try
            {
              
                model =_services.AddCategory(infomodel);
                if (model.TotalRowCount > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return View();
            }
        }

       

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       
        [HttpPost]
        
        public ActionResult Delete(CategoryInfo infomodel)
        {
            CategoryInfo model = new CategoryInfo();
            try
            {

                model = _services.DeleteCategory(infomodel);
                if (model.TotalRowCount > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
