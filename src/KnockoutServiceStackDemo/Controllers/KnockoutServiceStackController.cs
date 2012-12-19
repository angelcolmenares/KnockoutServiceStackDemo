using System.Text;
using ServiceStack.Mvc;
using System.Web.Mvc;

namespace PerpetuumSoft.Knockout
{
  public abstract class KnockoutServiceStackController : ServiceStackController //Controller
  {  
    protected override JsonResult Json(object data, string contentType, Encoding contentEncoding)
    {
      KnockoutUtilities.ConvertData(data);
      return base.Json(data, contentType, contentEncoding);
    }

    protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
    {
      KnockoutUtilities.ConvertData(data);
       return new JsonResult {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior
            };
    }   
  }
}