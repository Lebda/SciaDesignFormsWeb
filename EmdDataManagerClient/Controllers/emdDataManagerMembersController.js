angular.module("emdDataManagerApplicationModule")
    .controller("emdDataManagerMembersController", function ($scope, emdDataManagerSelectionService, emdDataManagerMemberService)
    {
        // MEMBERS
        $scope.items = null;

        // EVENTS
        $scope.$on("emdDataManagerSelectionChange", function (event, args)
        {
            if (args.type === "LOADED" || args.type === "STRUCTURE SELECTION" || args.type === "DELETE SELECTED STRUCTURE")
            {
                updateItems();
            }
        });

        // METHODS
        var updateItems = function ()
        {
            if (emdDataManagerSelectionService.getActiveStructureID() != null)
            {
                $scope.items = emdDataManagerMemberService.list(emdDataManagerSelectionService.getActiveStructureID());
            }
            else
            {
                $scope.items = null;
            }
        };
        $scope.selectMember = function (member)
        {
            emdDataManagerMemberService.selectItem($scope.items, member);
            emdDataManagerSelectionService.setActiveMemberID(member.ID);
        }
        
        // CTOR
        if (emdDataManagerSelectionService.geIsLoaded() === false)
        {
            emdDataManagerSelectionService.seIsLoaded(true);
            emdDataManagerSelectionService.load().$promise.then(function (data)
            {
                emdDataManagerSelectionService.loadingFinish(data);
            });
        }
    });