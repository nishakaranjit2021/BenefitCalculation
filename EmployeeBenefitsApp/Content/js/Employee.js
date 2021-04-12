$(document).ready(function () {
    $('.us-phone').mask('(000) 000-0000');
    btnDependentOnClick();
    bindDependentDetailsDialog();
});

function btnDependentOnClick() {
    $('#btnAddDependent').on('click', function () {
        var $list = $('#divDependentContainer');
        var count = $list.children('.collection-item').length;

        if (count >= 5) {
            alert("The number of dependencies that can be added has been met!");
            return false;
        }

        $.ajax({
            url: 'Employee/AddNewDependentRow',
            type: 'GET',
            data: { currentIndex: count - 1 },
            success: function (result) {
                $list.append(result);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                $list.append('<div class="text-danger">There was an error</div>');
            }
        });
    });
}

function bindDependentDetailsDialog() {
    $('#btnViewDependentDetails').on('click', function () {
        $('#divDependentDetailsDialog').dialog({
            modal: true,
            width: 600,
            height: "auto"
        });
    });
}