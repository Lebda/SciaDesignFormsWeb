angular.module("emdDataManagerApplicationModule")
    .controller("emdDataManagerSectionsController", function ($scope, emdDataManagerSectionService, emdEvent_MEMBER, emdEvent_MEMBER_CHANGE, emdDataManagerHelpService)
    {
        // INTERFACE
        $scope.items = null;
        $scope.selectSection = function (section)
        {
            emdDataManagerHelpService.selectItem($scope.items, section);
            emdDataManagerSectionService.publishChange($scope.items, emdDataManagerHelpService.getFirstSelected($scope.items));
        }

        // EVENTS
        $scope.$on(emdEvent_MEMBER, function (event, args)
        {
            if (args.type === emdEvent_MEMBER_CHANGE)
            {
                loadItems(args.activeItem);
            }
        });

        // METHODS
        var loadItems = function (selectedMember)
        {
            if (selectedMember === null)
            {
                $scope.items = null;
            }
            else
            {
                emdDataManagerSectionService.list(selectedMember.ID).$promise.then(function (data)
                {
                    $scope.items = data;
                    emdDataManagerSectionService.publishChange($scope.items, emdDataManagerHelpService.getFirstSelected($scope.items));
                });
            }
        };
    });