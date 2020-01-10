using System;
using System.Collections.Generic;
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
