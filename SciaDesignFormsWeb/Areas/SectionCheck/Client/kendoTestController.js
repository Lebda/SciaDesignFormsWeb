angular.module("SectionCheck")
    .controller("kendoTestCtrl", function ($scope, $http, calculationDataUrl)
    {
        $scope.checks = new Array();

        var myDataSource = new kendo.data.DataSource(
            {
            });

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
                        $scope.checks.push(viewModel);
                    });
                    for (var i = 0; i < $scope.checks.length; i++)
                    {
                        myDataSource.add($scope.checks[i]);
                    }
                })
                .error(function ()
                {
                    $scope.checks.length = 0;
                    $scope.error = "An Error has occured while loading calculation data!";
                });
        };
        $scope.clearCalculationData = function ()
        {
            $scope.checks.length = 0;
        }
        function myFunc(model)
        {
            if (model.m_isOn)
            {
                return '<input type="checkbox" checked>';
            }
            return '<input type="checkbox">';
        };
        $scope.mainGridOptions =
        {
            dataSource: myDataSource,
            sortable: true,
            columns:
            [
                    {
                        field: "m_name",
                        title: "First Name",
                        width: "120px"
                    },
                { field: "m_isOn", title: "On" }
            ]
        };
    })