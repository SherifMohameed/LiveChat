var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();



//connection.on("ReceiveMessage", function (message) {
//    console.log("on")
//    var createDiv = document.createElement("div");
//    var message = document.createElement("p");
//    message.innerHTML = $("#userName").val + ":" + message;
//    createDiv.appendChild(message);
//    $("#chat-content").appendChild(createDiv);
//    console.log("created div")
//});


connection.on("ReciveMessage", function (userName,message) {
    //userId = $("#userName").val();

    var li = document.createElement("li");
    document.getElementById("chat-content").appendChild(li);

    li.textContent = `${userName} : ${message}`;
});

connection.start();

$("#sendMess").on("click", function () {
    var userName = $("#userName").val();

    var message = $("#message").val();
    $("#message").val('');
    connection.invoke("SendMessage",userName, message);
});





