$(document).ready(function () {
    $('.delete-btn').click(function () {
        var id = $(this).data('id');
        var name = $(this).data('name');

        $('.deleteId').val(id);
        $('#supname').html(name);

    });
});