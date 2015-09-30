angular.module("emdDataManagerApplicationModule")
    .controller("emdDataManagerApplicationController", function ($scope, clientIntegrationFolder)
    {
        $scope.mainView = function ()
        {
            return clientIntegrationFolder + 'Views/emdDataManagerMainView.html';
        };
    });