// Makes fields uneditable if inactive
$(document).ready(function () {

    updateFieldStatus();


    $('input[type="radio"]').change(function () {
        updateFieldStatus();
    });

    function updateFieldStatus() {


        var isInactive = $('#inactive').is(':checked');
        $('.disable-on-inactive').attr('readonly', isInactive);
        
    }
});
