var myModule = angular.module('RegionsApp', ['ngResource', 'ngRoute']);

myModule.controller("RegionsListCntr", function ($scope, Regions) {
    $scope.regions = Regions;
});
myModule.controller("RegionObject", function ($scope, $location, Region) {
    $scope.region = Region;

    $scope.Save = function () {
        $scope.region.$save({ Method: "EditRegionData" }, function (region) {
            $location.path('/RegionsList');
        });
    }
});
myModule.controller("CreateNewRegion", function ($scope, $location, Region) {
    $scope.region = new Region({});

    $scope.SaveNewRegion = function () {
        $scope.region.$save({ Method: "SaveRegionData" }, function (region) {
            $location.path('/RegionsList');
        });
    }
});

myModule.controller("DeleteRegion", function ($scope, $location) {
    $location.path('/RegionsList');


});

