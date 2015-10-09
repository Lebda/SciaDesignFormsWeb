angular.module("emdDataManagerApplicationModule")
    .factory('emdDataManagerStructureService', function ($rootScope, $http, $resource, emdDataStructuresRestFullApiUrl)
    {
        var emdDataManagerStructuresChange = function (changeType, changeViewModel)
        {
            $rootScope.$broadcast("emdDataManagerStructuresChange",
                                  {
                                      type: changeType,
                                      viewModel: changeViewModel
                                  });
        };
        var serviceResource = $resource(emdDataStructuresRestFullApiUrl + "/:id", { id: "@id" });
        var updateItem = function (item)
        {
            item.$save();
        };
        var obj =
        {
            list : function()
            {
                return serviceResource.query();
            },
            getActive: function (allItems)
            {
                var retVal = null;
                allItems.forEach(function (item, index, array)
                {
                    if (item.IsSelected === true)
                    {
                        retVal = item;
                    }
                });
                return retVal;
            },
            selectItem: function (allItems, activeItem)
            {
                allItems.forEach(function (item, index, array)
                {
                    if (item.IsSelected === true)
                    {
                        item.IsSelected = false;
                        updateItem(item);
                    }
                    if (item.ID === activeItem.ID)
                    {
                        item.IsSelected = true;
                        updateItem(item);
                    }
                });
            },
            deleteItem: function (allItems, item4Delete)
            {
                item4Delete.$delete({ id: item4Delete.ID }).then(function ()
                {
                    allItems.splice(allItems.indexOf(item4Delete), 1);
                });
            },
            itemAdded: function ()
            {
                emdDataManagerStructuresChange("ADD", null);
            },
        };
        return obj;
    });