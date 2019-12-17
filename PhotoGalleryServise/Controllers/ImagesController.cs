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
		public string TestImage()
		{
			return "In Test";
		}
	}
}
