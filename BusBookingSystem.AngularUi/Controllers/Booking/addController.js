angular.module('busBookingSystemApp.bookingAddController', []).
controller('bookingAddController', function ($scope, $routeParams, bookingService, busService) {
    //$scope.id = $routeParams.id;
    $scope.busses = [];
    $scope.customers = [];

    busService.getAll().
    success(function (response) {
        $scope.busses = response;
    }).
    error(function (data, status, headers, config) {
        alert('error: ' + status);
    });

    $scope.addCustomer = function () {
        var newCustomer = {
            Id: guid(),
            FirstName: $scope.newCustomerFirstName,
            Surname: $scope.newCustomerFirstName,
            DrivingLicenceNumber: $scope.newCustomerDrivingLicenceNumber
        };

        $scope.customers.push(newCustomer);
    };

    $scope.submit = function () {
        var data = {
            StartDate: $scope.startDate,
            EndDate: $scope.endDate,
            BusId: $scope.bus.Id,
            Destination: $scope.destination,
            Customers: $scope.customers
        };

        bookingService.save(data);
    };
});