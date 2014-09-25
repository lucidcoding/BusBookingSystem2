angular.module('busBookingSystemApp.bookingEditController', []).
controller('bookingEditController', function ($scope, $routeParams, bookingService, busService) {
    $scope.id = $routeParams.id;
    $scope.busses = [];

    busService.getAll().
    success(function (response) {
        $scope.busses = response;
    }).
    error(function (data, status, headers, config) {
        alert('error: ' + status);
    });

    bookingService.getById($scope.id).
    success(function (response) {
        $scope.startDate = response.StartDate;
        $scope.endDate = response.EndDate;
        $scope.destination = response.Destination;
        $scope.bus = response.Bus;
        $scope.customers = response.Customers;

        if ($scope.customers == null) {
            $scope.customers = [];
        }
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
            Id: $scope.id,
            StartDate: $scope.startDate,
            EndDate: $scope.endDate,
            BusId: $scope.bus.Id,
            Destination: $scope.destination,
            Customers: $scope.customers
        };

        bookingService.save(data);
    };
});