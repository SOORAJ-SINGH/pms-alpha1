///  Adds Click event on the Add button to call action and get the partial Html
///  append in the div

$("#addLanguagePairItem").click(function () {
    $.ajax({
        url: this.href,
        cache: false,
        success: function (html) { $("#AddLanguagePair").append(html); }
    });
    return false;
});


///  Adds Click event on the Delete link to delete the row dynamically
$(document).on("click", "a.deleteRow", function () {
    console.log('Deleting..');
    //alert('working');
    $(this).parents("div.AddLanguagePairRow:first").remove();
    return false;
});

///  Adds Click event on the Add button to call action and get the partial Html
///  append in the div
$("#addVenderSoftwaresItem").click(function () {
    $.ajax({
        url: this.href,
        cache: false,
        success: function (html) { $("#AddVenderSoftwares").append(html); }
    });
    return false;
});

///  Adds Click event on the Delete link to delete the row dynamically
$(document).on("click", "a.deleteRow", function () {
    console.log('Deleting..');
    //alert('working');
    $(this).parents("div.AddVenderSoftwaresRow:first").remove();
    return false;
});


///  Adds Click event on the Add button to call action and get the partial Html
///  append in the div
$("#addVendorServicesItem").click(function () {
    $.ajax({
        url: this.href,
        cache: false,
        success: function (html) { $("#AddVendorServices").append(html); }
    });
    return false;
});

///  Adds Click event on the Delete link to delete the row dynamically
$(document).on("click", "a.deleteRow", function () {
    console.log('Deleting..');
    //alert('working');
    $(this).parents("div.AddVendorServicesRow:first").remove();
    return false;
});