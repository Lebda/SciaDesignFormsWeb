angular.module("sectionCheckApplicationModule")
    .controller("sectionCheckMainController", function ($scope, sectionCheckClientFolder)
    {
        $scope.documentView = function ()
        {
            return sectionCheckClientFolder + 'Views/sectionCheckDocumentView.html';
        };
        $scope.checkTableView = function ()
        {
            return sectionCheckClientFolder + 'Views/sectionCheckCheckTableView.html';
        };
        $scope.userSelectionView = function ()
        {
            return sectionCheckClientFolder + 'Views/sectionCheckEmdUserSelectionView.html';
        };
    });