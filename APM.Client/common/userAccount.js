(function () {

    "use strict";

    angular.module('common.services')
        .factory('userAccount', ['$resource', 'appSettings', userAccount]);

    function userAccount($resource, appSettings) {
        return $resource(appSettings.serverPath + '/api/account/register', null, {
            'registerUser': {
                method: 'post'
            }
        });
    }

})();