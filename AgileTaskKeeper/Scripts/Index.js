$(function () {
    displayAllTasks();

    $("#saveTask").click(function () {
        $.post('/api/AgileTask',
            $('#newTaskForm').serialize(),
            null,
            'json').done(function (data) {
                noty({ text: 'Task Successfully Added!' });
                $('#newTaskForm').trigger("reset");
                displayAllTasks();
            })
                
    })

    $("#updateTask").click(function () {
        $.ajax({
            url: '/api/AgileTask',
            type: 'PUT',
            data: $('#updateTaskForm').serialize(),
            success: function (data) {
                if (data == 'pass') {
                    noty({ text: 'Task Successfully Updated!' });
                    $('#updateTaskForm').trigger("reset");
                    displayAllTasks();
                } else {
                    noty({ text: 'The task was not updated, an error occured...' });
                    $('#updateTaskForm').trigger("reset");
                }
                
            }
        });

    })

    function formatItem(task) {
        return "Title: " + task.Title + " <br/>Body: " + task.Body;
    };

    function displayAllTasks() {
        $('#allTasks').empty();
        $.getJSON('/api/AgileTask')
            .done(function (data) {
                $.each(data, function (key, item) {
                    $('#allTasks').append("<li class='taskListItem'>" + formatItem(item) + "</li>")
                });
            });
    };
});