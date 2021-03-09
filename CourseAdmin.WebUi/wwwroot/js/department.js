 
function deleteConfirmDepartment(deptoId, title) {
    $('#modalDeleteDepto').modal();
    $('#deptoDelete').html(title);
    $('#deptoIdDelete').val(deptoId);
}

$('#btnDeleteDepto').click(() => { //ES6
    const data = {
        deptoId: $('#deptoIdDelete').val(),
    };
     
    $.ajax({
        type: 'POST',
        url: '/Department/Delete',
        dataType: 'json',
        data: data
    }).done(function (result) {
        alert(result.message);
        if (result.success) {
            location.href = '/Department/Index';
        }
    }).fail((jqXHR, textStatus) => {
        console.log("Request failed: " + textStatus);
    });

});

function GetDepartmentInfo(deptoId) {

    const data = {
        id: deptoId
    };

    $.ajax({
        type: 'POST',
        url: '/Department/GetDeparmentInfo',
        dataType: 'json',
        data: data
    }).done(function (result) {
        let data = result.data;       
    }).fail((jqXHR, textStatus) => {
        console.log("Request failed: " + textStatus);
    });
}
