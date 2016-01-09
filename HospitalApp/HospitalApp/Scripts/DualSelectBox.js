$("#btnRight").click(function (e) {
    var selected = $('#SelectedCon option:selected');
    if (selected.length == 0) {
        e.preventDefault();
    }
    $('#NotSelectedCon').append($(selected).clone());
    $(selected).remove();
    e.preventDefault();
});

$("#btnLeft").click(function (e) {
    var selected = $('#NotSelectedCon option:selected');
    if (selected.length == 0) {
        e.preventDefault();
    }
    $('#SelectedCon').append($(selected).clone());
    $(selected).remove();
    e.preventDefault();
});
//highlight postback előtt
$('#btnSubmit').click(function (e) {
    $('#SelectedCon option').prop('selected', true);
});