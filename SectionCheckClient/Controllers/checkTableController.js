/// <reference path="c:\users\jlebduska\documents\visual studio 2013\projects\sciadesignformsweb\sectioncheckclient\viewmodels\calculationcontext.js" />
/// <reference path="c:\users\jlebduska\documents\visual studio 2013\projects\sciadesignformsweb\sectioncheckclient\viewmodels\checkviewmodel.js" />

angular.module("SectionCheck")
    .controller("checkTableCtrl", function ($scope, $http, calculationDataUrl)
    {
        $scope.checks = new Array();

        $scope.loadCalculationData = function ()
        {
            var url4Job = calculationDataUrl;
            $http.get(url4Job)
                .success(function (data)
                {
                    $scope.checks.length = 0;
                    data.ChecksData.Checks.forEach(function (item, index, array)
                    {
                        var viewModel = new CheckViewModelGetSet();
                        viewModel.name = item.Name;
                        viewModel.checkValue = item.CheckValue;
                        viewModel.isOn = item.IsOn;
                        viewModel.calulationContext = new CalculationContextGetSet(item.Context.ClcID, item.Context.CombiID, item.Context.OutPutType);
                        $scope.checks.push(angular.copy(item));
                    });
                })
                .error(function ()
                {
                    $scope.checks.length = 0;
                    $scope.error = "An Error has occured while loading calculation data!";
                });
        }

        $scope.clearCalculationData = function ()
        {
            $scope.checks.length = 0;
        }
    });