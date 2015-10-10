angular.module("emdDataManagerApplicationModule")
    .controller("emdDataManagerEmdFilesController", function ($scope, clientIntegrationFolder)
    {
        // MEMBERS

        // EVENTS

        // METHODS
        $scope.structuresView = function ()
        {
            return clientIntegrationFolder + 'Views/emdDataManagerStructuresView.html';
        };
        $scope.membersView = function ()
        {
            return clientIntegrationFolder + 'Views/emdDataManagerMembersView.html';
        };
        $scope.sectionView = function ()
        {
            return clientIntegrationFolder + 'Views/emdDataManagerSectionsView.html';
        };

        //CTOR
    });