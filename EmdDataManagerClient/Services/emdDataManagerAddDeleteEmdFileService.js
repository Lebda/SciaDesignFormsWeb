angular.module("emdDataManagerApplicationModule")
    .service("emdDataManagerAddDeleteEmdFileService", function ($rootScope)
    {
        return {
            emdFileAddDeleteEvent: function ()
            {
                //this[type] = zip;
                $rootScope.$broadcast("emdFileAddDeleteEvent",
                {
                    //type: type, zipCode: zip
                });
            }
        }
    });