import * as signalR from "@microsoft/signalr";

const connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

connection.start().then().catch((err) => {
    return console.error(err.toString());
});

connection.on("ServerClientMessage", (user, text) => {
    console.log(user, text);
});

export default connection;
