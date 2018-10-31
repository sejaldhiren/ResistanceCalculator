$(document).ready(function () {

    //load select controls' background color on page load
    $("select").each(function () {
        setBackgroundColor($(this));
    });

    //load select control items' background color on page load
    $("select option").each(function () {
        setBackgroundColor($(this));
    });

    //Used to set background color of select control and its items
    function setBackgroundColor(object) {
        var color = "black";

        

        // Set background color of select items 
        if (object.val() != '') {

            object.css('background-color', object.val());

            switch (object.val()) {
                case "black":
                    color = "white";
                    break;
                case "red":
                    color = "white";
                    break;
                case "green":
                    color = "white";
                    break;
                case "brown":
                    color = "white";
                    break;
                case "blue":
                    color = "white";
                    break;
                case "grey":
                    color = "white";
                    break;
                default:

            }
            object.css('color', color);
        }
    }

    
    //triggers whenever a new item is selected from band select controls 
    $("select").change(function () {

        setBackgroundColor($(this));

        var data = JSON.stringify({
            'bandAColor': $('#drpFirstBand').val(),
            'bandBColor': $('#drpSecondBand').val(),
            'bandCColor': $('#drpThirdBand').val(),
            'bandDColor': $('#drpFourthBand').val()
        });

        // this ajax call returns the resistance value and tolerance as ajax JSON response.
        $.ajax({
            type: "POST",
            url: "/Home/GetResistanceValue",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: data,
            success: function (result) {
                //if error
                if (result.error != undefined) {
                    $("#divError").html(result.error);
                }
                else {
                    $("#divError").empty();
                    $("#txtResistance").val(result.resistance);
                    $("#txtTolerance").val($('#drpFourthBand option:selected').text().substr(0, $('#drpFourthBand option:selected').text().indexOf("%") + 1));
                }
            }
        });
    });

})