function helloWorld() {
    return "Hello World";
}
console.log("custom js")

tb = document.getElementsByClassName("topbar")[0];
tb_link = tb.getElementsByClassName("link")[0];
var small = document.createElement("small");
small.appendChild(document.createTextNode(versions.swaggerUi.version));
tb_link.appendChild(small);
