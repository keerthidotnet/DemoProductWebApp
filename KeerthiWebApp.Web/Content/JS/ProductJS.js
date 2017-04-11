//Add
$(document).on("click", "#btnAddNewProduct", function () {
    var selectedRow = $(this).parents('tr:first');
    $("#Add").css("display", "block");
    $("#btnAddNewProduct").attr("disabled", "disabled");
});

//cancel button in add functionality
$(document).on("click", "#btnAddProductCancel", function () {
    $("#btnAddNewProduct").removeAttr("disabled");
    $("#Add").css("display", "none");
});

//saving new product
$(document).on("click", "#btnAddProductSave", function () {
    var product = {
        productName : $("#Add").find("#txtProductName").val(),
    category : $("#Add").find("#txtCategory").val(),
    price : $("#Add").find("#txtPrice").val(),
    isActive : $("#Add").find("#chkIsActive").is(":checked")
};
    if (product.productName == "" || product.category == "" || product.price == "")
    {
        alert("Please enter Product name, category and price");
    }
    else if (isNaN(product.price)) {
        alert("Please enter valid price");
    }
    else
    {
        $.ajax({
            url: '/api/ProductAPI/',
            type: 'POST',
            data: JSON.stringify(product),
            contentType: "application/json;charset=utf-8",
            success: function (data) {
                alert("Product successfully added");
                location.reload();
            },
            error: function (request, message, error) {
                handleException(request, message, error);
            }
        });
    }

});

//Edit
$(document).on("click", "#btnProductEdit", function () {
    var tr = $(this).closest('tr');
    var product = {    
     ProductId : tr.find("#ProductId").val(),
     ProductName : tr.find("#lblProductName").text(),
     Category: tr.find("#lblCategory").text(),
     Price: tr.find("#lblPrice").text(),
     IsActive: tr.find("#lblIsActive").text()
    };

    if (product.ProductId != null) {
        var PId = '<input type="hidden" id="EditProductId" value=' + product.ProductId + ' /><br/>';
    var PName = 'Product Name: <input class="form-control input-sm" id="txtEditProductName" name="txtEditProductName" type="text" value="' + product.ProductName + '" /><br/>';
    var Cat = 'Category: <input class="form-control input-sm" id="txtEditCategory" name="txtEditCategory" type="text" value="' + product.Category + '" /><br/>';
    var price = 'Price: <input class="form-control input-sm" id="txtEditPrice" name="txtEditPrice" type="text" value="' + product.Price + '" /><br/>';
    var isActive = 'Is Active: <input class="form-control input-sm" id="chkEditIsActive" name="chkEditIsActive" type="checkbox" value=""/><br/>';
    var buttons = '<input type="button" id="btnEditProductSave" value="Save" class="btn btn-success btn-xs" /> <input type="button" id="btnEditProductCancel" value="Cancel" class="btn btn-success btn-xs" />';

    var data = PId + PName + Cat + price + isActive + buttons;
    var htmltext = '<tr class="GridCommandRowWithBorder" width="100%" id=tr' + product.ProductId + '><td id=' + product.ProductId + ' colspan=6>' + data + '</td></tr>'
    $(htmltext).insertAfter(tr);
    if (product.IsActive == 'True')
    {
        $("#chkEditIsActive").prop('checked', product.IsActive.toLowerCase());
    }
    $('#tr' + product.ProductId).slideDown("slow");
    $('.edit').toggle();
}
});

//Cancel on edit functionality
$(document).on("click", "#btnEditProductCancel", function () {
    $('.edit').toggle();
    $(this).closest('tr').remove();
});

//saving edited product
$(document).on("click", "#btnEditProductSave", function () {
    var tr = $(this).closest('tr');
    var product = {
        productId: tr.find("#EditProductId").val(),
        productName: tr.find("#txtEditProductName").val(),
        category: tr.find("#txtEditCategory").val(),
        price: tr.find("#txtEditPrice").val(),
        isActive: tr.find("#chkEditIsActive").is(":checked")
    };

    if (product.productName == "" || product.category == "" || product.price == "") {
        alert("Please enter Product name, category and price");
    }
    else if (isNaN(product.price))
    {
        alert("Please enter valid price");
    }
    else {
        $.ajax({
            url: '/api/ProductAPI/',
            type: 'PUT',
            data: JSON.stringify(product),
            contentType: "application/json;charset=utf-8",
            success: function (data) {
                alert("Product successfully updated");
                location.reload();
            },
            error: function (request, message, error) {
                handleException(request, message, error);
            }
        });
    }

});

//delete
$(document).on("click", "#btnProductDelete", function () {
    var tr = $(this).closest('tr');

    var id = $(this).closest('tr').find('#ProductId').val();
    var deleteMsg = confirm("Do you want to delete this record?");
    if (deleteMsg) {
        $.ajax({
            url: '/api/ProductAPI/' + id,
            type: 'DELETE',
            contentType: "application/json;charset=utf-8",
            success: function (data) {
                tr.remove();
            },
            error: function (request, message, error) {
                handleException(request, message, error);
            }
        });
 
        //task for yes
    }
    else {
        //task for no
    }
});

function handleException(request, message,
                         error) {
    var msg = "";
    msg += "Code: " + request.status + "\n";
    msg += "Text: " + request.statusText + "\n";
    if (request.responseJSON != null) {
        msg += "Message" +
            request.responseJSON.Message + "\n";
    }
    alert(msg);
}