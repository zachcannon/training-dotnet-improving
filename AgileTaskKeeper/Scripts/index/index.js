window.app = angular.module("agileIndexApp", []);

window.app.controller("agileIndexController", function ($scope, taskFactory, statusFactory, teamMemberFactory) {

    //--------------------------- STATUS SECTION ---------------------------
    $scope.getPossibleStatuses = function () {
        statusFactory.getStatuses().
            success(function (data, status, headers, config) {
                $scope.possibleStatuses = data;
            })
    };

    $scope.getPossibleStatuses();
    //--------------------------- END STATUS SECTION ---------------------------

    //--------------------------- TASK SECTION ---------------------------
    $scope.displayAllTasks = function () {
        taskFactory.getTasks().
            success(function (data, status, headers, config) {
                $scope.listOfTasks = data;
            }).
            error(function (data, status, headers, config) {
                noty({ 'text': 'Error retrieving tasks from backend...', 'timeout': '5000' });
            });
    };

    $scope.saveTask = function () {
        taskFactory.saveTask($('#newTaskForm').serialize()).
            success(function (data, status, headers, config) {
                noty({ 'text': 'Task Successfully Added!', 'timeout': '5000' });
                $scope.asyncPageRefresh();
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
                $scope.asyncPageRefresh();
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
                $scope.asyncPageRefresh();
            }).
            error(function (data, status, headers, config) {
                noty({ 'text': 'The task was not removed, an error occured...', 'timeout': '5000' });
            });

        disabled.attr('disabled', 'disabled');
    };

    $scope.updateUpdateBox = function (task) {
        $scope.taskFormId = task.AgileTaskId;
        $scope.taskFormTitle = task.Title;
        $scope.taskFormBody = task.Body;
        $scope.taskFormStatus = $scope.findStatusInSelect(task.MyStatus);
        $scope.taskFormOwnerId = $scope.findOwnerInSelect(task.TeamMember);
    };

    $scope.findOwnerInSelect = function (taskOwner) {
        if (taskOwner == null) {
            return "";
        }

        var i = 0;
        var size = $scope.listOfTeamMembers.length;

        for (i = 0; i < size; i++) {
            if ($scope.listOfTeamMembers[i].TeamMemberId == taskOwner.TeamMemberId) {
                return $scope.listOfTeamMembers[i];
            }
        }
    };

    $scope.findStatusInSelect = function (taskId) {
        var i = 0;
        var size = $scope.possibleStatuses.length;

        for (i = 0; i < size; i++) {
            if ($scope.possibleStatuses[i].Value == taskId) {
                return $scope.possibleStatuses[i];
            }
        }
    };

    $scope.translateStatus = function (enumId) {
        var i = 0;
        var size = $scope.possibleStatuses.length;

        for (i = 0; i < size; i++) {
            if ($scope.possibleStatuses[i].Value == enumId) {
                return $scope.possibleStatuses[i].Text;
            }
        }
        return ("Could not translate this enum!!");
    };

    $scope.extractTeamMembers = function (teamMember) {
        var memberList = teamMember[0][0];

        var returnList = "";

        var i;
        for (i = 0; i < memberList.length; i++) {
            if (i > 0)
                returnList += ", ";
            returnList += memberList[i].Name;
        }

        return returnList;
    };
    //--------------------------- END TASK SECTION ---------------------------

    //--------------------------- TEAM MEMBER SECTION ---------------------------   
    $scope.getListOfTeamMembers = function () {
        teamMemberFactory.getTeamMembers().
            success(function (data) {
                $scope.listOfTeamMembers = data;
            })
    };

    $scope.addTeamMember = function () {
        teamMemberFactory.addTeamMember($('#newTeamMemberForm').serialize()).
            success(function (data, status, headers, config) {
                noty({ 'text': 'Team Member Successfully Added!', 'timeout': '5000' });
                $scope.asyncPageRefresh();
                $scope.newMemberName = "";
            }).
            error(function (data, status, headers, config) {
                noty({ 'text': 'Error adding team member...', 'timeout': '5000' });
            });
    };

    $scope.removeTeamMember = function (teamMemberToRemove) {
        teamMemberFactory.removeTeamMember(teamMemberToRemove).
            success(function (data, status, headers, config) {
                noty({ 'text': 'Team Member Successfully Removed!', 'timeout': '5000' });
                $scope.asyncPageRefresh();
            }).
            error(function (data, status, headers, config) {
                noty({ 'text': 'Error removing team member...', 'timeout': '5000' });
            });
    };

    $scope.extractTaskList = function (teamMemberToExtract) {
        var teamMember = teamMemberToExtract[0][0];
        var taskList = teamMember.AgileTasks;
        var returnList = "";
        
        var i;
        for (i = 0; i < taskList.length; i++) {
            if (i > 0)
                returnList += ", ";
            returnList += taskList[i].Title;
        }

        return returnList;
    };
    //--------------------------- END TEAM MEMBER SECTION ---------------------------   

    //--------------------------- GENERAL FUNCTIONALITY SECTION ---------------------------
    $scope.resetAllFormFields = function () {
        $scope.newFormTitle = "";
        $scope.newFormBody = "";
        $scope.taskFormTitle = "";
        $scope.taskFormBody = "";
        $scope.taskFormStatus = "";
        $scope.taskFormOwnerId = "";
        $scope.taskFormId = "";
    };

    $scope.asyncPageRefresh = function () {
        $scope.getListOfTeamMembers();
        $scope.displayAllTasks();
        $scope.resetAllFormFields();
    };

    $scope.asyncPageRefresh();
});