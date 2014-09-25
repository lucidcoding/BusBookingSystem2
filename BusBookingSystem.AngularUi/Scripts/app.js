angular.module('busBookingSystemApp', [
  'busBookingSystemApp.controllers',
  'busBookingSystemApp.bookingIndexController',
  'busBookingSystemApp.bookingViewController',
  'busBookingSystemApp.bookingAddController',
  'busBookingSystemApp.bookingEditController',
  'busBookingSystemApp.services',
  'ngRoute'
]).
config(['$routeProvider', function ($routeProvider) {
    $routeProvider.
	when("/booking/index", { templateUrl: "Partials/Booking/index.html", controller: "bookingIndexController" }).
	when("/booking/view/:id", { templateUrl: "Partials/Booking/view.html", controller: "bookingViewController" }).
	when("/booking/add", { templateUrl: "Partials/Booking/addEdit.html", controller: "bookingAddController" }).
	when("/booking/edit/:id", { templateUrl: "Partials/Booking/addEdit.html", controller: "bookingEditController" }).
	otherwise({ redirectTo: '/booking/index' });
} ]);