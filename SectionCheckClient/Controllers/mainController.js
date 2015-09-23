angular.module("SectionCheck")
    .controller("mainCtrl", function ($scope, sectionCheckClientFolder)
    {
        $scope.documentView = function ()
        {
            return sectionCheckClientFolder + 'documentView.html';
        };
        $scope.checkTableView = function ()
        {
            return sectionCheckClientFolder + 'checkTableView.html';
        };
    });