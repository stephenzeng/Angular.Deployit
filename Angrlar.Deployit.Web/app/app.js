'use strict';

angular.module('MyApp', [])
    .controller('MyController', function($scope, $http, $log) {
        $scope.projects = [];
        $scope.selectedProject = {};
        $scope.requestSent = false;
        $scope.builds = {};
        $scope.deployments = {};
        $scope.errorMessage = '';


    $http.get('/api/projects').
        success(function(data, status, headers, config) {
            $log.info(data);
            $scope.projects = data;
        }).
        error(function(data, status, headers, config) {
            $log.info(data);
        });
        
    $scope.projectChange = function() {
        if ($scope.selectedProject.Id > 0) {
            $http.get('/api/tfs').
            success(function (data, status, headers, config) {
                $log.info(data);
                $scope.builds = data;
            }).
            error(function (data, status, headers, config) {
                handleError(data, status);
            });
            $http.get('/api/deploy').
            success(function (data, status, headers, config) {
                $log.info(data);
                $scope.deployments = data;
            }).
            error(function (data, status, headers, config) {
                handleError(data, status);
            });
        }
    };

    var handleError = function(data, status) {
        $log.error(data);
        $scope.errorMessage = data.Message;

        if (status == 500) {
            $scope.errorMessage += ' ' + data.ExceptionMessage;
        }
    }

});