angular.module("emdDataManagerApplicationModule")
    .controller("emdDataManagerMainController", function ($scope, clientIntegrationFolder)
    {
        $scope.fileUploadView = function ()
        {
            return clientIntegrationFolder + 'Views/emdDataManagerFileUploadView.html';
        };
        $scope.emdFilesView = function ()
        {
            return clientIntegrationFolder + 'Views/emdDataManagerEmdFilesView.html';
        };
    });