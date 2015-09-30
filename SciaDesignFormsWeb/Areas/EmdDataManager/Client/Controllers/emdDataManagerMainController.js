angular.module("emdDataManagerApplicationModule")
    .controller("emdDataManagerMainController", function ($scope, clientIntegrationFolder)
    {
        $scope.documentView = function ()
        {
            return clientIntegrationFolder + 'Views/sectionCheckDocumentView.html';
        };
        $scope.checkTableView = function ()
        {
            return clientIntegrationFolder + 'Views/sectionCheckCheckTableView.html';
        };
    });