'use strict';

angular.module('MyApp', [])
    .controller('MyController', function($scope, $http, $log) {
        $scope.projects = [];
        $scope.selectedProject = {};
        $scope.requestSent = false;
        
        $http.get('/api/projects').
            success(function(data, status, headers, config) {
                $log.info(data);
                $scope.projects = data;
            }).
            error(function(data, status, headers, config) {
                $log.info(data);
            });
    });