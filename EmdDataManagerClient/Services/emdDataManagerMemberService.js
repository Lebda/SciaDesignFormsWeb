angular.module("emdDataManagerApplicationModule")
    .constant("emdEvent_MEMBER", 'emdEvent_MEMBER')
    .constant("emdEvent_MEMBER_CHANGE", 'emdEvent_MEMBER_CHANGE')
    .factory('emdDataManagerMemberService', function ($rootScope, $http, $resource, emdMembersRestFullApiUrl, emdEvent_MEMBER, emdEvent_MEMBER_CHANGE)
    {
        var serviceResource = $resource(emdMembersRestFullApiUrl + "/:id", { id: "@id" });
        var itemChangeEvent = function (changeType, all, active)
        {
            $rootScope.$broadcast(emdEvent_MEMBER,
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
                itemChangeEvent(emdEvent_MEMBER_CHANGE, allItems, activeItem);
            },
            list : function(sctructureID)
            {
                return serviceResource.query({ id: sctructureID });
            },
        };
        return obj;
    });