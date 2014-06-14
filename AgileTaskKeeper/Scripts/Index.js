$(document).ready(function () {
    $.getJSON('api/Task')
        .done(function (data) {
            $.each(data, function (key, item) {
                $('<li>', { text: formatItem(item) }).appendTo($('#allTasks'));
            });
        });
});

function formatItem(task) {
    return "Title: " + task.Title + " Body: " + task.Body;
};

function find() {
    var taskTitle = $('#taskTitle').val();
    var uri = "api/task/"+ taskTitle;
    $.getJSON(uri)
        .done(function (data) {
            $('#singleTask').empty();
            $('#singleTask').append(formatItem(data));
        });
};