import React, {useEffect, useState} from 'react';
import {NotificationContainer} from 'react-notifications';
import {getChats, getMessages, postChat, postLink, postMessage} from "./axios-client/AxiosRequests";
import connection from "./web-socket/WebsocketClient";
import Message from "./Message";
import Chat from "./Chat";

import {Button, Col, Container, Input, InputGroup, InputGroupAddon, Row,} from 'reactstrap';
import 'react-notifications/lib/notifications.css';


const ChatPage = () => {

    const [chats, setChats] = useState([]);
    const [currentChatId, setCurrentChatId] = useState(0);
    const [currentChatName, setCurrentChatName] = useState("");
    const [userData, setUserData] = useState(null);
    const [messages, setMessages] = useState([]);
    const [messageText, setMessageText] = useState("");
    const [chatName, setChatName] = useState("");
    const [flag, setFlag] = useState(true);
    const [addUser, setAddUser] = useState("");

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
    
    const getMes = () => messages;

    const updateMessages = (newMess, getter = getMes()) => {
        console.log(newMess.chatId, currentChatId);
        if (newMess.chatId === currentChatId) {
            const mm = [...getter, newMess];
            setMessages(mm);
        }
    }

    const configureWS = () => {        
        connection.on("NewMessage", updateMessages);

        connection.on("ChatInvite", (chatNotify) => {
            const [lUserName, lChatName] = chatNotify.split(";");
            console.log(lUserName, lChatName);
            // NotificationManager.success(userName, " invited you to ", chatName, 'Chat invite');
            setTimeout(() => Chats(userData).then(), 1000);
        });

        connection.start().then().catch((err) => {
            return console.error(err.toString());
        });

        setFlag(false);
    };  

    useEffect(() => {        
        const userStorage = JSON
            .parse(localStorage.getItem("FullstackChatuser:https://localhost:5001:FullstackChat"));
        // localStorage.clear();
        setUserData(userStorage);

        Chats(userStorage).then((c) => {
            if (c[0] && currentChatId === 0) {
                setCurrentChatId(c[0].chatId);
                setCurrentChatName(c[0].chatName);
            } else
                return;

            Messages(userStorage, c[0].chatId).then();
        });
    }, []);

    const sendMessage = async () => {
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
        if (flag) {
            configureWS();
        }
        
        if (id !== currentChatId) {
            await setCurrentChatId(id);
            await setCurrentChatName(chats.find(c => c.chatId === id).chatName);
            await Messages(userData, id);
        }
    }

    const createChat = async () => {        
        if (chatName !== "") {
            await postChat(chatName, userData.profile.sub, userData.access_token);
            await Chats(userData);
        }
    }

    const addUserRequest = async (chatId, chatName) => {
        await postLink(chatId, chatName, addUser, userData.profile.name, userData.access_token);
        setAddUser("");
    };

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
                            <Chat key={c.chatId} func={addUserRequest} addUser={addUser} setAddUser={setAddUser}
                                  chatId={c.chatId}
                                  title={c.chatName} switcher={changeChat}/>))}
                    </div>
                </Col>
                <Col className="col-md-8">
                    <Row>
                        <h3 className="m-3">{currentChatName}</h3>
                    </Row>
                    <hr/>
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

            <NotificationContainer/>
        </Container>
    );
}

export default ChatPage