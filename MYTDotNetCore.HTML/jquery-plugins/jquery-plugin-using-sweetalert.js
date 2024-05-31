const tblBlog = "blogs";
let blogId = null;
getBlogTable();
//createBlog();
// updateBlog("2d8b6a79-d450-4440-8e10-f1727b7e5c33","moeyan","Moeyan", "Moe yan");
//deleteBlog("dd508422-aefe-4842-ae4c-fca39944d7a6");
// readBlog
function readBlog() {
  let blogs = localStorage.getItem(tblBlog);
  console.log(blogs);
}

// createBlog
function createBlog(title, author, content) {
  let lst = getBlogs();

  const requestModel = {
    id: uuidv4(),
    title: title,
    author: author,
    content: content,
  };

  lst.push(requestModel);
  const blogstr = JSON.stringify(lst);

  localStorage.setItem(tblBlog, blogstr);

  successfulMessage("Saving Successful");
  clearForm();
  getBlogTable();
}

function editBlog(id) {
  let lst = getBlogs();
  const items = lst.filter((x) => x.id === id);
  if (items.length == 0) {
    errorMessage("No Data Found");
    return;
  }
  const item = items[0];
  blogId = item.id;
  $("#txtTitle").val(item.title);
  $("#txtAuthor").val(item.author);
  $("#txtContent").val(item.content);
  $("#txtTitle").focus();
}
//updateBlog
function updateBlog(id, title, author, content) {
  let lst = getBlogs();

  const items = lst.filter((x) => x.id === id);

  if (items.length == 0) {
    errorMessage("No Data Found");
    return;
  }

  const item = items[0];
  item.title = title;
  item.author = author;
  item.content = content;

  const index = lst.findIndex((x) => x.id === id);
  lst[index] = item;

  const blogStr = JSON.stringify(lst);

  localStorage.setItem(tblBlog, blogStr);

  clearForm();
  successfulMessage("Updating Successful.");
}

// deleteBlog
function deleteBlog(id) {
  Swal.fire({
    title: "Are you sure want to delete?",
    text: "You won't be able to revert this!",
    icon: "question",
    showCancelButton: true,
    confirmButtonColor: "#3085d6",
    cancelButtonColor: "#d33",
    confirmButtonText: "Yes"
  }).then((result) => {
    if (result.isConfirmed) {
      let lst = getBlogs();
      const items = lst.filter((x) => x.id !== id);
      const blogStr = JSON.stringify(items);
      localStorage.setItem(tblBlog, blogStr);
      successfulMessage("Deleting Successful")
      getBlogTable()
      // Swal.fire({
      //   title: "Deleted!",
      //   text: "Your file has been deleted.",
      //   icon: "success"
      // });
    }
  });
  // let lst = getBlogs();
  // const items = lst.filter((x) => x.id !== id);
  // const blogStr = JSON.stringify(items);
  // localStorage.setItem(tblBlog, blogStr);
  // successfulMessage("Deleting Successful")
  // getBlogTable()
}

function getBlogs() {
  let blogs = localStorage.getItem(tblBlog);
  let lst = [];
  if (blogs !== null) {
    lst = JSON.parse(blogs);
  }
  return lst;
}

function uuidv4() {
  return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, (c) =>
    (
      +c ^
      (crypto.getRandomValues(new Uint8Array(1))[0] & (15 >> (+c / 4)))
    ).toString(16)
  );
}

$("#btnSave").click(function () {
  const title = $("#txtTitle").val();
  const author = $("#txtAuthor").val();
  const content = $("#txtContent").val();

  if (blogId === null) {
    createBlog(title, author, content);
  } else {
    updateBlog(blogId, title, author, content);
    blogId = null;
  }

  getBlogTable();
});

function successfulMessage(message) {
  Swal.fire({
    title: "Successful !",
    text: message,
    icon: "success"
  });
}

function errorMessage(message) {
  alert(message);
}

function clearForm() {
  $("#txtTitle").val("");
  $("#txtAuthor").val("");
  $("#txtContent").val("");
  $("#txtTitle").focus();
}

function getBlogTable() {
  const lst = getBlogs();
  let count = 0;
  let htmlRows = "";

  lst.forEach((item) => {
    const htmlRow = `        
        <tr>
            <th>${++count}</th>
            <td>${item.title}</td>
            <td>${item.author}</td>
            <td>${item.content}</td>
            <td>
                <button class="btn btn-warning" onclick="editBlog('${item.id
      }')">Edit</button>
                <button class="btn btn-danger" onclick="deleteBlog('${item.id
      }')">Delete</button>
            </td>
        </tr>`;
    htmlRows += htmlRow;
  });

  $("#tbody").html(htmlRows);
}
