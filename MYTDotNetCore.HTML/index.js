const tblBlog = "blogs"
updateBlog("d11851c2-6c2a-43b8-a463-7dc781abb057");

function readBlog() {
    let blogs = localStorage.getItem(tblBlog);
    console.log(blogs)
}

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

function updateBlog(id) {
    let blogs = localStorage.getItem(tblBlog);
    let lst = []
    if (blogs !== null) {
        lst = JSON.parse(blogs);
    }

    let items = lst.filter(x => x.id === id);

}

function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
        (+c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> +c / 4).toString(16)
    );
}