$("#btnRight").click(function (e) {
    var selected = $('#SelectedDiag option:selected');
    if (selected.length == 0) {
        e.preventDefault();
    }
    $('#NotSelectedDiag').append($(selected).clone());
    $(selected).remove();
    e.preventDefault();
});

$("#btnLeft").click(function (e) {
    var selected = $('#NotSelectedDiag option:selected');
    if (selected.length == 0) {
        e.preventDefault();
    }
    $('#SelectedDiag').append($(selected).clone());
    $(selected).remove();
    e.preventDefault();
});
//highlight postback előtt
$('#btnSubmit').click(function (e) {
    $('#SelectedDiag option').prop('selected', true);
});