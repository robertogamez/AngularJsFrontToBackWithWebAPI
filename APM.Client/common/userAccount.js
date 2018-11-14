﻿(function () {

    "use strict";

    angular.module('common.services')
        .factory('userAccount', ['$resource', 'appSettings', userAccount]);

    function userAccount($resource, appSettings) {
        return {
            registration: 
                $resource(appSettings.serverPath + '/api/account/register', null, {
                    'registerUser': {
                        method: 'post'
                    }
                }),
            login: $resource(appSettings.serverPath + '/Token', null, {
                'loginUser': {
                    method: 'post',
                    headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                    transformRequest: function (data, headersGetter) {
                        var str = [];
                        for (var d in data) {
                            str.push(encodeURIComponent(d) + '=' + encodeURIComponent(data[d]));
                        }

                        return str.join('&');
                    }
                }
            })
        };
    }

})();