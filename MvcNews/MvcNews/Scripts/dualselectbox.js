$("#btnRight").click(function (e) {
    var selected = $('#SelectedTags option:selected');
    if (selected.length == 0) {
        e.preventDefault();
    }
    $('#NotSelectedTags').append($(selected).clone());
    $(selected).remove();
    e.preventDefault();
});

$("#btnLeft").click(function (e) {
    var selected = $('#NotSelectedTags option:selected');
    if (selected.length == 0) {
        e.preventDefault();
    }
    $('#SelectedTags').append($(selected).clone());
    $(selected).remove();
    e.preventDefault();
});
$('#btnSubmit').click(function (e) {
    $('#SelectedTags option').prop('selected', true);
});