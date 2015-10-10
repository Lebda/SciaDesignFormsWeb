angular.module("emdDataManagerApplicationModule")
    .constant("emdUserSelection_NOT_SEL", '"Not selected"')
    .controller("emdDataManagerUserSelectionController", function ($scope, emdUserSelection_NOT_SEL,
        emdEvent_STRUCTURE, emdEvent_STRUCTURE_CHANGE,
        emdEvent_MEMBER, emdEvent_MEMBER_CHANGE,
        emdEvent_SECTION, emdEvent_SECTION_CHANGE)
    {
        // INTERFACE
        $scope.userSelectionViewModel = new UserSelectionViewModelGetSet(emdUserSelection_NOT_SEL, emdUserSelection_NOT_SEL, 0, 0.0);

        // EVENTS
        $scope.$on(emdEvent_STRUCTURE, function (event, args)
        {
            if (args.type === emdEvent_STRUCTURE_CHANGE)
            {
                $scope.userSelectionViewModel.structure = (args.activeItem !== null) ? args.activeItem.Name : emdUserSelection_NOT_SEL;
            }
        });
        $scope.$on(emdEvent_MEMBER, function (event, args)
        {
            if (args.type === emdEvent_MEMBER_CHANGE)
            {
                $scope.userSelectionViewModel.member = (args.activeItem !== null) ? args.activeItem.Name : emdUserSelection_NOT_SEL;
            }
        });
        $scope.$on(emdEvent_SECTION, function (event, args)
        {
            if (args.type === emdEvent_SECTION_CHANGE)
            {
                $scope.userSelectionViewModel.sectionIndex = (args.activeItem !== null) ? args.activeItem.Index : "-";
                $scope.userSelectionViewModel.sectionPosition = (args.activeItem !== null) ? args.activeItem.Position : "-";
            }
        });
    });