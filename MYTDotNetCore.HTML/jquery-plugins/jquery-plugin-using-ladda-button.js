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
  getBlogTable();
}

// deleteBlog
function deleteBlog(id) {
  Notiflix.Confirm.show(
    "Notiflix Confirm",
    "Are you sure want to delete?",
    "Yes",
    "No",
    function okCb() {
      Notiflix.Loading.dots();
      setTimeout(() => {
        Notiflix.Loading.remove();
        let lst = getBlogs();
        const items = lst.filter((x) => x.id !== id);
        const blogStr = JSON.stringify(items);
        localStorage.setItem(tblBlog, blogStr);
        successfulMessage("Deleting Successful");
        getBlogTable();
      }, 2000);
    }
  );
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

$("#btnSave").click(function (e) {
  e.preventDefault();
  var l = Ladda.create(this);
  l.start();
  const title = $("#txtTitle").val();
  const author = $("#txtAuthor").val();
  const content = $("#txtContent").val();

  if (blogId === null) {
    setTimeout(() => {
      createBlog(title, author, content);
      successfulMessage("Saving Successful");
      l.stop();
    }, 1000);
  } else {
    setTimeout(() => {
      updateBlog(blogId, title, author, content);
      successfulMessage("Saving Successful");
      blogId = null;
      l.stop();
    }, 1000);
  }

  getBlogTable();
});

function successfulMessage(message) {
  Notiflix.Report.success("Success", message, "Okay");
  // Notiflix.Notify.success(message);
}

function errorMessage(message) {
  // Notiflix.Notify.failure(message);
  Notiflix.Report.failure("Failure", message, "Okay");
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
                <button class="btn btn-warning" onclick="editBlog('${
                  item.id
                }')">Edit</button>
                <button class="btn btn-danger" onclick="deleteBlog('${
                  item.id
                }')">Delete</button>
            </td>
        </tr>`;
    htmlRows += htmlRow;
  });

  $("#tbody").html(htmlRows);
}
