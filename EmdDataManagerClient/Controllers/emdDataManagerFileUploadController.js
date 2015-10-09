/// <reference path="c:\users\jlebduska\documents\visual studio 2013\projects\sciadesignformsweb\emddatamanagerclient\services\emddatamanageradddeleteemdfileservice.js" />

angular.module("emdDataManagerApplicationModule")
    .controller('emdDataManagerFileUploadController',
                [
                    '$scope', 'Upload', '$timeout', 'emdDataUploadWebApiUrl', 'emdDataManagerStructureService',
                    function ($scope, Upload, $timeout, emdDataUploadWebApiUrl, emdDataManagerStructureService)
                    {
                        $scope.fileUploadObj = { testString1: "Test string 1", testString2: "Test string 2" };
                        $scope.uploadFiles = function (file)
                        {
                            $scope.f = file;
                            if (file && !file.$error)
                            {
                                file.upload = Upload.upload(
                                    {
                                        url: emdDataUploadWebApiUrl,
                                        method: "POST",
                                        data: { fileUploadObj: $scope.fileUploadObj },
                                        file: file
                                    });

                                file.upload.then(function (response)
                                {
                                    $timeout(function ()
                                    {
                                        file.result = response.data;
                                    });
                                    emdDataManagerStructureService.itemAdded();
                                }, function (response)
                                {
                                    if (response.status > 0)
                                        $scope.errorMsg = response.status + ': ' + response.data;
                                });

                                file.upload.progress(function (evt)
                                {
                                    file.progress = Math.min(100, parseInt(100.0 *
                                                                           evt.loaded / evt.total));
                                });
                            }
                        }
                    }
                ]);