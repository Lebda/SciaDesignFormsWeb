/// <reference path="c:\users\jlebduska\documents\visual studio 2013\projects\sciadesignformsweb\emddatamanagerclient\services\emddatamanagerstructureservice.js" />

angular.module("emdDataManagerApplicationModule")
    .controller("emdDataManagerEmdFilesController", function ($scope, emdDataManagerSelectionService, emdDataManagerStructureService, clientIntegrationFolder)
    {
        // MEMBERS
        $scope.emdStructures = emdDataManagerStructureService.list();

        // EVENTS
        $scope.$on("emdDataManagerStructuresChange", function (event, args)
        {
            if (args.type === "ADD")
            {
                $scope.emdStructures = emdDataManagerStructureService.list();
            }
        });

        // METHODS
        $scope.members4SelectedStructureView = function ()
        {
            return clientIntegrationFolder + 'Views/emdDataManagerMembersView.html';
        };
        $scope.section4SelectedMemberView = function ()
        {
            return clientIntegrationFolder + 'Views/emdDataManagerSectionsView.html';
        };
        $scope.selectStructure = function (structure)
        {
            emdDataManagerStructureService.selectItem($scope.emdStructures, structure);
            emdDataManagerSelectionService.setActiveStructureID(structure.ID);
            emdDataManagerSelectionService.testList();
            emdDataManagerSelectionService.load().$promise.then(function (data)
            {
                emdDataManagerSelectionService.loadingFinish(data);
            });
        }
        $scope.deleteStructure = function (structure)
        {
            emdDataManagerStructureService.deleteItem($scope.emdStructures, structure);
            emdDataManagerSelectionService.deleteStructure(structure.ID);
        }
    });