angular.module("sectionCheckApplicationModule")
    .constant("emdUserSelection_NOT_SEL", '"Not selected"')
    .controller("sectionCheckEmdUserSelectionController", function ($scope, emdUserSelection_NOT_SEL, sectionCheckEmdSelectionService)
    {
        // INTERFACE
        $scope.userSelectionViewModel = new UserSelectionViewModelGetSet(emdUserSelection_NOT_SEL, emdUserSelection_NOT_SEL, 0, 0.0);

        // METHODS
        var loadItems = function ()
        {
            sectionCheckEmdSelectionService.list().$promise.then(function (data)
            {
                $scope.userSelectionViewModel.structure = (data.ActiveStructure !== null) ? data.ActiveStructure.Name : emdUserSelection_NOT_SEL;
                $scope.userSelectionViewModel.member = (data.ActiveMember !== null) ? data.ActiveMember.Name : emdUserSelection_NOT_SEL;
                $scope.userSelectionViewModel.sectionIndex = (data.ActiveSection !== null) ? data.ActiveSection.Index : "-";
                $scope.userSelectionViewModel.sectionPosition = (data.ActiveSection !== null) ? data.ActiveSection.Position : "-";
            });
        };

        // CTOR
        loadItems();
    });