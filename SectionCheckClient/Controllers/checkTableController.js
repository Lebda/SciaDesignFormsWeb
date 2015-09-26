/// <reference path="c:\users\jlebduska\documents\visual studio 2013\projects\sciadesignformsweb\sectioncheckclient\viewmodels\calculationcontext.js" />
/// <reference path="c:\users\jlebduska\documents\visual studio 2013\projects\sciadesignformsweb\sectioncheckclient\viewmodels\checkviewmodel.js" />

angular.module("SectionCheck")
    .controller("checkTableCtrl", function ($scope, $http, calculationDataUrl)
    {
        $scope.items = new Array();
        $scope.selectedRowIndex = -1;
        $scope.settings =
        {
            Rows: "succes",
            Columns: "Green"
        };

        $scope.setSelectedRowIndex = function (rowIndex)
        {
            $scope.selectedRowIndex = rowIndex;
        };
        $scope.getRowStyle = function (actItem)
        {
            return "oddTableLine";
        };

        $scope.loadCalculationData = function ()
        {
            var url4Job = calculationDataUrl;
            $http.get(url4Job)
                .success(function (data)
                {
                    $scope.items.length = 0;
                    data.ChecksData.Checks.forEach(function (item, index, array)
                    {
                        var viewModel = new CheckViewModelGetSet();
                        viewModel.name = item.Name;
                        viewModel.checkValue = item.CheckValue;
                        viewModel.isOn = item.IsOn;
                        viewModel.calulationContext = new CalculationContextGetSet(item.Context.ClcID, item.Context.CombiID, item.Context.OutPutType);
                        $scope.items.push(viewModel);
                    });
                })
                .error(function ()
                {
                    $scope.items.length = 0;
                    $scope.error = "An Error has occured while loading calculation data!";
                });
        }

        $scope.clearCalculationData = function ()
        {
            $scope.items.length = 0;
        }
    });