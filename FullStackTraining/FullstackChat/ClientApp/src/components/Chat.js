import React from 'react';
import {Button, Input } from "reactstrap";


const Chat = ({ title, chatId, switcher, addUser, setAddUser, func }) => {

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
                alignItems: "center",
                flexDirection: "column"
            }}
            onClick={selectChat}
        >
            <p>{title}</p>
            <Input onChange={(e) => setAddUser(e.target.value)} value={addUser}
                   style={{width: "80%"}}
                   placeholder="User Email" className="m-3"/>
            <Button className="mb-3" color="success" style={{width: "75%"}} onClick={() => func(chatId, title)}>
                Invite User
            </Button>
        </div>
    );
}

export default Chat