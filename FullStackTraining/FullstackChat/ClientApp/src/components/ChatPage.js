import React, {useEffect, useState} from 'react';
import {createChat, getChats, getMessages, postChat, postMessage} from "./axios-client/AxiosRequests";
import connection from "./web-socket/WebsocketClient";
import MessageParser from "./Parsers/DateParser";
import Message from "./Message";
import Chat from "./Chat";

import {
    Col,
    Container,
    Row,
    InputGroup,
    InputGroupAddon,
    Button,
    Input,
} from 'reactstrap';


const ChatPage = () => {

    const [chats, setChats] = useState([]);
    const [currentChatId, setCurrentChatId] = useState(0);
    const [userData, setUserData] = useState(null);
    const [messages, setMessages] = useState([]);
    const [messageText, setMessageText] = useState("");
    const [chatName, setChatName] = useState("");
    const [flag, setFlag] = useState(true);

    async function Chats(storage) {
        const chats = await getChats(storage);
        setChats(chats);
        return chats;
    }

    async function Messages(storage, chatId) {
        const m = await getMessages(chatId, storage);
        setMessages(m);
        return m;
    }
    
    const configureWS = () => {
        connection.on("NewMessage", (message) => {
            const m = MessageParser(message);
            setMessages([...messages, m]);
        });
        
        setFlag(false);  
    };

    useEffect(() => {        
        const userStorage = JSON
            .parse(localStorage.getItem("FullstackChatuser:https://localhost:5001:FullstackChat"));
        // localStorage.clear();
        setUserData(userStorage);

        Chats(userStorage).then((c) => {
            setCurrentChatId(c[0].chatId || 0);
            Messages(userStorage, c[0].chatId || 0).then();
        });
    }, []);

    const sendMessage = async () => {
        if (flag){
            configureWS();
        }
        
        await postMessage({
            chatId: currentChatId,
            userId: userData.profile.sub,
            userName: userData.profile.name.split('@')[0],
            text: messageText,
            token: userData.access_token
        });

        setMessageText("");
    };

    const changeChat = async (id) => {
        if (id !== currentChatId){
            setCurrentChatId(id);
            await Messages(userData, id);
        }
    }
    
    const createChat = async () => {
        if (chatName !== ""){
            await postChat(chatName, userData.profile.sub, userData.access_token);
            await Chats(userData);
        }
    }

    return (
        <Container>
            <Row className="mt-3">
                <Col>
                    <h2 className="text-center">Simple Chat</h2>
                </Col>
            </Row>
            <hr/>
            <Row>
                <Col className="col-md-4"
                     style={{
                         borderRight: "1px solid lightgrey",
                         display: "flex",
                         flexDirection: "column",
                         alignItems: "center"
                     }}>
                    <Input onChange={(e) => setChatName(e.target.value)} value={chatName}
                           placeholder="Chat Name" className="m-3"/>
                    <Button className="mb-3" color="success" style={{width: "75%"}} onClick={createChat}>
                        New Chat
                    </Button>
                    <div
                        style={{overflowY: "scroll", width: "100%", overflowX: "hidden"}}>
                        {chats.map(c => (
                            <Chat key={c.chatId} chatId={c.chatId} title={c.chatName} switcher={changeChat}/>))}
                    </div>
                </Col>
                <Col className="col-md-8">
                    <Row>
                        <Col className="col-md-12">
                            {messages.map(m => (
                                <Message key={m.id} text={m.text} username={m.userName} date={m.date}/>))}
                        </Col>
                    </Row>
                    <Row>
                        <Col className="col-md-12">
                            <InputGroup>
                                <Input onChange={(e) => setMessageText(e.target.value)} value={messageText}
                                       placeholder="Message"/>
                                <InputGroupAddon addonType="append">
                                    <Button onClick={sendMessage} color="success">Send</Button>
                                </InputGroupAddon>
                            </InputGroup>
                        </Col>
                    </Row>
                </Col>
            </Row>
        </Container>
    );
}

export default ChatPage