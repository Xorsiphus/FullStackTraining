import React from 'react';

// import {
//     Container,
//     Col,
//     Row
// } from 'reactstrap';

const Chat = ({title}) => {
    
    const selectChat = () => {
        console.log(title);
    };

    return (
        <div 
            className="mb-3" 
            style={{border: "1px solid grey", borderRadius: 20, padding: 15}}
            onClick={selectChat}
        >
            <font color="black">{title}</font>
        </div>
    );
}

export default Chat