angular.module("emdDataManagerApplicationModule")
//.controller('emdDataManagerFileUploadController',
//           [
//               '$scope', 'Upload', function ($scope, Upload)
//               {
//                   $scope.upload = [];
//                   $scope.fileUploadObj = { testString1: "Test string 1", testString2: "Test string 2" };
//                   $scope.onFileSelect = function ($files)
//                   {
//                       //$files: an array of files selected, each file has name, size, and type.
//                       for (var i = 0; i < $files.length; i++)
//                       {
//                           var $file = $files[i];
//                           (function (index)
//                           {
//                               $scope.upload[index] = Upload.upload(
//                                   {
//                                       url: "./api/files/upload", // webapi url
//                                       method: "POST",
//                                       data: { fileUploadObj: $scope.fileUploadObj },
//                                       file: $file
//                                   }).progress(function (evt)
//                                   {
//                                       // get upload percentage
//                                       console.log('percent: ' + parseInt(100.0 * evt.loaded / evt.total));
//                                   }).success(function (data, status, headers, config)
//                                   {
//                                       // file is uploaded successfully
//                                       console.log(data);
//                                   }).error(function (data, status, headers, config)
//                                   {
//                                       // file failed to upload
//                                       console.log(data);
//                                   });
//                           })(i);
//                       }
//                   }
//                   $scope.abortUpload = function (index)
//                   {
//                       $scope.upload[index].abort();
//                   }
//               }
//           ]);
    .controller('emdDataManagerFileUploadController',
                [
                    '$scope', 'Upload', '$timeout', 'emdDataUploadWebApiUrl', function ($scope, Upload, $timeout, emdDataUploadWebApiUrl)
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