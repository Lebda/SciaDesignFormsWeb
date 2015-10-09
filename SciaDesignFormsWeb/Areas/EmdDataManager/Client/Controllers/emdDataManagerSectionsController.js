angular.module("emdDataManagerApplicationModule")
    .controller("emdDataManagerSectionsController", function ($scope, emdDataManagerSelectionService, emdDataManagerSectionService)
    {
        // MEMBERS
        $scope.items = null;

        // EVENTS
        $scope.$on("emdDataManagerSelectionChange", function (event, args)
        {
            if (args.type === "LOADED" || args.type === "STRUCTURE SELECTION" || args.type === "MEMBER SELECTION" || args.type === "DELETE SELECTED STRUCTURE")
            {
                updateItems();
            }
        });

        // METHODS
        var updateItems = function ()
        {
            if (emdDataManagerSelectionService.getActiveMemberID() != null)
            {
                $scope.items = emdDataManagerSectionService.list(emdDataManagerSelectionService.getActiveMemberID());
            }
            else
            {
                $scope.items = null;
            }
        };
        $scope.selectSection = function (section)
        {
            emdDataManagerSectionService.selectItem($scope.items, section);
            emdDataManagerSelectionService.setActiveSectionID(section.ID);
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