window.app.factory('taskFactory',
    function ($http) {
        $http.defaults.headers.post["Content-Type"] = "application/x-www-form-urlencoded";

        return {
            getTasks: function () {
                return $http({
                    method: 'GET',
                    url: '/api/AgileTask',
                    cache: false
                });
            },
            saveTask: function (input) {
                return $http({
                    method: 'POST',
                    url: '/api/AgileTask',
                    data: input
                });
            },
            updateTask: function (input) {
                return $http({
                    method: 'PUT',
                    url: '/api/AgileTask',
                    contentType: 'application/json; charset=utf-8',
                    data: input,
                    dataType: 'json'
                });
            },
            deleteTask: function (input) {
                return $http({
                    method: 'POST',
                    url: '/api/AgileTask/Delete',
                    data: input
                });
            }
        };
    });