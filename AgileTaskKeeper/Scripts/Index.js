$(function () {
    $('.collapse').collapse();

    displayAllTasks();

    $("#saveTask").click(function () {
        $.post('/api/AgileTask',
            $('#newTaskForm').serialize(),
            null,
            'json').done(function (data) {
                noty({ 'text': 'Task Successfully Added!', 'timeout': '5000' });
                $('#newTaskForm').trigger("reset");
                displayAllTasks();
            })

    });

    $("#updateTask").click(function () {
        var disabled = $('#updateTaskForm').find(':input:disabled').removeAttr('disabled');
        $.ajax({
            url: '/api/AgileTask',
            type: 'PUT',
            data: $('#updateTaskForm').serialize(),
            success: function (data) {
                if (data == 'pass') {
                    noty({ 'text': 'Task Successfully Updated!', 'timeout': '5000' });
                    $('#updateTaskForm').trigger("reset");
                    displayAllTasks();
                } else {
                    noty({ 'text': 'The task was not updated, an error occured...', 'timeout': '5000' });
                    $('#updateTaskForm').trigger("reset");
                }
            }
        });
        disabled.attr('disabled', 'disabled');
    });

    function formatItem(task) {
        return "Title: <span>" + task.Title + "</span> <br/>Body: " + task.Body;
    };

    function displayAllTasks() {
        $('#allTasks').empty();
        $.getJSON('/api/AgileTask')
            .done(function (data) {
                $.each(data, function (key, item) {
                    $('#allTasks').append("<li class='taskListItem' id='item" + key + "'>" + formatItem(item) + "</li>")
                });
                $("#allTasks li").click(function () {
                    $('#updateTitle').empty();
                    $('#updateTitle').val($('#' + this.id + ' span').text());
                });
            });
    };
});