$("#addItem").click(function() {
    $.ajax({
        url: this.href,
        cache: false,
        success: function (html) { $("#AddLanguagePair").append(html); }
    });
    return false;
});




$(document).on("click", "a.deleteRow", function () {
    console.log('Deleting..');
    //alert('working');
    $(this).parents("div.AddLanguagePairRow:first").remove();
    return false;
});

