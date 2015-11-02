angular.module("sectionCheckApplicationModule")
    .factory('sectionCheckSdfChecksService', function ($rootScope, $http, $resource, sdfCheksRestFullApiUrl)
    {
        var serviceResource = $resource(sdfCheksRestFullApiUrl);
        var obj =
        {
            list : function()
            {
                return serviceResource.query();
            },
        };
        return obj;
    });