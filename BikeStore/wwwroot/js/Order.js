// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//First Table Load
$(function () {
    $(function () {

        $("#spinner-div").show();
        $.ajax({
            type: "GET",
            url: "/Order/OrdersList",
            data: { "PageNumber": 1, "PageCount": 0, "Sorting": 0 },
            success: function (response) {
                $("#OrderTable").html(response);
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
        url: "/Order/Create",
        success: function (response) {
            $("#PlaceHolderHere").html(response);
            $("#AddOrder").modal('show');
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
        url: "/Order/OrdersList",
        data: jQuery.param({
            "PageNumber": parseInt($("#pageNum").val()) + 1,
            "PageCount": parseInt($("#pagesCount").val()), "Sorting": parseInt($("#Sort").val()), "filter": $("#search").val()
        }),
        success: function (response) {
            $("#OrderTable").html(response);
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
        url: "/Order/OrdersList",
        data: jQuery.param({
            "PageNumber": parseInt($("#pageNum").val()) - 1, "PageCount": parseInt($("#pagesCount").val())
            , "Sorting": parseInt($("#Sort").val()), "filter": $("#search").val()
        }),
        success: function (response) {
            $("#OrderTable").html(response);
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

function FirstPage() {
    $("#spinner-div").show();
    $.ajax({
        type: "GET",
        url: "/Order/OrdersList",
        data: jQuery.param({
            "PageNumber": 1, "PageCount": parseInt($("#pagesCount").val())
            , "sorting": parseInt($("#Sort").val()), "filter": $("#search").val()
        }),
        success: function (response) {
            $("#OrderTable").html(response);
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
function LastPage() {
    $("#spinner-div").show();
    $.ajax({
        type: "GET",
        url: "/Order/OrdersList",
        data: jQuery.param({
            "PageNumber": parseInt($("#pagesCount").val()), "PageCount": parseInt($("#pagesCount").val())
            , "Sorting": parseInt($("#Sort").val()), "filter": $("#search").val()
        }),
        success: function (response) {
            $("#OrderTable").html(response);
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

function RanPage(page) {
    $("#spinner-div").show();
    $.ajax({
        type: "GET",
        url: "/Order/OrdersList",
        data: jQuery.param({
            "PageNumber": page, "PageCount": parseInt($("#pagesCount").val())
            , "Sorting": parseInt($("#Sort").val()), "filter": $("#search").val()
        }),
        success: function (response) {
            $("#OrderTable").html(response);
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
        url: "/Order/OrdersList",
        data: jQuery.param({
            "PageNumber": parseInt($("#pageNum").val()), "PageCount": parseInt($("#pagesCount").val()),
            "Sorting": parseInt($("#Sort").val()), "filter": $("#search").val()
        }),
        success: function (response) {
            $("#OrderTable").html(response);
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
    $("#Sort").val(1);
    $("#spinner-div").show();
    $.ajax({
        type: "GET",
        url: "/Order/OrdersList",
        data: jQuery.param({
            "PageNumber": parseInt($("#pageNum").val()), "PageCount": parseInt($("#pagesCount").val()),
            "Sorting": parseInt($("#Sort").val()), "filter": $("#search").val()
        }),
        success: function (response) {
            $("#OrderTable").html(response);
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
                url: "/Order/Delete",
                data: { "id": id },
                success: function (r) {
                    Swal.fire({
                        text: 'Data berhasil dihapus...',
                        icon: 'success'
                    });
                    window.location = "/Order/Index";
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
        url: "/Order/EDIT",
        data: { "id": Id },
        success: function (response) {
            $("#PlaceHolderHere").html(response);
            $("#AddOrder").modal('show');
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}

//Filter Table
function filter(obj) {

    var res = $(obj).val();

    $("#spinner-div").show();
    $.ajax({
        type: "GET",
        url: "/Order/OrdersList",
        data: jQuery.param({
            "PageNumber": 1, "PageCount": parseInt($("#pagesCount").val()),
            "sorting": parseInt($("#Sort").val()), "filter": res
        }),
        success: function (response) {
            $("#OrderTable").html(response);
            $("#spinner-div").hide();
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}





