angular.module("emdDataManagerApplicationModule")
    .factory('emdDataManagerSectionService', function ($rootScope, $http, $resource, emdSectionsRestFullApiUrl)
    {
        var serviceResource = $resource(emdSectionsRestFullApiUrl + "/:id", { id: "@id" });
        var updateItem = function (item)
        {
            item.$save();
        };
        var itemChange = function (changeType, changeViewModel)
        {
            $rootScope.$broadcast("emdDataManagerSectionsChange",
                                  {
                                      type: changeType,
                                      viewModel: changeViewModel
                                  });
        };
        var obj =
        {
            list : function(memberID)
            {
                return serviceResource.query({ id: memberID });
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
                itemChange("SELECT", activeItem);
            },
        };
        return obj;
    });