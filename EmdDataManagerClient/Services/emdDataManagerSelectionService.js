angular.module("emdDataManagerApplicationModule")
    .factory('emdDataManagerSelectionService', function ($rootScope, $http, $resource, emdSelectionsRestFullApiUrl)
    {
        var itemChange = function (changeType, changeViewModel)
        {
            $rootScope.$broadcast("emdDataManagerSelectionChange",
                                  {
                                      type: changeType,
                                      viewModel: changeViewModel
                                  });
        };
        var serviceResource = $resource(emdSelectionsRestFullApiUrl + "/:id", { id: "@id" }, { query: { method: "GET", isArray: false } });
        var actualSelection =
        {
            activeStructureID: 0,
            activeMemberID: 0,
            activeSectionID: 0
        };
        var updateActualSelection = function (selection)
        {
            actualSelection.activeStructureID = null;
            actualSelection.activeMemberID = null;
            actualSelection.activeSectionID = null;
            if (selection.ActiveStructure != null)
            {
                actualSelection.activeStructureID = selection.ActiveStructure.ID;
            }
            if (selection.ActiveMember != null)
            {
                actualSelection.activeMemberID = selection.ActiveMember.ID;
            }
            if (selection.ActiveSection != null)
            {
                actualSelection.activeSectionID = selection.ActiveSection.ID;
            }
            itemChange("LOADED", actualSelection);
        };
        var isLoaded = false;
        var obj =
        {
            testList: function ()
            {
                serviceResource.query().$promise.then(function (data)
                {
                    updateActualSelection(data);
                });
            },
            geIsLoaded: function ()
            {
                return isLoaded;
            },
            seIsLoaded: function (value)
            {
                isLoaded = value;
            },
            load : function()
            {
                return serviceResource.query();
            },
            loadingFinish: function (selection)
            {
                updateActualSelection(selection);
            },
            setActiveStructureID: function (index)
            {
                actualSelection.activeStructureID = index;
                itemChange("STRUCTURE SELECTION", actualSelection);
            },
            getActiveStructureID: function (index)
            {
                return actualSelection.activeStructureID;
            },
            deleteStructure: function (index)
            {
                if (index === actualSelection.activeStructureID)
                {
                    actualSelection.activeStructureID = null;
                    actualSelection.activeMemberID = null;
                    actualSelection.activeSectionID = null;
                    itemChange("DELETE SELECTED STRUCTURE", actualSelection);
                }
            },
            setActiveMemberID: function (index)
            {
                actualSelection.activeMemberID = index;
                itemChange("MEMBER SELECTION", actualSelection);
            },
            getActiveMemberID: function (index)
            {
                return actualSelection.activeMemberID;
            },
            setActiveSectionID: function (index)
            {
                actualSelection.activeSectionID = index;
                itemChange("SECTION SELECTION", actualSelection);
            },
            getActiveSectionID: function (index)
            {
                return actualSelection.activeSectionID;
            },
        };
        return obj;
    });