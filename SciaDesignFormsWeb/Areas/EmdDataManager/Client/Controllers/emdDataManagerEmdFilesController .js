﻿angular.module("emdDataManagerApplicationModule")
    .controller("emdDataManagerEmdFilesController", function ($scope, $http, $resource, emdDataRestFullApiUrl, emdDataManagerAddDeleteEmdFileService)
    {
        $scope.displayMode = "list";
        $scope.currentProduct = null;
        $scope.emdFiles = null;
 
        $scope.emdFilesResource = $resource(emdDataRestFullApiUrl + ":id", { id: "@id" });

        // EVENTS
        $scope.$on("emdFileAddDeleteEvent", function (event, args)
        { // read again from databse
            $scope.listEmdFiles();
        });
 
        $scope.listEmdFiles = function ()
        {
            $scope.emdFiles = $scope.emdFilesResource.query();
        }
        //$scope.listEmdFiles = function ()
        //{
        //    $http.get(emdDataRestFullApiUrl).success(function (data)
        //    {
        //        $scope.emdFiles = data;
        //    });
        //};
        $scope.listEmdFiles();
        //$scope.deleteProduct = function (product)
        //{
        //    product.$delete().then(function ()
        //    {
        //        $scope.products.splice($scope.products.indexOf(product), 1);
        //    });
        //    $scope.displayMode = "list";
        //}
        //$scope.createProduct = function (product)
        //{
        //    new $scope.productsResource(product).$save().then(function(newProduct)
        //    {
        //        $scope.products.push(newProduct);
        //        $scope.displayMode = "list";
        //    });
        //}
        //$scope.updateProduct = function (product)
        //{
        //    product.$save();
        //    $scope.displayMode = "list";
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