angular.module("emdDataManagerApplicationModule")
    .controller("emdDataManagerApplicationController", function ($scope, clientIntegrationFolder, emdDataManagerSelectionService)
    {
        // METHODS
        $scope.mainView = function ()
        {
            return clientIntegrationFolder + 'Views/emdDataManagerMainView.html';
        };
    });