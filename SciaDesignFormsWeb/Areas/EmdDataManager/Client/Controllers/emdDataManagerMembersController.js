angular.module("emdDataManagerApplicationModule")
    .controller("emdDataManagerMembersController", function ($scope, emdDataManagerMemberService, emdEvent_STRUCTURE, emdEvent_STRUCTURE_CHANGE, emdDataManagerHelpService)
    {
        // INTERFACE
        $scope.items = null;
        $scope.selectMember = function (member)
        {
            emdDataManagerHelpService.selectItem($scope.items, member);
            emdDataManagerMemberService.publishChange($scope.items, emdDataManagerHelpService.getFirstSelected($scope.items));
        }

        // EVENTS
        $scope.$on(emdEvent_STRUCTURE, function (event, args)
        {
            if (args.type === emdEvent_STRUCTURE_CHANGE)
            {
                loadItems(args.activeItem);
            }
        });


        // METHODS
        var loadItems = function (selectedStructure)
        {
            if (selectedStructure === null)
            {
                $scope.items = null;
            }
            else
            {
                emdDataManagerMemberService.list(selectedStructure.ID).$promise.then(function (data)
                {
                    $scope.items = data;
                    emdDataManagerMemberService.publishChange($scope.items, emdDataManagerHelpService.getFirstSelected($scope.items));
                });
            }
        };
    });