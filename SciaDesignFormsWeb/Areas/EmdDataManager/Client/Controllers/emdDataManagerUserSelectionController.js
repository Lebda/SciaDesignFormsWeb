angular.module("emdDataManagerApplicationModule")
    .controller("emdDataManagerUserSelectionController", function ($scope)
    {
        $scope.userSelectionViewModel = new UserSelectionViewModelGetSet("Not selected", "-", 0, 0.0);
    });