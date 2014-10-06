angular.module('busBookingSystemApp.bookingIndexController', []).
controller('bookingIndexController', function ($scope, bookingService) {
    $scope.bookingList = [];

    bookingService.getAll().
    success(function (response) {
        $scope.bookingList = response;
    }).
    error(function (data, status, headers, config) {
        alert('error: ' + status);
    });
});
