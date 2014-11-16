'use strict';

angular.module('MyApp', [])
    .controller('MyController', function($scope, $http, $log) {
        $scope.projects = [];
        $scope.selectedProject = {};
        $scope.requestSent = false;
        $scope.builds = {};
        $scope.deployments = {};
        $scope.errorMessage = '';
        $scope.infoMessage = '';
        $scope.deploymentRequest = {};


    $http.get('/api/projects').
            success(function(data, status, headers, config) {
                $log.info(data);
                $scope.projects = data;
            }).
            error(function(data, status, headers, config) {
                $log.info(data);
            });

    $scope.projectChange = function () {

        if ($scope.selectedProject.Id > 0) {
            $scope.deploymentRequest.TfsProjectName = $scope.selectedProject.TfsProjectName;
            $scope.deploymentRequest.DropLocation = '';
            $scope.deploymentRequest.SourceSubFolder = $scope.selectedProject.SourceSubFolder;
            $scope.deploymentRequest.DestinationRootLocation = $scope.selectedProject.DestinationRootLocation;
            $scope.deploymentRequest.DestinationProjectFolder = $scope.selectedProject.DetinationProjectFolder;
            $scope.deploymentRequest.NextVersion = $scope.selectedProject.NextVersion;
            $scope.deploymentRequest.VersionKeyName = $scope.selectedProject.VersionKeyName;

            var url = '/api/tfs?projectName=' + $scope.selectedProject.TfsProjectName + '&branch=' + $scope.selectedProject.Branch + '&size=5';
            $log.info(url);
            $http.get(url).
                success(function(data, status, headers, config) {
                    $log.info(data);
                    $scope.builds = data;
                    $scope.deploymentRequest.DropLocation = data[0].DropLocation;
                }).
                error(function(data, status, headers, config) {
                    handleError(data, status);
                });
            $http.get('/api/deploy').
                success(function(data, status, headers, config) {
                    $log.info(data);
                    $scope.deployments = data;
                }).
                error(function(data, status, headers, config) {
                    handleError(data, status);
                });
        } else {
            $scope.deploymentRequest = {};
        }
    };

        var handleError = function(data, status) {
            $log.error(data);

            var message = data.Message;
            if (status == 500) {
                message += ' ' + data.ExceptionMessage;
            }

            $scope.errorMessage = message;
        }

        $scope.clearErrorMessage = function () {
            $scope.errorMessage = '';
        }

        $scope.clearInfoMessage = function () {
            $scope.infoMessage = '';
        }

    });