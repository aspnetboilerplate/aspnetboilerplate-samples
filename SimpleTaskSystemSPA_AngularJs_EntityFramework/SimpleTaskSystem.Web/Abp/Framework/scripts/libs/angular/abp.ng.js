(function (abp, angular) {

    if (!angular) {
        return;
    }

    // 'abp' module ///////////////////////////////////////////////////////////

    var abpModule = angular.module('abp', []);

    abpModule.config([
        '$httpProvider', function ($httpProvider) {
            $httpProvider.interceptors.push(function () {
                return {
                    'request': function (config) {
                        return config;
                    },

                    'response': function (response) {
                        if (!response.config || !response.config.abp) {
                            return response;
                        }

                        //var data = response.data;
                        if (!response.data) { //Needless check?
                            return response;
                        }

                        if (response.data.targetUrl) { //TODO: Check if it works and does not prevent return value!
                            location.href = data.targetUrl;
                        }

                        if (response.data.success === true) {
                            response.data = response.data.result;
                        } else { //data.success === false
                            if (response.data.error) {
                                //abp.log.error(response.data.error.details);
                                abp.message.error(response.data.error.message);
                                throw response.data.error.message;
                            }

                            if (response.data.unAuthorizedRequest && !response.data.targetUrl) {
                                location.reload();
                            }
                        }

                        return response;
                    },

                    //'responseError': function (rejection) {
                    //    alert(1);
                    //    console.log('asd: ' + rejection);

                    //    return $q.reject(rejection);
                    //}
                };
            });
        }
    ]);

    abpModule.factory('services.tasksystem.task', [
        '$http', function ($http) {
            return new function () {
                //Working on this code!
                this.getTasks = function (input) {
                    return $http({
                        url: '/api/services/tasksystem/task/GetTasks',
                        method: 'POST',
                        data: JSON.stringify(input),
                        abp: true
                    });
                };
            };
        }
    ]);

})((abp || (abp = {})), (angular || undefined));