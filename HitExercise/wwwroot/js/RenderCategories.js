$(document).ready(function () {
    var settings = {
        "url": "https://localhost:44327/api/Category",
        "method": "GET",
        "timeout": 0,
    };

    $.ajax(settings).done(function (response) {
        let categories = response.categories;

        for (var cat of categories) {
            let template = `<option value=${cat.categoryId}>${cat.name}</option>`
            $("#category").append(template);

        }
    });
});