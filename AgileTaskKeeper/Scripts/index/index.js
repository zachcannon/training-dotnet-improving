﻿window.app = angular.module("agileIndexApp", []);

window.app.controller("agileIndexController", function ($scope, taskFactory, statusFactory) {

    $scope.getPossibleStatuses = function () {
        statusFactory.getStatuses().
            success(function (data, status, headers, config) {
                $scope.possibleStatuses = data;
            })

    };

    $scope.displayAllTasks = function () {
        taskFactory.getTasks().
            success(function (data, status, headers, config) {
                $scope.listOfTasks = data;
            }).
            error(function (data, status, headers, config) {
                noty({ 'text': 'Error retrieving tasks from backend...', 'timeout': '5000' });
            });

    };

    $scope.resetAllFormFields = function () {
        $scope.newFormTitle = "";
        $scope.newFormBody = "";
        $scope.updateFormTitle = "";
        $scope.updateFormBody = "";
        $scope.updateFormStatus = "";
        $scope.deleteFormTitle = "";
    }

    $scope.saveTask = function () {
        taskFactory.saveTask($('#newTaskForm').serialize()).
            success(function (data, status, headers, config) {
                noty({ 'text': 'Task Successfully Added!', 'timeout': '5000' });
                $scope.resetAllFormFields();
                $scope.displayAllTasks();
            }).
            error(function (data, status, headers, config) {
                noty({ 'text': 'Error saving task...', 'timeout': '5000' });
            });
    };

    $scope.updateTask = function () {
        var disabled = $('#updateTaskForm').find(':input:disabled').removeAttr('disabled');

        taskFactory.updateTask($('#updateTaskForm').serialize()).
            success(function (data, status, headers, config) {
                noty({ 'text': 'Task Successfully Updated!', 'timeout': '5000' });
                $scope.resetAllFormFields();
                $scope.displayAllTasks();
            }).
            error(function (data, status, headers, config) {
                noty({ 'text': 'The task was not updated, an error occured...', 'timeout': '5000' });
            });

        disabled.attr('disabled', 'disabled');
    };

    $scope.deleteTask = function () {
        var disabled = $('#deleteTaskForm').find(':input:disabled').removeAttr('disabled');

        taskFactory.deleteTask($('#deleteTaskForm').serialize()).
            success(function (data, status, headers, config) {
                noty({ 'text': 'Task Successfully Removed!', 'timeout': '5000' });
                $scope.resetAllFormFields();
                $scope.displayAllTasks();
            }).
            error(function (data, status, headers, config) {
                noty({ 'text': 'The task was not removed, an error occured...', 'timeout': '5000' });
            });

        disabled.attr('disabled', 'disabled');
    };

    $scope.updateTitleBox = function (task) {
        $scope.updateFormTitle = task.Title;
        $scope.updateFormBody = task.Body;
        $scope.updateFormStatus = $scope.findStatusInSelect(task.MyStatus);
        $scope.deleteFormTitle = task.Title;
    }

    $scope.findStatusInSelect = function (taskId) {
        var i = 0;
        var size = $scope.possibleStatuses.length;

        for (i = 0; i < size; i++) {
            if ($scope.possibleStatuses[i].Value == taskId) {
                return $scope.possibleStatuses[i];
            }
        }
    }

    $scope.translateStatus = function (enumId) {
        var i = 0;
        var size = $scope.possibleStatuses.length;

        for (i = 0; i < size; i++) {
            if ($scope.possibleStatuses[i].Value == enumId) {
                return $scope.possibleStatuses[i].Text;
            }
        }
        return ("Could not translate this enum!!");
    }

    // Run these two methods after page and js load. 
    $scope.getPossibleStatuses();
    $scope.displayAllTasks();
});