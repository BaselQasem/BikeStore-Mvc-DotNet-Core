// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//First Table Load
$(function () {
    $(function () {

        $("#spinner-div").show();
        $.ajax({
            type: "GET",
            url: "/Category/CategoriesList",
            data: { "PageNum": 1, "PageCount": 0, "desc": 0 },
            success: function (response) {
                $("#CategoryTable").html(response);
                $("#spinner-div").hide();
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    });
    /*Paging*/
});

//Show Add Modal 
function ShowAdd() {
    $.ajax({
        type: "GET",
        url: "/Category/Create",
        success: function (response) {
            $("#PlaceHolderHere").html(response);
            $("#AddCategory").modal('show');
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}

//Navigate to Next Page
function NextPage() {
    $("#spinner-div").show();
    $.ajax({
        type: "GET",
        url: "/Category/CategoriesList",
        data: jQuery.param({
            "PageNum": parseInt($("#pageNume").val()) + 1,
            "PageCount": parseInt($("#pagesCount").val()), "desc": parseInt($("#Sort").val())
        }),
        success: function (response) {
            $("#CategoryTable").html(response);
            $("#spinner-div").hide();
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    })
}


//Navigate To Previous Page
function PrevPage() {
    $("#spinner-div").show();
    $.ajax({
        type: "GET",
        url: "/Category/CategoriesList",
        data: jQuery.param({
            "PageNum": parseInt($("#pageNume").val()) - 1, "PageCount": parseInt($("#pagesCount").val())
            , "desc": parseInt($("#Sort").val())
        }),
        success: function (response) {
            $("#CategoryTable").html(response);
            $("#spinner-div").hide();
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    })
}

//Sort Asc
function Asc() {
    $("#Sort").val(0);
    $("#spinner-div").show();
    $.ajax({
        type: "GET",
        url: "/Category/CategoriesList",
        data: jQuery.param({
            "PageNum": parseInt($("#pageNume").val()), "PageCount": parseInt($("#pagesCount").val()),
            "desc": parseInt($("#Sort").val())
        }),
        success: function (response) {
            $("#CategoryTable").html(response);
            $("#spinner-div").hide();
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    })
}


//Sort Desc
function Desc() {
    $("#spinner-div").show();
    $("#Sort").val(1);
    $.ajax({
        type: "GET",
        url: "/Category/CategoriesList",
        data: jQuery.param({
            "PageNum": parseInt($("#pageNume").val()), "PageCount": parseInt($("#pagesCount").val()),
            "desc": parseInt($("#Sort").val())
        }),
        success: function (response) {
            $("#CategoryTable").html(response);
            $("#spinner-div").hide();
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    })
}
//Show Sweet Alert When Delete
function AlertDeleteData(obj) {
    var ele = $(obj);
    var Id = ele.data("id");
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        var id = Id;

        if (result.isConfirmed) {

            $.ajax({
                type: "POST",
                url: "/Category/Delete",
                data: { "id": id },
                success: function (r) {
                    Swal.fire({
                        text: 'Data berhasil dihapus...',
                        icon: 'success'
                    });
                    window.location = "/Category/Index";
                }
            });
            //Swal.fire(
            //    'Deleted!',
            //    'Your file has been deleted.',
            //    'success'
            //)
        }
    });

}
//Open Edit Modal
function OpenModal(obj) {
    var ele = $(obj);
    var Id = ele.data("id");
    $.ajax({
        type: "GET",
        url: "/Category/EDIT",
        data: { "id": Id },
        success: function (response) {
            $("#PlaceHolderHere").html(response);
            $("#AddCategory").modal('show');
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}





