angular.module("emdDataManagerApplicationModule")
    .factory('emdDataManagerHelpService', function ()
    {
        var emdDataManagerApplicationGetFirstSelected = function (allItems)
        {
            if (!angular.isArray(allItems))
            {
                return null;
            }
            for (counter = 0; counter < allItems.length; counter++)
            {
                if (allItems[counter] === null || !angular.isDefined(allItems[counter].IsSelected))
                {
                    continue;
                }
                if (allItems[counter].IsSelected === true)
                {
                    return allItems[counter];
                }
            }
            return null;
        };
        var emdDataManagerApplicationSelectItem = function (allItems, activeItem)
        {
            if (!angular.isArray(allItems))
            {
                return;
            }
            for (counter = 0; counter < allItems.length; counter++)
            {
                if (allItems[counter] === null || !angular.isDefined(allItems[counter].IsSelected))
                {
                    continue;
                }
                if (allItems[counter].IsSelected === true)
                {
                    allItems[counter].IsSelected = false;
                    if (angular.isDefined(allItems[counter].$save))
                    {
                        allItems[counter].$save();
                    }
                }
                if (allItems[counter].ID === activeItem.ID)
                {
                    allItems[counter].IsSelected = true;
                    if (angular.isDefined(allItems[counter].$save))
                    {
                        allItems[counter].$save();
                    }
                }
            }
        };
        var obj =
        {
            getFirstSelected: emdDataManagerApplicationGetFirstSelected,
            selectItem: emdDataManagerApplicationSelectItem,
        };
        return obj;
    });