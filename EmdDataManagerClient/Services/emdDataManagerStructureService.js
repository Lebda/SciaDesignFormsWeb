angular.module("emdDataManagerApplicationModule")
    .constant("emdEvent_STRUCTURE", 'emdEvent_STRUCTURE')
    .constant("emdEvent_STRUCTURE_CHANGE", 'emdEvent_STRUCTURE_CHANGE')
    .factory('emdDataManagerStructureService', function ($rootScope, $http, $resource,
        emdDataStructuresRestFullApiUrl,
        emdEvent_STRUCTURE, emdEvent_STRUCTURE_CHANGE)
    {
        var itemChangeEvent = function (changeType, all, active)
        {
            $rootScope.$broadcast(emdEvent_STRUCTURE,
                                  {
                                      type: changeType,
                                      activeItem : active,
                                      allItems: all
                                  });
        };
        var serviceResourceInternal = $resource(emdDataStructuresRestFullApiUrl + "/:id", { id: "@id" });
        var obj =
        {
            publishChange: function (allItems, activeItem)
            {
                itemChangeEvent(emdEvent_STRUCTURE_CHANGE, allItems, activeItem);
            },
            list : function()
            {
                return serviceResourceInternal.query();
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
                itemChangeEvent("ADD", null);
            },
        };
        return obj;
    });