$(function () {
    $('#btnAddNewCourse').click(addNewCourse);
    $('#btnSaveData').click(saveCourse);
});

function addNewCourse() {
    $('#formCourse')[0].reset();
    $('#modalTitle').text('Create New Course');
}
function saveCourse()
{
    if ($('#courseId').val() === undefined || $('#courseId').val() == 0) { // Nuevo Curso //

        var data = {
            title: $('#title').val(),
            credits: $('#credit').val(),
            departmentId: $('#ddlDeptos').val()
        };

        $.ajax({
            type: 'POST',
            dataType: 'json',
            data: data,
            url: '/Course/Create'
        }).done(function (result) {

            alert(result.message);

            if (result.success) {
                window.location.href = '/Course/index';
                $('#courseModal').modal('hide');
            }



        }).fail(function (jqXHR, textStatus) {
            console.log("Request failed: " + textStatus);
        });
    }
    else {

        var data = {
            courseId: $('#courseId').val(),
            title: $('#title').val(),
            credits: $('#credit').val(),
            departmentId: $('#ddlDeptos').val()
        };


        $.ajax({
            type: 'POST',
            dataType: 'json',
            data: data,
            url: '/Course/Modify'
        }).done(function (result) {

            alert(result.message);

            if (result.success) {
                window.location.href = '/Course/index';
                $('#courseModal').modal('hide');
            }

        }).fail(function (jqXHR, textStatus) {
            console.log("Request failed: " + textStatus);
        });
    }

   
}

function getCourseInfo(courseId) {

    $('#courseModal').modal();
    $('#modalTitle').html('Modify Course');

    var data = {
        courseId: courseId
    };

    $.ajax({
        type: 'POST',
        url: '/Course/GetCourseInfo',
        dataType: 'json',
        data: data
    }).done(function (result) {

        if (result.success) {
            $('#courseId').val(result.data.courseId);
            $('#title').val(result.data.title);
            $('#credit').val(result.data.credits);
            $('#ddlDeptos').val(result.data.departmentId);
        }


    }).fail((jqXHR, textStatus) => {
        console.log("Request failed: " + textStatus);
    });

}



