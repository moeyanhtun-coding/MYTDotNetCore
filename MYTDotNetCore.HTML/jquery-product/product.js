const tblProducts = "product";
const tblCart = "cart";
let editProductId = null;
getProductTable();
getCartTable();

// for (let i = 0; i < 100; i++) {
//   let no = i + 1;
//   createProduct("Product " + no, "Description " + no, "1500");
// }

function createProduct(name, description, price) {
  const lst = getProduct();
  const requestProduct = {
    productId: uuidv4(),
    productName: name,
    productDescription: description,
    productPrice: price,
  };
  lst.push(requestProduct);
  const productStr = JSON.stringify(lst);

  localStorage.setItem(tblProducts, productStr);
  // successMessage("Create Message");
  getProductTable();
  getCartTable();
  clearForm();
  successMessage("Creating Successful");
}

function editProduct(id) {
  let lst = getProduct();
  const items = lst.filter((item) => item.productId === id);
  if (items.length == 0) {
    errorMessage("No Data Found");
  }
  const item = items[0];
  console.log(item);

  editProductId = item.productId;
  $("#txtName").val(item.productName);
  $("#txtDescription").val(item.productDescription);
  $("#txtPrice").val(item.productPrice);
  $("#txtName").focus();
}

function updateProduct(id, name, description, price) {
  let lst = getProduct();
  const items = lst.filter((item) => item.productId === id);
  if (items.length === 0) {
    errorMessage("No Data Found");
  }
  const item = items[0];
  (item.productName = name),
    (item.productDescription = description),
    (item.productPrice = price);
  let index = items.findIndex((x) => x.productId === id);
  lst[index] = item;

  let productStr = JSON.stringify(lst);
  localStorage.setItem(tblProducts, productStr);
  successMessage("Updating Successful");
  getProductTable();
  clearForm();
}

function deleteProduct(id) {
  Notiflix.Confirm.show(
    "Confirm",
    "Are you sure want ot delete?",
    "Yes",
    "No",
    function okCb() {
      Notiflix.Loading.dots();
      setTimeout(() => {
        Notiflix.Loading.remove();
        let lst = getProduct();
        let items = lst.filter((x) => x.productId !== id);
        lst = items;
        let productStr = JSON.stringify(lst);
        localStorage.setItem(tblProducts, productStr);
        getProductTable();
        successMessage("Deleting Successful");
      }, 1000);
    }
  );
}

$("#btnSave").click(function () {
  const name = $("#txtName").val();
  const description = $("#txtDescription").val();
  const price = $("#txtPrice").val();

  if (editProductId === null) {
    Notiflix.Loading.dots();
    setTimeout(() => {
      Notiflix.Loading.remove();
      createProduct(name, description, price);
    }, 1000);
  } else {
    Notiflix.Loading.dots();
    setTimeout(() => {
      Notiflix.Loading.remove();
      updateProduct(editProductId, name, description, price);
    }, 1000);
  }
});

function getProductTable() {
  if ($.fn.DataTable.isDataTable("#datatable")) {
    $("#datatable").DataTable().destroy();
  }

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
                  item.productId
                }')">Edit</button>
                <button class="btn btn-danger" onclick="deleteProduct('${
                  item.productId
                }')">Delete</button>
            </td>
            <td>
                <button class="btn btn-info" onclick="addToCartProduct('${
                  item.productId
                }')"><i class="fa-solid fa-plus"></i></button>  
            </td>
        </tr>
        `;
    htmlRows += htmlRow;
  });
  $("#tBody").html(htmlRows);
  new DataTable("#datatable");
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

  let productLst = lst.filter((x) => x.productId === id);
  let product = productLst[0];

  let index = cartLst.findIndex((x) => x.cartProductId === id);
  if (index === -1) {
    const requestCart = {
      cartId: uuidv4(),
      cartProductId: product.productId,
      cartProductName: product.productName,
      cartPrice: product.productPrice,
      cartQuantity: 1,
    };
    cartLst.push(requestCart);
  } else {
    cartLst[index].cartQuantity += 1;
  }

  const cartStr = JSON.stringify(cartLst);
  localStorage.setItem(tblCart, cartStr);

  getCartTable();
}

function getCartTable() {
  if ($.fn.DataTable.isDataTable("#cartDataTable")) {
    $("#cartDataTable").DataTable().destroy();
  }

  const lst = getCart();
  let count = 0;
  let htmlRows = "";
  lst.forEach((item) => {
    let htmlRow = `<tr>
      <th>${++count}</th>
      <td>${item.cartProductName}</td>
      <td>${item.cartPrice} MMK</td>
      <td>
        <div class="d-flex">
          <button class="btn btn-warning" onclick="plusCart('${
            item.cartId
          }')"><i class="fa-solid fa-plus"></i></button>
          <div style="width:30px; height:30px;" class="text-center d-flex justify-content-center align-items-center">
            ${item.cartQuantity}
          </div>
          <button class="btn btn-danger" onclick="minusCart('${
            item.cartId
          }')"><i class="fa-solid fa-minus"></i></button>
        </div>
      </td>
      <td>${item.cartPrice * item.cartQuantity} MMK</td>
      <td>
        <button class="btn btn-danger" onclick="deleteCart('${
          item.cartId
        }')"><i class="fa-solid fa-trash"></i></button>
      </td>
    </tr>
    `;
    htmlRows += htmlRow;
  });
  $("#cartTable").html(htmlRows);
  new DataTable("#cartDataTable");
}

function deleteCart2(id) {
  Notiflix.Confirm.show(
    "Confirm",
    "Are you sure want ot delete?",
    "Yes",
    "No",
    function okCb() {
      Notiflix.Loading.dots();
      setTimeout(() => {
        Notiflix.Loading.remove();
        let lst = getCart();
        let items = lst.filter((x) => x.cartId !== id);
        lst = items;
        const cartStr = JSON.stringify(lst);
        localStorage.setItem(tblCart, cartStr);
        getCartTable();
        successMessage("Deleting Successful");
      }, 1000);
    }
  );
}
function deleteCart(id) {
  confirmMessage("Are you sure want to delete?").then(function () {
    let lst = getCart();
    let items = lst.filter((x) => x.cartId !== id);
    lst = items;
    const cartStr = JSON.stringify(lst);
    localStorage.setItem(tblCart, cartStr);
    successMessage("Deleting Successful");
    getCartTable();
  });
}

function plusCart(id) {
  let cartLst = getCart();
  let index = cartLst.findIndex((x) => x.cartId === id);
  if (index !== null) {
    cartLst[index].cartQuantity += 1;
    const cartStr = JSON.stringify(cartLst);
    localStorage.setItem(tblCart, cartStr);
    getCartTable();
  }
}

function minusCart(id) {
  let cartLst = getCart();
  let index = cartLst.findIndex((x) => x.cartId === id);
  if (index !== null && cartLst[index].cartQuantity > 1) {
    cartLst[index].cartQuantity -= 1;
    const cartStr = JSON.stringify(cartLst);
    localStorage.setItem(tblCart, cartStr);
    getCartTable();
  }
}
