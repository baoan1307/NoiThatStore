using System.Web.Mvc;
using Model;
using Service;
using ShopingCart.Common;

namespace ShopingCart.Areas.Admin.Controllers
{
    public class FootersController : BaseController
    {
		private FooterService footerService;
		public FootersController()
		{
			footerService = new FooterService();
		}
		
		[HasCredential(ActionId = 5)]
		public ActionResult Index()
        {
            return View(footerService.GetAll());
        }

		
		[HasCredential(ActionId = 6)]
		public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HasCredential(ActionId = 6)]
		public ActionResult Create([Bind(Include = "ID,Content,Status")] Footer footer)
        {
            if (ModelState.IsValid)
            {
				var result= footerService.Insert(footer);
				if (result > 0)
				{
					TempData["message"] = "Added";
				}
				else
				{
					TempData["message"] = "false";
				}
				return RedirectToAction("Index");
            }

            return View(footer);
        }

		
		[HasCredential(ActionId = 7)]
		public ActionResult Edit(int id)
        {
            Footer footer = footerService.GetById(id);
            if (footer == null)
            {
                return HttpNotFound();
            }
            return View(footer);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HasCredential(ActionId = 7)]
		public ActionResult Edit([Bind(Include = "ID,Content,Status")] Footer footer)
        {
            if (ModelState.IsValid)
            {
				var result= footerService.Update(footer);
				if (result > 0)
				{
					TempData["message"] = "Added";
				}
				else
				{
					TempData["message"] = "false";
				}
				return RedirectToAction("Index");
            }
            return View(footer);
        }

	
		[HasCredential(ActionId = 8)]
		public ActionResult Delete(int id)
        {
			var result= footerService.Delete(id);
			if (result > 0)
			{
				TempData["message"] = "Added";
			}
			else
			{
				TempData["message"] = "false";
			}
			return RedirectToAction("Index");
        }

       
    }
}
