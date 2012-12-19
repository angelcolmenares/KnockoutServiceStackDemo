using System.Collections.Generic;
using System.Web.Mvc;
using KnockoutServiceStackDemo.Models;
using ServiceStack.Mvc;

namespace KnockoutServiceStackDemo.Controllers
{
  public class GiftListController : BaseController
  {
	public GiftListModel GiftList{get;set;}

    public ActionResult Index()
    {
      InitializeViewBag("Gift list");
			/*
      var model = new GiftListModel
      {
        Gifts = new List<GiftModel>
            {
              new GiftModel {Title = "Tall Hat", Price = 49.95},
              new GiftModel {Title = "Long Cloak", Price = 78.25}
            }
      };
      */
      return View(GiftList);
    }

    public ActionResult AddGift(GiftListModel model)
    {
	
      //model.AddGift();
      //return Json(model);
			//GiftList.Gifts.Add(model.Gifts[model.Gifts.Count-1]);
			model.AddGift();
			return Json(model);
    }

    public ActionResult RemoveGift(GiftListModel model, int index)
	//public ActionResult RemoveGift(int index)
    {
      //model.RemoveGift(index);
			GiftList.RemoveGift(index);
      return Json(GiftList);
    }

    public ActionResult Save(GiftListModel model)
    {
			GiftList.Gifts.Clear();
			foreach( var g in model.Gifts)
				GiftList.Gifts.Add(g);
			GiftList.Save();
			return Json(GiftList);
      //model.Save();
      //return Json(model);
    }
  }
}
