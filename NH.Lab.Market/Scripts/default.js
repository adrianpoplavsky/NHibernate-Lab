var loadingProgress = 0;
var webservicesAmount = 2;

function getMarkets(ddlMarkets, ddlMarketsForProducts) {

    loadingProgress += 100 / webservicesAmount / 2;

    $('#overallProgressHeader').addClass("progress-striped active");
    $('#overallProgress').css('width', loadingProgress + '%').attr('aria-valuenow', loadingProgress);

    $.getJSON("api/markets")
        .done(function (data) {
            $.each(data, function (index, value) {
                ddlMarkets.append($('<option></option>').val(value.Id).html(value.Name));
                ddlMarketsForProducts.append($('<option></option>').val(value.Id).html(value.Name));
            });

            loadingProgress += 100 / webservicesAmount / 2;

            $('#overallProgress').css('width', loadingProgress + '%').attr('aria-valuenow', loadingProgress);
            $('#overallProgressHeader').removeClass("progress-striped active");
        })
        .fail(function (data) {
            loadingProgress += 100 / webservicesAmount / 2;

            $('#overallProgress').css('width', loadingProgress + '%').attr('aria-valuenow', loadingProgress);
            $('#overallProgressHeader').removeClass("progress-striped active");

            $('#spanGeneralError').text(data.statusText + ". " + data.responseText);
            $('#generalExceptionMessage').show();
        });
}



function getProducts(ddlProducts) {

    loadingProgress += 100 / webservicesAmount / 2;

    $('#overallProgressHeader').addClass("progress-striped active");
    $('#overallProgress').css('width', loadingProgress + '%').attr('aria-valuenow', loadingProgress);

    $.getJSON("api/products")
        .done(function (data) {
            $.each(data, function (index, value) {
                ddlProducts.append(
                    $('<option></option>').val(value.Id).html(value.Name)
                );

            });

            loadingProgress += 100 / webservicesAmount / 2;

            $('#overallProgress').css('width', loadingProgress + '%').attr('aria-valuenow', loadingProgress);
            $('#overallProgressHeader').removeClass("progress-striped active");
        })
        .fail(function (data) {
            loadingProgress += 100 / webservicesAmount / 2;

            $('#overallProgress').css('width', loadingProgress + '%').attr('aria-valuenow', loadingProgress);
            $('#overallProgressHeader').removeClass("progress-striped active");

            $('#spanGeneralError').text(data.statusText + ". " + data.responseText);
            $('#generalExceptionMessage').show();
        });
}

function addProduct() {
    var addProgress = 50;

    $('#overallProgressHeader').addClass("progress-striped active");
    $('#overallProgress').css('width', addProgress + '%').attr('aria-valuenow', addProgress);

    var newProduct = { Name: txtProductName.val(), Market: { Id: ddlMarketForProduct.val() } };

    $.post("api/products", newProduct)
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


function addMarket() {
    var addProgress = 50;

    $('#overallProgressHeader').addClass("progress-striped active");
    $('#overallProgress').css('width', addProgress + '%').attr('aria-valuenow', addProgress);
    
    var newMarket = { Name: txtNombre.val(), Address: txtAddress.val() };

    $.post("api/markets", newMarket)
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

function getByProductName(txtproductName) {
    var addProgress = 50;

    $('#overallProgressHeader').addClass("progress-striped active");
    $('#overallProgress').css('width', addProgress + '%').attr('aria-valuenow', addProgress);

    $.getJSON("api/GetByProductName?txtproductName=" + txtproductName.val())
    .done(function (data) {
        $.each(data, function (index, value) {

            addProgress = 100;

            $('#overallProgress').css('width', addProgress + '%').attr('aria-valuenow', addProgress);

            $('#overallProgressHeader').removeClass("progress-striped active");
        })
    });
}