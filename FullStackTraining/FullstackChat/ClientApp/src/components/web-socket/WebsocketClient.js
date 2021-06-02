import * as signalR from "@microsoft/signalr";

const connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

export default connection;
