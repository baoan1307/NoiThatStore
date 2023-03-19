using System.Web.Mvc;
using Model;
using Service;
using ShopingCart.Common;

namespace ShopingCart.Areas.Admin.Controllers
{
    public class AboutsController : BaseController
    {
		private AboutService _aboutService;
		public AboutsController()
		{
			_aboutService = new AboutService();

		}
		[HasCredential(ActionId = 27)]
		
		public ActionResult Index()
		{
			return View(_aboutService.GetAll());
		}


		[HasCredential(ActionId = 28)]
		
		public ActionResult Create()
		{
			return View();
		}

		
		[HttpPost]
		[HasCredential(ActionId = 28)]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "ID,Name,Slug,Detail,CreatedDate,ModifileDate,Image,Status")] About about)
		{
			if (ModelState.IsValid)
			{
				var result  = _aboutService.Insert(about);
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

			return View(about);
		}

		
		[HasCredential(ActionId = 29)]
		public ActionResult Edit(int id)
		{
			About about = _aboutService.GetById(id);
			if (about == null)
			{
				return HttpNotFound();
			}
			return View(about);
		}

		
		[HttpPost]
		[HasCredential(ActionId = 29)]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "ID,Name,Slug,Detail,CreatedDate,ModifileDate,Image,Status")] About about)
		{
			if (ModelState.IsValid)
			{
				var result = _aboutService.Update(about);
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
			return View(about);
		}

		
		[HasCredential(ActionId = 30)]
		public ActionResult Delete(int id)
		{
			var result=_aboutService.Delete(id);
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
