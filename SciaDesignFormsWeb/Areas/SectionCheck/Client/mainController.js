angular.module("SectionCheck")
    .controller("mainCtrl", function ($scope, sectionCheckClientFolder)
    {
        $scope.documentView = function ()
        {
            return sectionCheckClientFolder + 'documentView.html';
        };
    });