// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function takeName(nameHero) {
    document.getElementById("heroName").innerHTML = nameHero;
}

function takeInfo(itemName, itemGold, itemImage) {
    document.getElementById("ItemName").innerHTML = itemName;
    document.getElementById("ItemGold").innerHTML = itemGold;
    document.getElementById("ItemImage").src = itemImage; 

    document.getElementById("ItemsTitle").style.display = "none";
    document.getElementById("ById").style.display = "block";
}

$(function () {
    $("time").each(function (i, e) {
        const dateTimeValue = $(e).attr("datetime");
        if (!dateTimeValue) {
            return;
        }

        const time = moment.utc(dateTimeValue).local();
        $(e).html(time.format("llll"));
        $(e).attr("title", $(e).attr("datetime"));
    });
});
