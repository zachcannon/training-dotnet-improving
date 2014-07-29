window.app.factory('statusFactory',
    function ($http) {
        return {
            getStatuses: function () {
                return $http({
                    method: 'GET',
                    url: '/api/TaskStatus',
                    cache: false
                });
            }
        };
    });