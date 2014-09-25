angular.module('busBookingSystemApp.controllers', []).
controller('bookingIndexController', function ($scope, bookingService) {
    $scope.bookingList = [];

    bookingService.getAll().
    success(function (response) {
        $scope.bookingList = response;
    }).
    error(function (data, status, headers, config) {
        alert('error: ' + status);
    });
}).
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
}).
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
}).
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
}).
directive("datepicker", function () {
    return {
        restrict: "A",
        require: "ngModel",
        link: function (scope, elem, attrs, ngModelCtrl) {
            var updateModel = function (dateText) {
                scope.$apply(function () {
                    ngModelCtrl.$setViewValue(dateText);
                });
            };
            var options = {
                dateFormat: "dd/mm/yy",
                onSelect: function (dateText) {
                    updateModel(dateText);
                }
            };
            $(elem).datepicker(options);
            //alert('this works');
        }
    }
});

