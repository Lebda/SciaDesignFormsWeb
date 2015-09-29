angular.module("sectionCheckApplicationModule")
    .controller("sectionCheckApplicationController", function ($scope, sectionCheckClientFolder)
    {
        $scope.mainView = function ()
        {
            return sectionCheckClientFolder + 'Views/sectionCheckMainView.html';
        };
    });