angular.module("emdDataManagerApplicationModule")
    .constant("emdActiveStructureRestFullApiUrl", '/EmdDataManager/api/EmdActiveStructure')
    .constant("emdFileRangesRestFullApiUrl", '/EmdDataManager/api/EmdFileRanges')
    .constant("emdMembersNonRestFullApiUrl", '/EmdDataManager/api/nrest/EmdMembers')
    .constant("emdSectionsRestFullApiUrl", '/EmdDataManager/api/EmdSections')
    .constant("emdMembersRestFullApiUrl", '/EmdDataManager/api/EmdMembers')
    .constant("emdDataStructuresRestFullApiUrl", '/EmdDataManager/api/EmdStructures')
    .constant("emdDataUploadWebApiUrl", '/EmdDataManager/api/EmdFiles/Upload')
    .constant("clientIntegrationFolder", '../../Areas/EmdDataManager/Client/');