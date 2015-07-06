using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MvcAjax.Helpers;
using MvcAjax.Models;
using MvcAjax.Repo;

namespace MvcAjax.Controllers
{
	public class PersonController : ApiController
	{

		#region ================================================== Public Methods ==================================================

		[HttpGet]
		public ServiceResult<Person[]> RetrieveAllPersons()
		{
			return Helper.Instance.ExecuteSafely<Person[]>(() => {
				return new ServiceResult<Person[]>(
					MockPersonRepo.Instance.Persons.Values.ToArray()
				);
			});
		}




		[HttpGet]
		public ServiceResult<Person> RetrievePerson(int id)
		{
			return Helper.Instance.ExecuteSafely<Person>(() => {
				return (MockPersonRepo.Instance.Persons.ContainsKey(id))
					? new ServiceResult<Person>(MockPersonRepo.Instance.Persons[id])
					: new ServiceResult<Person>(null, "Person id not found.", false);
			});
		}




		[HttpPost]
		public ServiceResult<Person> AddPerson([FromBody]Person person)
		{
			return Helper.Instance.ExecuteSafely<Person>(() => {
				bool containsKey = MockPersonRepo.Instance.Persons.ContainsKey(person.Id);

				if (!containsKey)
				{
					MockPersonRepo.Instance.Persons[person.Id] = person;
				}

				return (!containsKey)
					? new ServiceResult<Person>(person)
					: new ServiceResult<Person>(null, "Person id already exists.", false);
			});
		}




		[HttpPut]
		public ServiceResult<Person> UpdatePerson([FromBody]Person person)
		{
			return Helper.Instance.ExecuteSafely<Person>(() => {
				bool containsKey = MockPersonRepo.Instance.Persons.ContainsKey(person.Id);

				if (containsKey)
				{
					MockPersonRepo.Instance.Persons[person.Id] = person;
				}

				return (containsKey)
					? new ServiceResult<Person>(person)
					: new ServiceResult<Person>(null, "Person id not found.", false);
			});
		}




		[HttpDelete]
		public ServiceResult<int> RemovePerson(int id)
		{
			return Helper.Instance.ExecuteSafely<int>(() => {
				bool containsKey = MockPersonRepo.Instance.Persons.ContainsKey(id);

				if (containsKey)
				{
					MockPersonRepo.Instance.Persons.Remove(id);
				}

				return (containsKey)
					? new ServiceResult<int>(id)
					: new ServiceResult<int>(0, "Person id not found.", false);
			});
		}

		#endregion ================================================== Public Methods ==================================================

	}
}