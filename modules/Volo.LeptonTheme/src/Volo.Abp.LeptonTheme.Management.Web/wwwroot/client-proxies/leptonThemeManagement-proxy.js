/* This file is automatically generated by ABP framework to use MVC Controllers from javascript. */


// module leptonThemeManagement

(function(){

  // controller volo.abp.leptonTheme.leptonThemeSettings

  (function(){

    abp.utils.createNamespace(window, 'volo.abp.leptonTheme.leptonThemeSettings');

    volo.abp.leptonTheme.leptonThemeSettings.get = function(ajaxParams) {
      return abp.ajax($.extend(true, {
        url: abp.appPath + 'api/lepton-theme-management/settings',
        type: 'GET'
      }, ajaxParams));
    };

    volo.abp.leptonTheme.leptonThemeSettings.update = function(input, ajaxParams) {
      return abp.ajax($.extend(true, {
        url: abp.appPath + 'api/lepton-theme-management/settings',
        type: 'PUT',
        dataType: null,
        data: JSON.stringify(input)
      }, ajaxParams));
    };

  })();

})();

