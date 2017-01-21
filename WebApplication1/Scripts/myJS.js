$(document).ready(function () {
    document.getElementById('Btm_order').disabled = 'disabled';

    document.getElementById('Start').addEventListener("input", function () {
        myFunction();
    });
    document.getElementById('Finish').addEventListener("input", function () {
        myFunction();
    });
});

function myFunction() {
    var start = $("#Start").val();
    var finish = $("#Finish").val();

    if (start && finish && finish> start) {
        var perDay = $("#car_PricePerDay").val();
        var extra = $("#car_PriceExtra").val();
        var div = $('div_Price');

        var objTo = document.getElementById('div_Price');
        var divtest = document.createElement("div");
        divtest.innerHTML = "Price per day is:" + perDay.split('.')[0] + ' ILS';
        objTo.appendChild(divtest);

        var cd = 24 * 60 * 60 * 1000;
        var time = (new Date(finish) - new Date(start));
        time = time / 1000 / 60 / 60 / 24;

        var objTo = document.getElementById('div_Price');
        var divtest = document.createElement("div");
        divtest.innerHTML = "Extra price per day is:" + extra.split('.')[0] + ' ILS';
        objTo.appendChild(divtest);


        var objTo = document.getElementById('div_Price');
        var divtest = document.createElement("div");
        divtest.innerHTML = "For this order is :" + (perDay.split('.')[0] * time) + ' ILS';

        objTo.appendChild(divtest);
        addAggre(start, finish);

    }

    function addAggre(start, finish) {
        if (start && finish && finish > start) {
            var checkbox = document.createElement('input');
            checkbox.type = "checkbox";
            checkbox.name = "namecheckbox";
            checkbox.value = "value";
            checkbox.id = "checkbox";
            var label = document.createElement('label');
            label.htmlFor = "id";
            label.appendChild(document.createTextNode("I Agree"));

            var objTo = document.getElementById('div_Price');
            objTo.appendChild(checkbox);
            objTo.appendChild(label);
            document.getElementById('checkbox')
                .addEventListener("click",
                    function() {
                        enableBtm();
                    });
        }
    }

    function enableBtm() {
        document.getElementById('Btm_order').disabled = !document.getElementById('Btm_order').disabled;
    }


}


