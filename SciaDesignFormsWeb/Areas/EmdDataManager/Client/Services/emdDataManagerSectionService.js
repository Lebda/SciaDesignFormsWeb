angular.module("emdDataManagerApplicationModule")
    .constant("emdEvent_SECTION", 'emdEvent_SECTION')
    .constant("emdEvent_SECTION_CHANGE", 'emdEvent_SECTION_CHANGE')
    .factory('emdDataManagerSectionService', function ($rootScope, $http, $resource, emdSectionsRestFullApiUrl, emdEvent_SECTION, emdEvent_SECTION_CHANGE)
    {
        var serviceResource = $resource(emdSectionsRestFullApiUrl + "/:id", { id: "@id" });
        var itemChangeEvent = function (changeType, all, active)
        {
            $rootScope.$broadcast(emdEvent_SECTION,
                                  {
                                      type: changeType,
                                      activeItem: active,
                                      allItems: all
                                  });
        };
        var obj =
        {
            publishChange: function (allItems, activeItem)
            {
                itemChangeEvent(emdEvent_SECTION_CHANGE, allItems, activeItem);
            },
            list : function(memberID)
            {
                return serviceResource.query({ id: memberID });
            },
        };
        return obj;
    });