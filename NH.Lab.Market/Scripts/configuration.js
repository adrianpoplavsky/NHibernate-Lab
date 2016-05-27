function checkSchema() {
    var addProgress = 50;
    $('#generalExceptionMessage').hide();

    $('#overallProgressHeader').addClass("progress-striped active");
    $('#overallProgress').css('width', addProgress + '%').attr('aria-valuenow', addProgress);

    $.getJSON("api/Configuration/CheckSchema")
        .done(function (data) {
            addProgress = 100;

            $('#overallProgress').css('width', addProgress + '%').attr('aria-valuenow', addProgress);
            $('#overallProgressHeader').removeClass("progress-striped active");
        })
        .fail(function (data) {
            addProgress = 100;

            $('#overallProgress').css('width', addProgress + '%').attr('aria-valuenow', addProgress);
            $('#overallProgressHeader').removeClass("progress-striped active");

            $('#spanGeneralError').text(data.statusText + ". " + data.responseText);
            $('#generalExceptionMessage').show();
        });
}


function createSchema() {
    var addProgress = 50;
    $('#generalExceptionMessage').hide();

    $('#overallProgressHeader').addClass("progress-striped active");
    $('#overallProgress').css('width', addProgress + '%').attr('aria-valuenow', addProgress);

    $.getJSON("api/Configuration/CreateSchema")
        .done(function (data) {
            addProgress = 100;

            $('#overallProgress').css('width', addProgress + '%').attr('aria-valuenow', addProgress);
            $('#overallProgressHeader').removeClass("progress-striped active");
        })
        .fail(function (data) {
            addProgress = 100;

            $('#overallProgress').css('width', addProgress + '%').attr('aria-valuenow', addProgress);
            $('#overallProgressHeader').removeClass("progress-striped active");

            $('#spanGeneralError').text(data.statusText + ". " + data.responseText);
            $('#generalExceptionMessage').show();
        });
}
