/// <reference path="c:\users\jlebduska\documents\visual studio 2013\projects\sciadesignformsweb\sectioncheckclient\viewmodels\calculationcontext.js" />

angular.module("sectionCheckApplicationModule")
    .controller("sectionCheckDocumentController", function ($scope, $http, calculationDocumentUrl)
    {
        $scope.calculationContext = new CalculationContext(2, 1, "eBrief");
        $scope.showCanvas = false;

        $scope.loadDocument = function (calcContext)
        {
            var url4Job = calculationDocumentUrl + 'Get/' + calcContext.m_clcID + '/' + calcContext.m_combiID + '/' + calcContext.m_outPutType;
            $http.get(url4Job)
                .success(function (data)
                {
                    var ctx = document.getElementById("canvas").getContext("2d");
                    ctx.canvas.width = data.CanvasWidth;
                    ctx.canvas.height = data.CanvasHeight;
                    data.Pictures.forEach(function (item, index, array)
                    {
                        var imgFromWebApi = new Image();
                        imgFromWebApi.src = "data:image/gif;base64, " + item.Base64String;
                        ctx.drawImage(imgFromWebApi, item.Location.BoundsLocationX, item.Location.BoundsLocationY, item.Location.BoundsWidth, item.Location.BoundsHeight);
                    });
                    $scope.showCanvas = true;
                })
                .error(function ()
                {
                    $scope.showCanvas = false;
                    $scope.error = "An Error has occured while loading document!";
                });
        }

        $scope.clearDocument = function ()
        {
            $scope.showCanvas = false;
        }
    });