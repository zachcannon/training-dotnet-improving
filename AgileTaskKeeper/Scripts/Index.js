$(document).ready(function () {
    displayAllTasks();

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

function find() {
    var taskTitle = $('#taskTitle').val();
    var uri = "api/AgileTask/"+ taskTitle;
    $.getJSON(uri)
        .done(function (data) {
            $('#singleTask').empty();
            $('#singleTask').append(formatItem(data));
        });
};