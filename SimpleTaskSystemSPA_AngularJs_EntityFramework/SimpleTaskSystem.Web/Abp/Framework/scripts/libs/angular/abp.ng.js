(function (abp, angular) {

    if (!angular) {
        return;
    }

    // 'abp' module ///////////////////////////////////////////////////////////

    var abpModule = angular.module('abp', []);

    abpModule.config([
        '$httpProvider', function ($httpProvider) {
            $httpProvider.interceptors.push(function ($q) {
                return {
                    'response': function (response) {
                        if (!response.config || !response.config.abp || !response.data) {
                            return response;
                        }

                        var defer = $q.defer();

                        if (response.data.targetUrl) { //TODO: Check if it works and does not prevent return value!
                            location.href = data.targetUrl;
                        }

                        if (response.data.success === true) {
                            response.data = response.data.result;
                            defer.resolve(response);
                        } else { //data.success === false
                            if (response.data.error) {
                                abp.message.error(response.data.error.message);
                            } else {
                                response.data.error = {
                                    message: 'Ajax request is not succeed!',
                                    details: 'Error detail is not sent by server.'
                                };
                            }

                            abp.log.error(response.data.error.message + ' | ' + response.data.error.details);

                            response.data = response.data.error;
                            defer.reject(response);

                            if (response.data.unAuthorizedRequest && !response.data.targetUrl) {
                                location.reload();
                            }
                        }

                        return defer.promise;
                    }
                };
            });
        }
    ]);

    abpModule.factory('services.tasksystem.task', [
        '$http', function ($http) {
            return new function () {
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