using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothBazar.Web.Controllers
{
    public class SharedController : Controller
    {
        public JsonResult UploadImage()    
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            try
            {
                var file = Request.Files[0];   //check kerage request me kitne file hai
               // var fileName = file.FileName; //same name se image to shave kr dega
                var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);     //file name banalege kyoke agar second time use name se image save hoge to error dega
                //total generrate krega alpha grid     extension same hoga

                var path = Path.Combine(Server.MapPath("~/Content/images/"), fileName);

                file.SaveAs(path);    //file ko iss path pr save kr dege

                result.Data = new { Success = true, ImageURL = string.Format("/Content/images/{0}", fileName)  };


                //var newImage = new Image() { Name = fileName };
                //if(ImagesService.Instance.SaveNewImage(newImage))
                //{
                //    result.Data = new { Success = true, Image = fileName, File = newImage.ID, ImageURL = string.Format("{0}{1}", Variables.ImageFolderPath, fileName) };
                //}
                //else
                //{

                //}

            }
            catch(Exception ex)
            {
                result.Data = new { success = false, Message = ex.Message };
            }
            return result;
        }
    }
}