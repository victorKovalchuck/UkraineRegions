
describe("AngularControllerTest", function () {
    var httpBackend, mockRegionResource, $controller, resource, $scope = {}, Region = {};


    beforeEach(function () {
        module('RegionsApp');
    });
    beforeEach(inject(function (_$controller_) {
        $controller = _$controller_;
    }));

    beforeEach(function () {
        angular.mock.inject(function ($injector) {
            $controller = $injector.get('$controller');
            $location = $injector.get('$location');
            httpBackend = $injector.get('$httpBackend');
            resource = $injector.get('$resource');
            mockRegionResource = $injector.get('Region');
            var contr = $controller("RegionObject", { '$scope': $scope, '$location': $location, 'Region': mockRegionResource });
        });
    });

    describe("ResourceTest", function () {
        it("shoud test controller--(RegionObject)", function () {

            expect($scope.region).toBe(mockRegionResource);
        })
    });


    describe("ResourceTest", function () {
        it("shoud test Resource --(Region)", function () {
            var $scope = {};
            var $location = {};
            var Ship = {};
            httpBackend.expectGET('/Home/GetRegionData?ID=1')
                .respond({
                    ID: 1
                });
            var result = mockRegionResource.get({
                Method: 'GetRegionData',
                ID: 1
            });
            httpBackend.flush();
            expect(result.ID).toEqual(1);
        });
    });


    describe("FactoryTest", function () {
        var Region = {}, MyRegionObject = {};


        beforeEach(inject(function ($injector) {
            MyRegionObject = $injector.get('RegionsList');
            Region = $injector.get('Region');
        }));


        it("shoud test factory--(RegionsList)", function () {
            httpBackend.expectGET('/Home/RetriveRegionsData')
                .respond([{
                    ID: 1
                }]);
            spyOn(Region, 'query');

            var res = MyRegionObject();
            expect(Region.query).toHaveBeenCalled();
        });
    });
});