/// <reference path="c:\users\jlebduska\documents\visual studio 2013\projects\sciadesignformsweb\emddatamanagerclient\services\emddatamanagerstructureservice.js" />

angular.module("emdDataManagerApplicationModule")
    .controller("emdDataManagerStructuresController", function ($scope, emdDataManagerStructureService, emdEvent_STRUCTURE, emdDataManagerHelpService)
    {
        // MEMBERS
        $scope.items = null;

        // EVENTS
        $scope.$on(emdEvent_STRUCTURE, function (event, args)
        {
            if (args.type === "ADD")
            {
                $scope.items = emdDataManagerStructureService.list();
            }
        });

        // METHODS
        $scope.selectStructure = function (structure)
        {
            emdDataManagerHelpService.selectItem($scope.items, structure);
            emdDataManagerStructureService.publishChange($scope.items, emdDataManagerHelpService.getFirstSelected($scope.items));
        }
        $scope.deleteStructure = function (structure)
        {
            emdDataManagerStructureService.deleteItem($scope.items, structure);
            //emdDataManagerSelectionService.deleteStructure(structure.ID);
        }

        // CTOR
        emdDataManagerStructureService.list().$promise.then(function (data)
        {
            $scope.items = data;
            emdDataManagerStructureService.publishChange($scope.items, emdDataManagerHelpService.getFirstSelected($scope.items));
        });
    });