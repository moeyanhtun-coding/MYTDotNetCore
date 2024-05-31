const tblProducts = "product";
const tblCart = "cart";
let productId = null;
getProductTable();

function createProduct(name, description, price) {
  const lst = getProduct();
  const requestProduct = {
    ProductId: uuidv4(),
    productName: name,
    productDescription: description,
    productPrice: price,
  };
  lst.push(requestProduct);
  const productStr = JSON.stringify(lst);

  localStorage.setItem(tblProducts, productStr);
  successMessage("Create Message");
  getProductTable();
  clearForm();
}

function editProduct(id) {
  let lst = getProduct();
  const items = lst.filter((item) => item.ProductId === id);
  if (items.length == 0) {
    errorMessage("No Data Found");
  }
  const item = items[0];
  console.log(item);

  productId = item.ProductId;
  $("#txtName").val(item.productName);
  $("#txtDescription").val(item.productDescription);
  $("#txtPrice").val(item.productPrice);
}

function updateProduct(id, name, description, price) {
  let lst = getProduct();
  const items = lst.filter((item) => item.ProductId === id);
  if (items.length === 0) {
    errorMessage("No Data Found");
  }
  const item = items[0];
  (item.productName = name),
    (item.productDescription = description),
    (item.productPrice = price);
  let index = items.findIndex((x) => x.ProductId === id);
  lst[index] = item;

  let productStr = JSON.stringify(lst);
  localStorage.setItem(tblProducts, productStr);
  successMessage("Successful Updated!");
  getProductTable();
  clearForm();
}

function deleteProduct(id) {
  let lst = getProduct();
  let items = lst.filter((x) => x.ProductId !== id);
  lst = items;
  let productStr = JSON.stringify(lst);
  localStorage.setItem(tblProducts, productStr);
  getProductTable();
  successMessage("Deleting Successful");
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
  let products = localStorage.getItem(tblProducts);
  let lst = [];
  if (products !== null) {
    lst = JSON.parse(products);
  }
  return lst;
}

function successMessage(message) {
  alert(message);
}

function errorMessage(message) {
  alert(message);
}

$("#btnSave").click(function () {
  const name = $("#txtName").val();
  const description = $("#txtDescription").val();
  const price = $("#txtPrice").val();

  if (productId === null) {
    createProduct(name, description, price);
  } else {
    updateProduct(productId, name, description, price);
  }
});

function getProductTable() {
  const lst = getProduct();
  let count = 0;
  let htmlRows = "";
  lst.forEach((item) => {
    const htmlRow = `
        <tr>
            <th>${++count}</th>
            <td>${item.productName}</td>
            <td>${item.productDescription}</td>
            <td>${item.productPrice} MMK</td>
            <td>
                <button class="btn btn-warning" onclick="editProduct('${
                  item.ProductId
                }')">Edit</button>
                <button class="btn btn-danger" onclick="deleteProduct('${
                  item.ProductId
                }')">Delete</button>
            </td>
            <td>
                <button class="btn btn-info" onclick="addToCartProduct('${
                  item.ProductId
                }')"><i class="fa-solid fa-plus"></i></button>  
            </td>
        </tr>
        `;
    htmlRows += htmlRow;
  });
  $("#tBody").html(htmlRows);
}

function clearForm() {
  $("#txtName").val("");
  $("#txtDescription").val("");
  $("#txtPrice").val("");
  $("#txtName").focus();
}

function addToCartProduct(id) {
  let cartLst = getCart();
  let lst = getProduct();
  let items = lst.filter((x) => x.ProductId === id);
  let item = items[0];
  cartLst.push(item);
  const cartStr = JSON.stringify(cartLst);
  localStorage.setItem(tblCart, cartStr);
  getCartTable()
}

function getCart() {
  let carts = localStorage.getItem(tblCart);
  let lst = [];
  if (carts !== null) {
    lst = JSON.parse(carts);
  }
  return lst;
}

function getCartTable() {
  const lst = getCart();
  let count = 0;
  let htmlRows = "";
  lst.forEach((item) => {
    let htmlRow = ` <tr>
        <th>${++count}</th>
        <td>${item.productName}</td>
        <td>${item.productPrice}</td>
        <td>
            <button class="btn btn-warning" onclick=""><i class="fa-solid fa-plus"></i></button>
            <button class="btn btn-danger" onclick=""><i class="fa-solid fa-minus"></i></button>
        </td>
        <td>MMK</td>
    </tr>
    `;
    htmlRows += htmlRow;
  });
  $("#cartTable").html(htmlRows);
}
