angular.module("emdDataManagerApplicationModule")
    .constant("emdEvent_STRUCTURE", 'emdEvent_STRUCTURE')
    .constant("emdEvent_STRUCTURE_CHANGE", 'emdEvent_STRUCTURE_CHANGE')
    .constant("emdEvent_STRUCTURE_DELETE", 'emdEvent_STRUCTURE_DELETE')
    .constant("emdEvent_STRUCTURE_ADD", 'emdEvent_STRUCTURE_ADD')
    .factory('emdDataManagerStructureService', function ($rootScope, $http, $resource,
        emdDataStructuresRestFullApiUrl,
        emdEvent_STRUCTURE, emdEvent_STRUCTURE_CHANGE, emdEvent_STRUCTURE_DELETE, emdEvent_STRUCTURE_ADD)
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
            publishDelete: function (allItems, activeItem)
            {
                itemChangeEvent(emdEvent_STRUCTURE_DELETE, allItems, activeItem);
            },
            list : function()
            {
                return serviceResourceInternal.query();
            },
            deleteItem: function (allItems, item4Delete, callbackAfter)
            {
                item4Delete.$delete({ id: item4Delete.ID }).then(function ()
                {
                    allItems.splice(allItems.indexOf(item4Delete), 1);
                    callbackAfter();
                });
            },
            itemAdded: function ()
            {
                itemChangeEvent(emdEvent_STRUCTURE_ADD, null);
            },
        };
        return obj;
    });