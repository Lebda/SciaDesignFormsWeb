angular.module("emdDataManagerApplicationModule")
    .controller("emdDataManagerApplicationController", function ($scope, clientIntegrationFolder)
    {
        // METHODS
        $scope.mainView = function ()
        {
            return clientIntegrationFolder + 'Views/emdDataManagerMainView.html';
        };
    });