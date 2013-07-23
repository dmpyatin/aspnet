

function translateStr(string, cultureId, spaceName) {
    $.ajax({
        url: "Translation/GetJsonTranslation",
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify({
            cultureId: cultureId,
            spaceName: spaceName,
            str: string
        }),
        success: function (responseText, textStatus, XMLHttpRequest) {
            

        },
        error: function (jqXHR, exception) {
            alert('Error translate');
        }
    });
}

function translatePage(cultureId, spaceName) {
    /*console.log("Ok ok! ");
    var Q = $("[data-i18n]");
    console.log(Q);

    var names = [];
    for (var i = 0; i < Q.length; ++i)
        names.push(Q[i].getAttribute("data-i18n"));*/

    $.ajax({
        url: "Translation/GetJsonTranslation",
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify({
            cultureId: cultureId,
            spaceName: spaceName
            //elementNames: names
        }),
        success: function (responseText, textStatus, XMLHttpRequest) {
            var store = $.parseJSON(responseText);

            $.i18n.init({
                resStore: store,
                useDataAttrOptions: true
            });

            $("html").i18n();

        },
        error: function (jqXHR, exception) {
            alert('Error translate');
        }
    });
}

