$(function(){

	// (apiMethod, httpMethod, id, postData)

	PersonApi("RetrieveAllPersons", "GET", null, null)
		.fail(function(){
			console.log("RetrieveAllPersons Fail");
		})
		.done(function(data){
			console.log("RetrieveAllPersons Done");
			console.log(data);
		});
		

	//PersonApi("RetrievePerson", "GET", 1, null)
	//	.fail(function(){
	//		console.log("RetrievePerson Fail");
	//	})
	//	.done(function(data){
	//		console.log("RetrievePerson Done");
	//		console.log(data);
	//	});

});