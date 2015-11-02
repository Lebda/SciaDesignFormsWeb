angular.module("sectionCheckApplicationModule")
    .factory('sectionCheckEmdSelectionService', function ($rootScope, $http, $resource, emdSelectionsRestFullApiUrl)
    {
        var serviceResource = $resource(emdSelectionsRestFullApiUrl, null,
                                        {
                                            'query': { method: 'GET', isArray: false }
                                        });
        var obj =
        {
            list : function()
            {
                return serviceResource.query();
            },
        };
        return obj;
    });