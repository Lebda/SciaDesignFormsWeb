/// <reference path="c:\users\jlebduska\documents\visual studio 2013\projects\sciadesignformsweb\emddatamanagerclient\services\emddatamanagerstructureservice.js" />

angular.module("emdDataManagerApplicationModule")
    .controller("emdDataManagerStructuresController", function ($scope, emdDataManagerStructureService, emdEvent_STRUCTURE, emdEvent_STRUCTURE_ADD, emdDataManagerHelpService)
    {
        // EVENTS
        $scope.$on(emdEvent_STRUCTURE, function (event, args)
        {
            if (args.type === emdEvent_STRUCTURE_ADD)
            {
                loadItems();
            }
        });

        // INTERFACE
        $scope.items = null;
        $scope.selectStructure = function (structure)
        {
            emdDataManagerHelpService.selectItem($scope.items, structure);
            emdDataManagerStructureService.publishChange($scope.items, emdDataManagerHelpService.getFirstSelected($scope.items));
        }
        $scope.deleteStructure = function (structure)
        {
            var selected = emdDataManagerHelpService.getFirstSelected($scope.items);
            emdDataManagerStructureService.deleteItem($scope.items, structure, function () { emdDataManagerStructureService.publishDelete(null, null) });
            if (selected !== null && selected.ID === structure.ID)
            {
                emdDataManagerStructureService.publishChange($scope.items, null);
            }
        }

        // METHODS
        var loadItems = function ()
        {
            emdDataManagerStructureService.list().$promise.then(function (data)
            {
                $scope.items = data;
                emdDataManagerStructureService.publishChange($scope.items, emdDataManagerHelpService.getFirstSelected($scope.items));
            });
        };

        // CTOR
        loadItems();
    });