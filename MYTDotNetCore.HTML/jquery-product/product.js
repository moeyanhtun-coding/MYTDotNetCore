productId = null;
let tblProducts = "product"
getProductTable()

function createProduct(name, description, price) {

    const lst = getProduct();
    const requestProduct = {
        id: uuidv4(),
        productName: name,
        productDescription: description,
        productPrice: price,
    }
    lst.push(requestProduct);
    const productStr = JSON.stringify(lst);

    localStorage.setItem(tblProducts, productStr);
    successMessage("Create Message");
    getProductTable();
}

function editProduct(id) {
    let lst = getProduct()
    const items = lst.filter(x => x.id = id);
    if (items.length == 0) {
        errorMessage("No Data Found");
    }
    const item = items[0];
    productId = item.id;

    $("#txtName").val(item.productName);
    $("#txtDescription").val(item.productDescription)
    $("#txtPrice").val(item.productPrice)
}

function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, (c) =>
        (
            +c ^
            (crypto.getRandomValues(new Uint8Array(1))[0] & (15 >> (+c / 4)))
        ).toString(16)
    );
}

function getProduct() {
    let products = localStorage.getItem(tblProducts)
    let lst = [];
    if (products !== null) {
        lst = JSON.parse(products);
    }
    return lst;
}

function successMessage(message) {
    alert(message)
}

function errorMessage(message) {
    alert(message)
}

$("#btnSave").click(function () {
    const name = $("#txtName").val();
    const description = $("#txtDescription").val();
    const price = $("#txtPrice").val();

    createProduct(name, description, price);
});

function getProductTable() {
    const lst = getProduct();
    let count = 0;
    let htmlRows = "";
    lst.forEach(item => {
        const htmlRow = `
        <tr>
            <th>${++count}</th>
            <td>${item.productName}</td>
            <td>${item.productDescription}</td>
            <td>${item.productPrice} MMK</td>
            <td>
                <button class="btn btn-warning" onclick="editProduct('${item.id}')">Edit</button>
                <button class="btn btn-danger">Delete</button>
            </td>
        </tr>
        `
        htmlRows += htmlRow;
    });
    $("#tBody").html(htmlRows);
}