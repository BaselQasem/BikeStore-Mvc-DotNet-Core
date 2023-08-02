// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//First Table Load
function LoadTable(dataUrl) {

        $("#spinner-div").show();
        $.ajax({
            type: "GET",
            url: dataUrl,
            data: { "PageNumber": 1, "PagesCount": 0, "Sorting": 0 },
            success: function (response) {
                $("#Table").html(response);
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
    /*Paging*/


//Show Add Modal 
function ShowAdd(dataUrl) {

    $.ajax({
        type: "GET",
        url: dataUrl,
        success: function (response) {
            $("#PlaceHolderHere").html(response);
            $("#AddModal").modal('show');
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
function NextPage(dataUrl) {
 
    $("#spinner-div").show();
    $.ajax({
        type: "GET",
        url: dataUrl,
        data: jQuery.param({
            "PageNumber": parseInt($("#pageNume").val()) + 1,
            "PagesCount": parseInt($("#pagesCount").val()), "Sorting": parseInt($("#Sorting").val()), "Filter": $("#search").val()
        }),
        success: function (response) {
            $("#Table").html(response);
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
function PrevPage(dataUrl) {
    $("#spinner-div").show();
    $.ajax({
        type: "GET",
        url: dataUrl,
        data: jQuery.param({
            "PageNumber": parseInt($("#pageNume").val()) - 1, "PagesCount": parseInt($("#pagesCount").val())
            , "Sorting": parseInt($("#Sorting").val()), "Filter": $("#search").val()
        }),
        success: function (response) {
            $("#Table").html(response);
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
function FirstPage(dataUrl) {
    $("#spinner-div").show();
    $.ajax({
        type: "GET",
        url: dataUrl,
        data: jQuery.param({
            "PageNumber": 1, "PagesCount": parseInt($("#pagesCount").val())
            , "Sorting": parseInt($("#Sorting").val()), "Filter": $("#search").val()
        }),
        success: function (response) {
            $("#Table").html(response);
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
function LastPage(dataUrl) {
    $("#spinner-div").show();
    $.ajax({
        type: "GET",
        url: dataUrl,
        data: jQuery.param({
            "PageNumber": parseInt($("#pagesCount").val()), "PageCount": parseInt($("#pagesCount").val())
            , "Sorting": parseInt($("#Sorting").val()), "Filter": $("#search").val()
        }),
        success: function (response) {
            $("#Table").html(response);
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
function RanPage(page, dataUrl) {
   
    $("#spinner-div").show();
    $.ajax({
        type: "GET",
        url: dataUrl,
        data: jQuery.param({
            "PageNumber": page, "PagesCount": parseInt($("#pagesCount").val())
            , "Sorting": parseInt($("#Sorting").val()), "Filter": $("#search").val()
        }),
        success: function (response) {
            $("#Table").html(response);
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
function Asc(dataUrl) {
   
    $("#Sorting").val(0);
    $("#spinner-div").show();
    $.ajax({
        type: "GET",
        url: dataUrl,
        data: jQuery.param({
            "PageNumber": parseInt($("#pageNume").val()), "PagesCount": parseInt($("#pagesCount").val()),
            "Sorting": parseInt($("#Sorting").val())
        }),
        success: function (response) {
            $("#Table").html(response);
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
function Desc(dataUrl) {
    
    $("#Sorting").val(1);
    $("#spinner-div").show();
    $.ajax({
        type: "GET",
        url: dataUrl,
        data: jQuery.param({
            "PageNumber": parseInt($("#pageNume").val()), "PagesCount": parseInt($("#pagesCount").val()),
            "Sorting": parseInt($("#Sorting").val()), "Filter": $("#search").val()
        }),
        success: function (response) {
            $("#Table").html(response);
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
function AlertDeleteData(obj, dataUrl) {
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
                url: dataUrl,
                data: { "id": id },
                success: function (r) {
                    Swal.fire({
                        text: 'Data berhasil dihapus...',
                        icon: 'success'
                    });
                    window.location = dataUrl.split('/')[0];
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
function OpenModal(obj, dataUrl) {
    var ele = $(obj);
    var Id = ele.data("id");

    $.ajax({
        type: "GET",
        url: dataUrl,
        data: { "id": Id },
        success: function (response) {
            $("#PlaceHolderHere").html(response);
            $("#EditModal").modal('show');
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}

//Open Edit Modal For Stock
function OpenStockModal(obj, dataUrl) {
    var ele = $(obj);
    var Id = ele.data("id2");
    var ProductId = ele.data("id2");
    var StoreId = ele.data("id");

    $.ajax({
        type: "GET",
        url: dataUrl,
        data: { "store_id": StoreId, "product_id": ProductId },
        success: function (response) {
            $("#PlaceHolderHere").html(response);
            $("#EditModal").modal('show');
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
function filter(obj, dataUrl) {
    var res = $(obj).val();
    
    $("#spinner-div").show();
    $.ajax({
        type: "GET",
        url: dataUrl,
        data: jQuery.param({
            "PageNumber": 1, "PagesCount": parseInt($("#pagesCount").val()),
            "Sorting": parseInt($("#Sort").val()), "Filter": res
        }),
        success: function (response) {
          
            $("#Table").html(response);
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






