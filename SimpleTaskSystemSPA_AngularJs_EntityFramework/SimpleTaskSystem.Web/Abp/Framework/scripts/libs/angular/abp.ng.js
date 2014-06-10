(function(abp, angular) {

    if (!angular) {
        return;
    }

    // 'abp' module ///////////////////////////////////////////////////////////

    var abpModule = angular.module('abp', []);

    abpModule.config([
        '$httpProvider', function($httpProvider) {
            //$httpProvider.defaults.transformResponse.push(function (a) {
            //    return a;
            //});
        }
    ]);

    abpModule.factory('abp.$http', [
        '$q', '$http', function($q, $http) {
            return function (options) {

                options.transformResponse = function(strData) {
                    var data = strData && JSON.parse(strData);
                    if (data) {
                        if (data.targetUrl) {
                            location.href = data.targetUrl;
                        }

                        if (data.success === true) {
                            return data.result;
                        } else { //data.success === false
                            if (data.error) {
                                abp.message.error(data.error.message);
                            }

                            if (data.unAuthorizedRequest && !data.targetUrl) {
                                location.reload();
                            }

                            if (data.targetUrl) {
                                location.href = data.targetUrl;
                            }

                            //TODO: ERROR
                            return null;
                        }
                    } else { //no data sent to back
                        return strData;
                    }
                };

                return $http(options);
            };
        }
    ]);

    abpModule.factory('services.tasksystem.task', [
        'abp.$http', function($http) {
            return new function() {
                //this.getTasks = abp.services.tasksystem.task.getTasks;

                //Working on this code!
                this.getTasks = function(input) {
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