using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

using MvcAjax.Models;

namespace MvcAjax.Repo
{
	public class MockPersonRepo
	{

		#region ================================================== Thread Safe Singleton ==================================================

		private static readonly Lazy<MockPersonRepo> lazy = new Lazy<MockPersonRepo>(() => new MockPersonRepo());
	
		public static MockPersonRepo Instance { get { return lazy.Value; } }

		private MockPersonRepo()
		{
			InitPersons();
		}

		#endregion ================================================== Thread Safe Singleton ==================================================




		#region ================================================== Public Members ==================================================

		public Dictionary<int, Person> Persons;

		#endregion ================================================== Public Members ==================================================




		#region ================================================== Private Methods ==================================================

		private Person CreatePerson(int id, string name)
		{
			string[] names = name
				.Split(new char[] { ' ' })
				.Select(x => x.Trim())
				.ToArray();

			int age = new Random().Next(0, 200);

			return new Person()
			{
				Id        = id,
				FirstName = names[0],
				LastName  = names[1],
				Age       = age
			};
		}




		private void InitPersons()
		{
			this.Persons = new Dictionary<int, Person>();

			string[] names = File.ReadAllLines(
				HttpContext.Current.Server.MapPath("/Repo/Names.txt")
			);

			this.Persons = names
				.Select((x, i) => CreatePerson(i + 1, x))
				.ToDictionary(x => x.Id, y => y);
		}

		#endregion ================================================== Private Methods ==================================================

	}
}