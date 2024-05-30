const tblBlog = "blogs"
createBlog();
// updateBlog("2d8b6a79-d450-4440-8e10-f1727b7e5c33","moeyan","Moeyan", "Moe yan");
deleteBlog("dd508422-aefe-4842-ae4c-fca39944d7a6");
// readBlog
function readBlog() {
    let blogs = localStorage.getItem(tblBlog);
    console.log(blogs)
}

// createBlog
function createBlog() {
    const blogs = localStorage.getItem(tblBlog);
    console.log(blogs)
    let lst = [];
    if (blogs !== null) {
        lst = JSON.parse(blogs);
    }
    const requestModel = {
        id: uuidv4(),
        title: "this is title",
        author: "this is author",
        content: "this is cotent"
    }

    lst.push(requestModel)
    const blogstr = JSON.stringify(lst);

    localStorage.setItem(tblBlog, blogstr);
}

//updateBlog
function updateBlog(id, title, author, content) {
    let blogs = localStorage.getItem(tblBlog);
    let lst = []
    if (blogs !== null) {
        lst = JSON.parse(blogs);
    }

    const items = lst.filter(x => x.id === id);

    if(items.length == 0){
        console.log("No Data Found");
        return;
    }

    const item = items[0];
    item.title = title;
    item.author = author;
    item.content = content;

    const index = lst.findIndex(x=> x.id === id );
    lst[index] =item;

    const blogStr = JSON.stringify(lst);

    localStorage.setItem(tblBlog, blogStr);

}

// deleteBlog
function deleteBlog(id){
    let blogs = localStorage.getItem(tblBlog);
    let lst = []
    if(blogs !== null){
        lst = JSON.parse(blogs);
    }

    const items = lst.filter(x=> x.id !== id);
    const blogStr = JSON.stringify(items);
    localStorage.setItem(tblBlog, blogStr)
}

function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
        (+c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> +c / 4).toString(16)
    );
}