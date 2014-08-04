window.app.factory('teamMemberFactory',
    function ($http) {
        return {
            getTeamMembers: function () {
                return $http({
                    method: 'GET',
                    url: '/api/TeamMember',
                    cache: false
                });
            },

            addTeamMember: function (input) {
                return $http({
                    method: 'POST',
                    url: 'api/TeamMember',
                    data: input
                });
            },

            removeTeamMember: function (input) {
                return $http({
                    method: 'POST',
                    url: 'api/TeamMember/Delete?idToRemove=' + input
                });
            }
        };
    });