import React from 'react';

// import {
//     Container,
//     Col,
//     Row
// } from 'reactstrap';

const Chat = ({ title, chatId, switcher }) => {
    
    const selectChat = () => {
        switcher(chatId);
    };

    return (
        <div 
            className="m-3" 
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