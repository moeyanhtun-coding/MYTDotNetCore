const tblProducts = "product";
const tblCart = "cart";
let productId = null;
getProductTable();
getCartTable()

// for (let i = 0; i < 100; i++) {
//   let no = i + 1;
//   createProduct("Product " + no, "Description " + no, "1500");
// }

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
  // successMessage("Create Message");
  getProductTable();
  getCartTable();
  clearForm();
  successMessage("Creating Successful")
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
  $('#txtName').focus()
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
  successMessage("Updating Successful");
  getProductTable();
  clearForm();
}

function deleteProduct(id) {
  Notiflix.Confirm.show(
    'Confirm',
    'Are you sure want ot delete?',
    'Yes',
    'No',
    function okCb() {
      Notiflix.Loading.dots();
      setTimeout(() => {
        Notiflix.Loading.remove();
        let lst = getProduct();
        let items = lst.filter((x) => x.ProductId !== id);
        lst = items;
        let productStr = JSON.stringify(lst);
        localStorage.setItem(tblProducts, productStr);
        getProductTable();
        successMessage("Deleting Successful");
      }, 1000);
    },)
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
  Notiflix.Report.success(
    'Success',
    message,
    'Okay',
  );
}

function errorMessage(message) {
  Notiflix.Report.failure(
    'Failure',
    message,
    'Okay',
  );
}

$("#btnSave").click(function () {
  const name = $("#txtName").val();
  const description = $("#txtDescription").val();
  const price = $("#txtPrice").val();

  if (productId === null) {
    Notiflix.Loading.dots();
    setTimeout(() => {
      Notiflix.Loading.remove();
      createProduct(name, description, price);
    }, 1000);
  } else {
    Notiflix.Loading.dots();
    setTimeout(() => {
      Notiflix.Loading.remove();
      updateProduct(productId, name, description, price);
    }, 1000);
  }
});

function getProductTable() {
  if ($.fn.DataTable.isDataTable('#datatable')) {
    $('#datatable').DataTable().destroy();
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
                <button class="btn btn-warning" onclick="editProduct('${item.ProductId
      }')">Edit</button>
                <button class="btn btn-danger" onclick="deleteProduct('${item.ProductId
      }')">Delete</button>
            </td>
            <td>
                <button class="btn btn-info" onclick="addToCartProduct('${item.ProductId
      }')"><i class="fa-solid fa-plus"></i></button>  
            </td>
        </tr>
        `;
    htmlRows += htmlRow;
  });
  $("#tBody").html(htmlRows);
  new DataTable('#datatable');
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
  const requestCart = {
    cartId: uuidv4(),
    cartProduct: item.productName,
    cartPrice: item.productPrice,
    cartQuantity: 1
  }
  cartLst.push(requestCart);
  const cartStr = JSON.stringify(cartLst);
  localStorage.setItem(tblCart, cartStr);
  getCartTable();
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
  if ($.fn.DataTable.isDataTable('#cartDataTable')) {
    $('#cartDataTable').DataTable().destroy();
  }

  const lst = getCart();
  let count = 0;
  let htmlRows = "";
  lst.forEach((item) => {
    let htmlRow = `<tr>
      <th>${++count}</th>
      <td>${item.cartProduct}</td>
      <td>${item.cartPrice} MMK</td>
      <td>
        <div class="d-flex">
          <button class="btn btn-warning" onclick="plusCart('${item.cartId}')"><i class="fa-solid fa-plus"></i></button>
          <div style="width:30px; height:30px;" class="text-center d-flex justify-content-center align-items-center">
            ${item.cartQuantity}
          </div>
          <button class="btn btn-danger" onclick="minusCart('${item.cartId}')"><i class="fa-solid fa-minus"></i></button>
        </div>
      </td>
      <td>${item.cartPrice * item.cartQuantity} MMK</td>
      <td>
        <button class="btn btn-danger" onclick="deleteCart('${item.cartId}')"><i class="fa-solid fa-trash"></i></button>
      </td>
    </tr>
    `;
    htmlRows += htmlRow;
  });
  $("#cartTable").html(htmlRows);
  new DataTable('#cartDataTable');
}

function deleteCart(id) {
  Notiflix.Confirm.show(
    'Confirm',
    'Are you sure want ot delete?',
    'Yes',
    'No',
    function okCb() {
      Notiflix.Loading.dots();
      setTimeout(() => {
        Notiflix.Loading.remove();
        let lst = getCart();
        let items = lst.filter(x => x.cartId !== id);
        lst = items;
        const cartStr = JSON.stringify(lst);
        localStorage.setItem(tblCart, cartStr);
        getCartTable();
        successMessage("Deleting Successful")
      }, 1000);
    },)

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