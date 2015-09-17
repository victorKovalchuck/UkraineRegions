myModule.factory('RegionsList', ['Region', '$q',
function (Region, $q) {
    return function () {
        var delay = $q.defer();
        Region.query({ Method: 'RetriveRegionsData' }, function (regions) {
            delay.resolve(regions);
        }, function () {
            delay.reject('Unable to fetch regions');
        });
        return delay.promise;
    };
} ]);


myModule.factory('RegionObject', ['Region', '$route', '$q',
function (Region, $route, $q) {
    return function () {
        var delay = $q.defer();
        Region.get({ Method: 'GetRegionData', ID: $route.current.params.id }, function (Region) {
            delay.resolve(Region);
        }, function () {
            delay.reject('Unable to fetch regions ' + $route.current.params.id);
        });
        return delay.promise;
    };
} ]);


myModule.factory('DeleteObject', ['Region', '$route', '$q',
function (Region, $route, $q) {
    return function () {
        var delay = $q.defer();
        Region.delete({ Method: 'DeleteRegionData', ID: $route.current.params.id }, function (Region) {
            delay.resolve(Region);
        }, function () {
            delay.reject('Unable to fetch regions ' + $route.current.params.id);
        });
        return delay.promise;
    };
} ]);