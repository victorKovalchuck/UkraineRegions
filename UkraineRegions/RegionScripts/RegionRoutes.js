myModule.config(['$routeProvider', '$locationProvider',
        function ($routeProvider, $locationProvider) {
            $routeProvider
    .when("/RegionsList",
    {
        controller: "RegionsListCntr",
        resolve: {
            Regions: function (RegionsList) {
                return RegionsList();
            }
        },
        templateUrl: 'Home/Regions'
    })
    .when("/EditRegionID=:id",
    {
        controller: "RegionObject",
        resolve: {
            Region: function (RegionObject) {
                return RegionObject();
            }
        },
        templateUrl: 'Home/EditRegion'
    })
    .when("/DeleteRegionID=:id",
    {
        controller: "DeleteRegion",
        resolve: {
            DRegion: function (DeleteObject) {
                return DeleteObject();
            }
        },
        templateUrl: 'Home/Regions'
    })
     .when("/CreateRegion",
    {
        controller: "CreateNewRegion",
        templateUrl: 'Home/CreateRegion'
    })
    .otherwise({ redirectTo: '/RegionsList' });
        } ]);
