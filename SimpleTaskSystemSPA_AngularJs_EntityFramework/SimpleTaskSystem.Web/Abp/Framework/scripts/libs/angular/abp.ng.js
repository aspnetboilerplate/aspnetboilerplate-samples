(function (abp, angular) {

    if (!angular) {
        return;
    }

    // 'abp' module ///////////////////////////////////////////////////////////

    var abpModule = angular.module('abp', []);

    abpModule.config([
        '$httpProvider', function ($httpProvider) {
            //$httpProvider.defaults.transformResponse.push(function (a) {
            //    return a;
            //});
        }
    ]);

    abpModule.factory('abp.$http', [
        '$q', '$http', function ($q, $http) {

            //var defaultOptions = {
            //    transformResponse: function (strData) {
            //        if (!strData) {
            //            return strData;
            //        }

            //        var data = JSON.parse(strData);
            //        if (!data) { //Needless check?
            //            return strData;
            //        }

            //        if (data.targetUrl) { //TODO: Check if it works and does not prevent return value!
            //            location.href = data.targetUrl;
            //        }

            //        if (data.success === true) {
            //            return data.result;
            //        } else { //data.success === false
            //            if (data.error) {
            //                abp.log.error(data.error.details);
            //                abp.message.error(data.error.message);
            //            }

            //            if (data.unAuthorizedRequest && !data.targetUrl) {
            //                location.reload();
            //            }

            //            return data;
            //        }

            //    }
            //};

            return function (options) {

                return $http($.extend({}, defaultOptions, options));
            };
        }
    ]);

    abpModule.factory('services.tasksystem.task', [
        'abp.$http', function ($http) {
            return new function () {
                //Working on this code!
                this.getTasks = function (input) {
                    return $http({
                        url: '/api/services/tasksystem/task/GetTasks',
                        method: 'POST',
                        data: JSON.stringify(input)
                    });
                };
            };
        }
    ]);

})((abp || (abp = {})), (angular || undefined));