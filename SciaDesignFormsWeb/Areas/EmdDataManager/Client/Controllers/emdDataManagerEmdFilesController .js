angular.module("emdDataManagerApplicationModule")
    .controller("emdDataManagerEmdFilesController", function ($scope, $http, $resource, emdDataRestFullApiUrl, emdDataManagerAddDeleteEmdFileService)
    {
        $scope.displayMode = "list";
        $scope.currentProduct = null;
        $scope.emdStructures = null;
 
        $scope.emdStructureResource = $resource(emdDataRestFullApiUrl + "/:id", { id: "@id" });

        // EVENTS
        $scope.$on("emdFileAddDeleteEvent", function (event, args)
        { // read again from databse
            $scope.listEmdStructures();
        });
 
        $scope.listEmdStructures = function ()
        {
            $scope.emdStructures = $scope.emdStructureResource.query();
        }
        $scope.updateStructure = function (structure)
        {
            structure.$save();
        }
        $scope.deleteStructure = function (structure)
        {
            structure.$delete({ id: structure.ID }).then(function ()
            {
                $scope.emdStructures.splice($scope.emdStructures.indexOf(structure), 1);
            });
        }
        $scope.selectStructure = function (structure)
        {
            $scope.emdStructures.forEach(function (item, index, array)
            {
                if (item.ID != structure.ID)
                {
                    item.IsSelected = false;
                }
                else
                {
                    item.IsSelected = true;
                }
                $scope.updateStructure(item);
            });
        }


        $scope.listEmdStructures();
        //$scope.createProduct = function (product)
        //{
        //    new $scope.productsResource(product).$save().then(function(newProduct)
        //    {
        //        $scope.products.push(newProduct);
        //        $scope.displayMode = "list";
        //    });
        //}
        //$scope.editOrCreateProduct = function (product)
        //{
        //    $scope.currentProduct = product ? product : {};
        //    $scope.displayMode = "edit";
        //}
        //$scope.saveEdit = function (product)
        //{
        //    if (angular.isDefined(product.id))
        //    {
        //        $scope.updateProduct(product);
        //    }
        //    else
        //    {
        //        $scope.createProduct(product);
        //    }
        //}
        //$scope.cancelEdit = function ()
        //{
        //    if ($scope.currentProduct && $scope.currentProduct.$get)
        //    {
        //        $scope.currentProduct.$get();
        //    }
        //    $scope.currentProduct = {};
        //    $scope.displayMode = "list";
        //}
    });