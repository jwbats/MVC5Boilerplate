window.Utils = {};

Utils.isNullOrWhitespace = function (str) {
	return (str == null) || (str.trim().length == 0);
};