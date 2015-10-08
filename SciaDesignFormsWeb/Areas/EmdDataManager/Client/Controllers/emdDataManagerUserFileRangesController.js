angular.module("emdDataManagerApplicationModule")
    .controller("emdDataManagerUserFileRangesController", function ($scope, $resource, emdFileRangesRestFullApiUrl)
    {
        // EVENTS
        $scope.$on("emdFileAddEvent", function (event, args)
        { // read again from databse
            $scope.listEmdRanges();
        });
        $scope.$on("emdFileDeleteEvent", function (event, args)
        { // read again from databse
            $scope.listEmdRanges();
        });
        $scope.emdFileRangesResource = $resource(emdFileRangesRestFullApiUrl + "/:id", { id: "@id" });
        $scope.isRangeOk = true;
        $scope.emdFileRanges = null;

        $scope.listEmdRanges = function ()
        {
            $scope.emdFileRanges = $scope.emdFileRangesResource.query().$promise.then(
                function (data)
                {
                    $scope.isRangeOk = (data[0].EmdFilesLimit - data[0].EmdFilesSize) < 100000
                    $scope.emdFileRanges = data;
                });
        }

        $scope.listEmdRanges();
    })