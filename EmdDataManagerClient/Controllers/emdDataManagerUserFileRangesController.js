angular.module("emdDataManagerApplicationModule")
    .controller("emdDataManagerUserFileRangesController", function ($scope, $resource, emdFileRangesRestFullApiUrl, emdEvent_STRUCTURE, emdEvent_STRUCTURE_DELETE, emdEvent_STRUCTURE_ADD)
    {
        // INTERFACE
        $scope.emdFileRangesResource = $resource(emdFileRangesRestFullApiUrl + "/:id", { id: "@id" });
        $scope.isRangeOk = true;
        $scope.emdFileRanges = null;

        // EVENTS
        $scope.$on(emdEvent_STRUCTURE, function (event, args)
        {
            if (args.type === emdEvent_STRUCTURE_ADD || args.type === emdEvent_STRUCTURE_DELETE)
            {
                listEmdRanges();
            }
        });

        // METHODS
        var listEmdRanges = function ()
        {
            $scope.emdFileRanges = $scope.emdFileRangesResource.query().$promise.then(
                function (data)
                {
                    $scope.isRangeOk = (data[0].EmdFilesLimit - data[0].EmdFilesSize) < 100000
                    $scope.emdFileRanges = data;
                });
        }

        // CTOR
        listEmdRanges();
    })