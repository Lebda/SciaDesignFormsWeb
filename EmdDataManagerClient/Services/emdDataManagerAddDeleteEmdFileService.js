angular.module("emdDataManagerApplicationModule")
    .service("emdDataManagerAddDeleteEmdFileService", function ($rootScope)
    {
        return {
            emdFileAddEvent: function ()
            {
                //this[type] = zip;
                $rootScope.$broadcast("emdFileAddEvent",
                                      {
                                          //type: type, zipCode: zip
                                      });
            },
            emdFileDeleteEvent: function ()
            {
                $rootScope.$broadcast("emdFileDeleteEvent", {});
            },
        }
    });