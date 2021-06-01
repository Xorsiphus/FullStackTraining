import React from 'react';
import connection from "./web-socket/WebsocketClient";

// import {
//     Container,
//     Col,
//     Row
// } from 'reactstrap';

const Chat = ({title}) => {
    
    const selectChat = () => {
        console.log(title);
        connection.invoke("ClientServerMessage", "qwe", "sss" ).catch(function (err) {
            return console.error(err.toString());
        });
    };

    return (
        <div 
            className="mb-3" 
            style={{
                border: "1px solid grey", 
                borderRadius: 25, 
                padding: 10, 
                display: "flex", 
                justifyContent: "center",
            }}
            onClick={selectChat}
        >
            <p>{title}</p>
        </div>
    );
}

export default Chat