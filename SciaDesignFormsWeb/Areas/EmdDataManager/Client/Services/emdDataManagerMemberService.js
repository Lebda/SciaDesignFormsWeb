angular.module("emdDataManagerApplicationModule")
    .factory('emdDataManagerMemberService', function ($rootScope, $http, $resource, emdMembersRestFullApiUrl)
    {
        var serviceResource = $resource(emdMembersRestFullApiUrl + "/:id", { id: "@id" });
        var updateItem = function (item)
        {
            item.$save();
        };
        var itemChange = function (changeType, changeViewModel)
        {
            $rootScope.$broadcast("emdDataManagerMembersChange",
                                  {
                                      type: changeType,
                                      viewModel: changeViewModel
                                  });
        };
        var obj =
        {
            list : function(sctructureID)
            {
                return serviceResource.query({ id: sctructureID });
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