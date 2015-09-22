angular.module("SectionCheck")
    .controller("documentCtrl", function ($scope, $http, calculationDocumentUrl)
    {
        $scope.calculationContext = new CalculationContext(2, 1, "eBrief");
        $scope.showCanvas = false;

        $scope.loadDocument = function (calcContext)
        {
            var url4Job = calculationDocumentUrl + 'Get/' + calcContext.GetClcID() + '/' + calcContext.GetCombiID() + '/' + calcContext.GetOutPutType();
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
                    $scope.error = "An Error has occured while loading posts!";
                });
        }

        $scope.clearDocument = function ()
        {
            $scope.showCanvas = false;
        }
    });