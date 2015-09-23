angular.module("SectionCheck", [])
    .constant("sectionCheckClientFolder", '../../Areas/SectionCheck/Client/')
    .constant("calculationDocumentUrl", '/Calculation/api/nrest/Document/')
    .constant("calculationDataUrl", '/Calculation/api/CalculationData/')
    .controller("appCtrl", function ($scope, sectionCheckClientFolder)
    {
        $scope.mainView = function ()
        {
            return sectionCheckClientFolder + 'mainView.html';
        };
    });