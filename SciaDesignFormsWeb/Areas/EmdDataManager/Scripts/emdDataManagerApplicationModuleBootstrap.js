angular.module("emdDataManagerApplicationModule")
    .constant("emdFileRangesRestFullApiUrl", '/EmdDataManager/api/EmdFileRanges')
    .constant("emdDataRestFullApiUrl", '/EmdDataManager/api/EmdStructures')
    .constant("emdDataUploadWebApiUrl", '/EmdDataManager/api/EmdFiles/Upload')
    .constant("clientIntegrationFolder", '../../Areas/EmdDataManager/Client/');