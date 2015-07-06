using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MvcAjax.Models;

namespace MvcAjax.Helpers
{
	public class Helper
	{

		#region ================================================== Thread Safe Singleton ==================================================

		private static readonly Lazy<Helper> lazy = new Lazy<Helper>(() => new Helper());

		public static Helper Instance { get { return lazy.Value; } }

		private Helper()
		{
		}

		#endregion ================================================== Thread Safe Singleton ==================================================




		#region ================================================== Public Methods ==================================================

		public ServiceResult<T> ExecuteSafely<T>(Func<ServiceResult<T>> func)
		{
			try
			{
				return func();
			}
			catch (Exception exception)
			{
				ServiceResult<T> serviceResult = new ServiceResult<T>(default(T), exception.ToString(), false);
				// TO DO: log exception to database, using service result's datetime stamp
				return serviceResult;
			}
		}

		#endregion ================================================== Public Methods ==================================================

	}
}