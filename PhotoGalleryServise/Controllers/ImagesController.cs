using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhotoGalleryServise.Controllers
{
	public class ImagesController : ApiController
	{
		[HttpGet]
		public string TestImage()
		{
			return "In Test";
		}


        [HttpPost()]
        public string UploadFiles()
        {
            int iUploadedCnt = 0;

            // DEFINE THE PATH WHERE WE WANT TO SAVE THE FILES.
            string sPath = "";
            sPath = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Images/");

            System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;

            // CHECK THE FILE COUNT.
            for (int iCnt = 0; iCnt <= hfc.Count - 1; iCnt++)
            {
                System.Web.HttpPostedFile hpf = hfc[iCnt];

                if (hpf.ContentLength > 0)
                {
                    // CHECK IF THE SELECTED FILE(S) ALREADY EXISTS IN FOLDER. (AVOID DUPLICATE)
                    if (!File.Exists(sPath + Path.GetFileName(hpf.FileName)))
                    {
                        // SAVE THE FILES IN THE FOLDER.
                        hpf.SaveAs(sPath + Path.GetFileName(hpf.FileName));
                        iUploadedCnt = iUploadedCnt + 1;
                    }
                }
            }

            // RETURN A MESSAGE (OPTIONAL).
            if (iUploadedCnt > 0)
            {
                return iUploadedCnt + " Files Uploaded Successfully";
            }
            else
            {
                return "Upload Failed";
            }
        }

        public bool ThumbnailCallback()
        {
            return false;
        }

        [HttpGet]
        public IEnumerable<byte[]> GetImages()
        {
            //Get Image folder path
            string sPath = "";
            List<byte[]> imgData = new List<byte[]>();
            sPath = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Images/");

            //string[] filePaths = Directory.GetFiles(sPath, "*.*");

            foreach (string file in Directory.EnumerateFiles(sPath, "*.*"))
            {
                Bitmap myBitmap = new Bitmap(file);

                Image.GetThumbnailImageAbort myCallback =
                                    new Image.GetThumbnailImageAbort(ThumbnailCallback);

                Image myThumbnail = myBitmap.GetThumbnailImage(
                40, 40, myCallback, IntPtr.Zero);

                byte[] contents = (byte[])(new ImageConverter()).ConvertTo(myThumbnail, typeof(byte[]));

                //  File.ReadAllText(file);
                imgData.Add(contents);
            }

            //Get all Images in that folder

            return imgData;
        }
    #region Required Methods

    //Get all Images
    //Get Sorted Images (sort on categories)
    //Upload Image 
    //Delete Image
    //Edit Image (Edit Info of Image (example- change category or any other related info))
    #endregion
    //
}
}
