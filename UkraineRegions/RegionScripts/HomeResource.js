myModule.factory('Region', ['$resource',
function ($resource) {
    return $resource('/Home/:Method', {Method:'@Method', ID: '@ID' });
} ]);