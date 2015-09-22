angular.module("SectionCheck", [])
    .constant("sectionCheckClientFolder", '../../Areas/SectionCheck/Client/')
    .constant("calculationDocumentUrl", '/Calculation/api/nrest/Document/')
    .controller("appCtrl", function ($scope, sectionCheckClientFolder)
    {
        $scope.mainView = function ()
        {
            return sectionCheckClientFolder + 'mainView.html';
        };
    });