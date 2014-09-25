angular.module('busBookingSystemApp.bookingViewController', []).
controller('bookingViewController', function ($scope, $routeParams, bookingService) {
    $scope.id = $routeParams.id;
    $scope.booking = null;

    bookingService.getById($scope.id).
    success(function (response) {
        $scope.booking = response;
    }).
    error(function (data, status, headers, config) {
        alert('error: ' + status);
    });
});