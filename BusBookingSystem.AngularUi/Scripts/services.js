angular.module('busBookingSystemApp.services', []).
factory('bookingService', function ($http) {

    var bookingService = {};

    bookingService.getAll = function () {
        return $http({
            method: 'GET',
            url: 'http://localhost:54482/Booking'
        });
    };

    bookingService.getById = function (id) {
        return $http({
            method: 'GET',
            url: 'http://localhost:54482/Booking/' + id
        });
    };

    bookingService.save = function (data) {
        return $http({
            method: 'POST',
            url: 'http://localhost:54482/Booking/',
            data: data
        });
    };

    return bookingService;
}).
factory('busService', function ($http) {

    var busService = {};

    busService.getAll = function () {
        return $http({
            method: 'GET',
            url: 'http://localhost:54482/Bus'
        });
    }

    return busService;
});