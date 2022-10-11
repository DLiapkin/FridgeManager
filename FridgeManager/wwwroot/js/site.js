// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('#process').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget)
    var recipient = button.data('fridge')
    var modal = $(this)
    modal.find('.modal-header').text('Deletion')
    modal.find('.modal-body').text('Do you want to delete the fridge?')
    var originalUrl = modal.find('.modal-footer #ok-delete').attr('href')
    var updatedUrl = originalUrl.substring(0, originalUrl.lastIndexOf('/') + 1) + recipient
    $("#ok-delete").attr('href', updatedUrl)
})

$("#btnAdd").on('click', function () {
    $.ajax({
        async: true,
        data: $('#form').serialize(),
        type: "POST",
        url: '/Fridges/AddFridgeProduct',
        success: function (partialView) {
            console.log("partialView: " + partialView)
            $('#products').html(partialView)
        }
    })
})