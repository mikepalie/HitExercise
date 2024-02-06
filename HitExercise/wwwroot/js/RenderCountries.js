$(document).ready(function () {
    var settings = {
        "url": "https://localhost:44327/api/Country",
        "method": "GET",
        "timeout": 0,
    };

    $.ajax(settings).done(function (response) {
        let countries = response.countries;

        for (var cou of countries) {
            let template = `<option value=${cou.countryId}>${cou.name}</option>`
            $("#country").append(template);

        }
    });
});