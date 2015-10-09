angular.module("emdDataManagerApplicationModule")
    .controller("emdDataManagerApplicationController", function ($scope, clientIntegrationFolder, emdDataManagerSelectionService)
    {
        // CTOR
        emdDataManagerSelectionService.load().$promise.then(function (data)
        {
            emdDataManagerSelectionService.setLoaded(data);
        });

        // METHODS
        $scope.mainView = function ()
        {
            return clientIntegrationFolder + 'Views/emdDataManagerMainView.html';
        };
    });