$(function () {
    displayAllTasks();

    $("#saveTask").click(function () {
        $.post('api/AgileTask',
            $('#newTaskForm').serialize(),
            null,
            'json').done(function (data) {
                noty({ text: 'Task Successfully Added!' });
                $('#newTaskForm').trigger("reset");
                $('#allTasks').empty();
                displayAllTasks();
            })
                
    })

    function formatItem(task) {
        return "Title: " + task.Title + " Body: " + task.Body;
    };

    function displayAllTasks() {
        $.getJSON('api/AgileTask')
            .done(function (data) {
                $.each(data, function (key, item) {
                    $('#allTasks').append("<li class='taskListItem'>" + formatItem(item) + "</li>")
                });
            });
    };
});