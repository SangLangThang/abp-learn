/* This file is automatically generated by ABP framework to use MVC Controllers from javascript. */


// module fileManagement

(function(){

  // controller volo.fileManagement.files.fileDescriptor

  (function(){

    abp.utils.createNamespace(window, 'volo.fileManagement.files.fileDescriptor');

    volo.fileManagement.files.fileDescriptor.get = function(id, ajaxParams) {
      return abp.ajax($.extend(true, {
        url: abp.appPath + 'api/file-management/file-descriptor/' + id + '',
        type: 'GET'
      }, ajaxParams));
    };

    volo.fileManagement.files.fileDescriptor.getList = function(directoryId, ajaxParams) {
      return abp.ajax($.extend(true, {
        url: abp.appPath + 'api/file-management/file-descriptor' + abp.utils.buildQueryString([{ name: 'directoryId', value: directoryId }]) + '',
        type: 'GET'
      }, ajaxParams));
    };

    volo.fileManagement.files.fileDescriptor.create = function(directoryId, inputWithStream, ajaxParams) {
      return abp.ajax($.extend(true, {
        url: abp.appPath + 'api/file-management/file-descriptor/upload' + abp.utils.buildQueryString([{ name: 'directoryId', value: directoryId }]) + '',
        type: 'POST',
        data: JSON.stringify(inputWithStream)
      }, ajaxParams));
    };

    volo.fileManagement.files.fileDescriptor.move = function(input, ajaxParams) {
      return abp.ajax($.extend(true, {
        url: abp.appPath + 'api/file-management/file-descriptor/move',
        type: 'POST',
        data: JSON.stringify(input)
      }, ajaxParams));
    };

    volo.fileManagement.files.fileDescriptor.getPreInfo = function(input, ajaxParams) {
      return abp.ajax($.extend(true, {
        url: abp.appPath + 'api/file-management/file-descriptor/pre-upload-info',
        type: 'POST',
        data: JSON.stringify(input)
      }, ajaxParams));
    };

    volo.fileManagement.files.fileDescriptor.getContent = function(id, ajaxParams) {
      return abp.ajax($.extend(true, {
        url: abp.appPath + 'api/file-management/file-descriptor/content' + abp.utils.buildQueryString([{ name: 'id', value: id }]) + '',
        type: 'GET'
      }, ajaxParams));
    };

    volo.fileManagement.files.fileDescriptor.getDownloadToken = function(id, ajaxParams) {
      return abp.ajax($.extend(true, {
        url: abp.appPath + 'api/file-management/file-descriptor/download/' + id + '/token',
        type: 'GET'
      }, ajaxParams));
    };

    volo.fileManagement.files.fileDescriptor.rename = function(id, input, ajaxParams) {
      return abp.ajax($.extend(true, {
        url: abp.appPath + 'api/file-management/file-descriptor/' + id + '',
        type: 'POST',
        data: JSON.stringify(input)
      }, ajaxParams));
    };

    volo.fileManagement.files.fileDescriptor['delete'] = function(id, ajaxParams) {
      return abp.ajax($.extend(true, {
        url: abp.appPath + 'api/file-management/file-descriptor/' + id + '',
        type: 'DELETE',
        dataType: null
      }, ajaxParams));
    };

    volo.fileManagement.files.fileDescriptor.download = function(id, token, ajaxParams) {
      return abp.ajax($.extend(true, {
        url: abp.appPath + 'api/file-management/file-descriptor/download/' + id + '' + abp.utils.buildQueryString([{ name: 'token', value: token }]) + '',
        type: 'GET'
      }, ajaxParams));
    };

  })();

  // controller volo.fileManagement.directories.directoryDescriptor

  (function(){

    abp.utils.createNamespace(window, 'volo.fileManagement.directories.directoryDescriptor');

    volo.fileManagement.directories.directoryDescriptor.get = function(id, ajaxParams) {
      return abp.ajax($.extend(true, {
        url: abp.appPath + 'api/file-management/directory-descriptor/' + id + '',
        type: 'GET'
      }, ajaxParams));
    };

    volo.fileManagement.directories.directoryDescriptor.getList = function(parentId, ajaxParams) {
      return abp.ajax($.extend(true, {
        url: abp.appPath + 'api/file-management/directory-descriptor/sub-directories' + abp.utils.buildQueryString([{ name: 'parentId', value: parentId }]) + '',
        type: 'GET'
      }, ajaxParams));
    };

    volo.fileManagement.directories.directoryDescriptor.create = function(input, ajaxParams) {
      return abp.ajax($.extend(true, {
        url: abp.appPath + 'api/file-management/directory-descriptor',
        type: 'POST',
        data: JSON.stringify(input)
      }, ajaxParams));
    };

    volo.fileManagement.directories.directoryDescriptor.rename = function(id, input, ajaxParams) {
      return abp.ajax($.extend(true, {
        url: abp.appPath + 'api/file-management/directory-descriptor/' + id + '',
        type: 'POST',
        data: JSON.stringify(input)
      }, ajaxParams));
    };

    volo.fileManagement.directories.directoryDescriptor.getContent = function(input, ajaxParams) {
      return abp.ajax($.extend(true, {
        url: abp.appPath + 'api/file-management/directory-descriptor' + abp.utils.buildQueryString([{ name: 'filter', value: input.filter }, { name: 'sorting', value: input.sorting }, { name: 'id', value: input.id }]) + '',
        type: 'GET'
      }, ajaxParams));
    };

    volo.fileManagement.directories.directoryDescriptor['delete'] = function(id, ajaxParams) {
      return abp.ajax($.extend(true, {
        url: abp.appPath + 'api/file-management/directory-descriptor/' + id + '',
        type: 'DELETE',
        dataType: null
      }, ajaxParams));
    };

    volo.fileManagement.directories.directoryDescriptor.move = function(input, ajaxParams) {
      return abp.ajax($.extend(true, {
        url: abp.appPath + 'api/file-management/directory-descriptor/move',
        type: 'POST',
        data: JSON.stringify(input)
      }, ajaxParams));
    };

  })();

})();

