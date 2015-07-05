(function () {

	function CreateApiProxy(apiBaseUrl) {
		return function (apiMethod, httpMethod, id, postData) {
			// create api url
			var apiUrl = apiBaseUrl + "/" + apiMethod;
			if (id != null) {
				apiUrl += "/" + id;
			}

			// make request
			return $.ajax({
				method: httpMethod,
				url: apiUrl,
				dataType: "json",
				contentType: "application/json",
				data: postData
			});
		}
	};




	// create one service proxy per webapi controller
	$(function () {
		window.PersonApi = CreateApiProxy("/api/person");
	});

})();