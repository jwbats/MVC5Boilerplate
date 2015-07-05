using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MvcAjax
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new StyleBundle("~/Content/css").Include(
				"~/Content/bootstrap.css"
			));

			bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
				"~/Scripts/jquery-1.9.1.js",
				"~/Scripts/moment.js",
				"~/Scripts/bootstrap.js",
				"~/Scripts/bootstrap-datetimepicker.js"
			));
		}
	}
}