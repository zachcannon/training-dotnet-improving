var app = angular.module("agileIndexApp", []);

app.controller("agileIndexController", function ($scope, $http) {
    $http.defaults.headers.post["Content-Type"] = "application/x-www-form-urlencoded";
    $http.defaults.headers.put["Content-Type"] = "application/x-www-form-urlencoded";

    $scope.displayAllTasks = function () {
        $http.get('/api/AgileTask').
            success(function (data) {
                $scope.listOfTasks = data;
            }).
            error(function () {
                noty({ 'text': 'Error retrieving tasks from backend...', 'timeout': '5000' });
            });
    };

    $scope.saveTask = function () {
        $http.post('/api/AgileTask', $('#newTaskForm').serialize()).
            success(function (data) {
                noty({ 'text': 'Task Successfully Added!', 'timeout': '5000' });
                $scope.newFormBody = "";
                $scope.newFormTitle = "";
                $scope.displayAllTasks();
            }).
            error(function () {
                noty({ 'text': 'Error saving task...', 'timeout': '5000' });
            });
    };

    $scope.updateTask = function () {
        var disabled = $('#updateTaskForm').find(':input:disabled').removeAttr('disabled');
        $http.put('/api/AgileTask', $('#updateTaskForm').serialize()).
            success(function (data) {
                if (data == 'pass') {
                    noty({ 'text': 'Task Successfully Updated!', 'timeout': '5000' });
                    $scope.updateFormTitle = "";
                    $scope.updateFormBody = "";
                    $scope.displayAllTasks();
                } else {
                    noty({ 'text': 'The task was not updated, an error occured...', 'timeout': '5000' });
                }
            });

        disabled.attr('disabled', 'disabled');
    };

    $scope.updateTitleBox = function (task) {
        $scope.updateFormTitle = task.Title;
    }


    $('.collapse').collapse();

    $scope.displayAllTasks();
});