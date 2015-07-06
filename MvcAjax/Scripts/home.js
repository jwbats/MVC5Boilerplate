$(function () {

	function RemovePerson() {
		PersonApi("RemovePerson", "DELETE", 101, null)
			.fail(function () {
				console.log("RemovePerson Fail");
			})
			.done(function (data) {
				console.log("RemovePerson Done");
				console.log(data);
			})
			.always(function () {
				console.log("Callchain end.");
			});
	}


	function UpdatePerson() {
		PersonApi("UpdatePerson", "PUT", null, { Id: 101, FirstName: "Jack", LastName: "Applestack", Age: 34 })
			.fail(function () {
				console.log("UpdatePerson Fail");
			})
			.done(function (data) {
				console.log("UpdatePerson Done");
				console.log(data);
			})
			.always(function () {
				RemovePerson();
			});
	}


	function AddPerson() {
		PersonApi("AddPerson", "POST", null, { Id: 101, FirstName: "Jack", LastName: "Applestack", Age: 24 })
			.fail(function () {
				console.log("AddPerson Fail");
			})
			.done(function (data) {
				console.log("AddPerson Done");
				console.log(data);
			})
			.always(function () {
				UpdatePerson();
			});
	}


	function RetrievePerson() {
		PersonApi("RetrievePerson", "GET", 1, null)
			.fail(function () {
				console.log("RetrievePerson Fail");
			})
			.done(function (data) {
				console.log("RetrievePerson Done");
				console.log(data);
			})
			.always(function () {
				AddPerson();
			});
	}


	function RetrieveAllPersons() {
		PersonApi("RetrieveAllPersons", "GET", null, null)
			.fail(function () {
				console.log("RetrieveAllPersons Fail");
			})
			.done(function (data) {
				console.log("RetrieveAllPersons Done");
				console.log(data);
			})
			.always(function () {
				RetrievePerson();
			});
	}


	// starts a callback chain to test the PersonController WebAPI
	RetrieveAllPersons();
});