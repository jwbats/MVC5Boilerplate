using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAjax.Extensions
{
	public static class ExtDateTime
	{

		public static string ToYMDHMS(this DateTime dateTime)
		{
			return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
		}

	}
}