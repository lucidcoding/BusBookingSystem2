describe("A suite", function () {
    it("contains spec with an expectation", function () {
        expect(true).toBe(true);
    });

    it("fails", function () {
        expect(true).toBe(false);
    });
});

describe('Unit: MainController', function () {
    // Load the module with MainController
    beforeEach(module('myApp'));

    var ctrl, scope;
    // inject the $controller and $rootScope services
    // in the beforeEach block
    beforeEach(inject(function ($controller, $rootScope) {
        // Create a new scope that's a child of the $rootScope
        scope = $rootScope.$new();
        // Create the controller
        ctrl = $controller('MainController', {
            $scope: scope
        });
    }));

    it('should create $scope.greeting when calling sayHello',
    function () {
        expect(scope.greeting).toBeUndefined();
        scope.sayHello();
        expect(scope.greeting).toEqual("Hello Ari");
    });
});



describe('Controller: public/AboutController', function () {
    //var $scope, $bookingService;

    beforeEach(module('busBookingSystemApp.bookingIndexController'));

    var mockBookingService = {

            getAll: function () {
                return {
                    something: 'nothing'
                };
            },

            getById: function (id) {
                return {
                    something: 'nothing'
                };
            },

            save: function (data) {
                return {
                    something: 'nothing'
                };
            }
    };

    beforeEach(inject(function ($rootScope, $controller) { // inject mocked service
        scope = $rootScope.$new();

        ctrl = $controller('bookingIndexController', {
            $scope: scope,
            bookingService: mockBookingService
        });

    }));


    it('should make about menu item active.', function () {
        expect($rootScope.activeMenu.about == 'active');
    });

});