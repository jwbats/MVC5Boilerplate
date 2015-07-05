using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MvcAjax.Extensions;

namespace MvcAjax.Models
{
	public class ServiceResult<T>
	{
		public T        Data     { get; set; }
		public string   Message  { get; set; }
		public bool     Success  { get; set; }
		public string   DateTime { get; set; }

		public ServiceResult(T data, string message = "", bool success = true)
		{
			this.Data     = data;
			this.Message  = message;
			this.Success  = success;
			this.DateTime = System.DateTime.Now.ToYMDHMS();
		}
	}
}