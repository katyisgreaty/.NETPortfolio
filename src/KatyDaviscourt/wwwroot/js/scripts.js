$(document).ready(function () {
    $('.project').submit(function (event) {
        event.preventDefault();
        alert("javascript is starting");
        $.ajax({
            type: 'GET',
            dataType: 'json',
            data: $(this).serialize(),
            url: 'Home/GetProjects',
            success: function (projects) {

                for (var i = 0; i < projects.length; i++) {
                    $('#search-result').append('<p>' + projects[i].name + '</p>');
                }

            }
        });
    })

});