function uuidv4() {
  return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, (c) =>
    (
      +c ^
      (crypto.getRandomValues(new Uint8Array(1))[0] & (15 >> (+c / 4)))
    ).toString(16)
  );
}

function successMessage(message) {
  Notiflix.Report.success("Success", message, "Okay");
}

function errorMessage(message) {
  Notiflix.Report.failure("Failure", message, "Okay");
}

function getCart() {
  let carts = localStorage.getItem(tblCart);
  let lst = [];
  if (carts !== null) {
    lst = JSON.parse(carts);
  }
  return lst;
}

function getProduct() {
  let products = localStorage.getItem(tblProducts);
  let lst = [];
  if (products !== null) {
    lst = JSON.parse(products);
  }
  return lst;
}

function confirmMessage(message) {
  let confirmMessageResult = new Promise(function (success, error) {
    // Notiflix.Confirm.show(
    //   "Confirm",
    //   "Are you sure want ot delete?",
    //   "Yes",
    //   "No"
    // ).then((result) => {
    //   Notiflix.Loading.dots();
    //   setTimeout(() => {
    //     Notiflix.Loading.remove();
    //     if (!result.isConfirmed) return;
    //     let lst = getProduct();
    //     let items = lst.filter((x) => x.productId !== id);
    //     lst = items;
    //     let productStr = JSON.stringify(lst);
    //     localStorage.setItem(tblProducts, productStr);
    //     getProductTable();
    //     success();
    //   }, 1000);
    // });

    //     const swalWithBootstrapButtons = Swal.mixin({
    //       customClass: {
    //         confirmButton: "btn btn-success mx-1",
    //         cancelButton: "btn btn-danger mx-1",
    //       },
    //       buttonsStyling: false,
    //     });
    //     swalWithBootstrapButtons
    //       .fire({
    //         title: message,
    //         icon: "warning",
    //         showCancelButton: true,
    //         confirmButtonText: "Yes",
    //         cancelButtonText: "No",
    //         reverseButtons: true,
    //       })
    //       .then((result) => {
    //         if (result.isConfirmed) {
    //           Notiflix.Loading.dots();
    //           setTimeout(() => {
    //             Notiflix.Loading.remove();
    //             success();
    //           }, 2000);
    //         } else {
    //           error();
    //         }
    //       });
    //   });
    Notiflix.Confirm.show(
      "Notiflix Confirm",
      "Do you agree with me?",
      "Yes",
      "No",
      function okCb() {
        Notiflix.Loading.dots();
        setTimeout(() => {
          Notiflix.Loading.remove();
          success();
        }, 2000);
      },
      function cancelCb() {
        error();
      }
    );
  });
  return confirmMessageResult;
}
