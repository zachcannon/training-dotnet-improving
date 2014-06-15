$(document).ready(function () {
    $.getJSON('api/AgileTask')
        .done(function (data) {
            $.each(data, function (key, item) {
                //$('<li>', { text: formatItem(item) }).appendTo($('#allTasks'));
                $('#allTasks').append("<li class='taskListItem'>"+formatItem(item)+"</li>")
            });
        });

    $("#saveTask").click(function () {
        $.post('api/AgileTask',
            $('#newTaskForm').serialize(),
            null,
            'json').done(function (data) {
                alert("Task Successfully Added!");
                $('#allTasks').empty();
                displayAllTasks();
            })
                
    })
});

function formatItem(task) {
    return "Title: " + task.Title + " Body: " + task.Body;
};

function displayAllTasks() {
    $.getJSON('api/AgileTask')
        .done(function (data) {
            $.each(data, function (key, item) {
                $('<li>', { text: formatItem(item) }).appendTo($('#allTasks'));
            });
        });
};