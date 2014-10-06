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

angular.module('mock.bookingService', []).
    factory('UserService', function ($q) {
        var bookingService = {};

        bookingService.getAll = function () {
            return {
                something : 'nothing'
            };
        };

        bookingService.getById = function (id) {
            return {
                something: 'nothing'
            };
        };

        bookingService.save = function (data) {
            return {
                something: 'nothing'
            };
        };

        return bookingService;
    });

describe('Controller: public/AboutController', function () {
    var $scope, $bookingService;

    beforeEach(module('busBookingSystemApp.bookingIndexController'));
    beforeEach(module('busBookingSystemApp.bookingIndexController'));
    beforeEach(module('mock.bookingService'));

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


//    beforeEach(module({
//        mockBookingService: {

//            getAll: function () {
//                return {
//                    something: 'nothing'
//                };
//            },

//            getById: function (id) {
//                return {
//                    something: 'nothing'
//                };
//            },

//            save: function (data) {
//                return {
//                    something: 'nothing'
//                };
//            }
//        }
//    }));

//    beforeEach(inject(function (_$rootScope_, _$controller_) {
//        $rootScope = _$rootScope_;
//        $scope = $rootScope.$new();
//        $controller = _$controller_;
//        
//        $controller('bookingIndexController', { '$rootScope': $rootScope, '$scope': $scope, 'bookingService': mockBookingService });
//    }));





//    beforeEach(function () {
//        module(function ($provide) {
//            $provide.value('bookingService', mockBookingService);
//        });
//    });

//    var ctrl, scope;

//    beforeEach(module('busBookingSystemApp.bookingIndexController'));

//    // include previous module containing mocked service which will override actual service, because it's declared later
//    beforeEach(module('mock.bookingService'));

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

//    it('should show title.', function () {
//        expect($rootScope.showTitle == true);
//    });

//    it('should have correct page title.', function () {
//        expect($rootScope.page_title).toEqual('About Me');
//    });

//    it('should have correct page description.', function () {
//        expect($rootScope.page_description).toEqual('Here is my story.');
//    });
});