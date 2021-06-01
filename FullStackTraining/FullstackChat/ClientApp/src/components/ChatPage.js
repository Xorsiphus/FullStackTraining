import React, {useEffect, useState} from 'react';
import Chat from "./Chat";
import {getChats} from "./axios-client/AxiosRequests";

import {
    Col,
    Container,
    Row,
    InputGroup,
    InputGroupAddon,
    Button,
    Input,
} from 'reactstrap';
import Message from "./Message";


const ChatPage = (props) => {

    const [chats, setChats] = useState([]);
    const [userData, setUserData] = useState(null);
    const [messages, setMessages] = useState([]);

    useEffect(() => {
        async function getData(storage) {
            return await getChats(storage);
        }

        const userStorage = JSON
            .parse(localStorage.getItem("FullstackChatuser:https://localhost:5001:FullstackChat"));
        getData(userStorage).then(r => setChats(r));
        setUserData(userStorage);
        // console.log(props);
    }, []);

    return (
        <Container>
            <Row className="mt-3">
                <Col>
                    <h2 className="text-center">Simple Chat</h2>
                </Col>
            </Row>
            <hr/>
            <Row>
                <Col className="col-md-4" style={{borderRight: "1px solid lightgrey"}}>
                    <div style={{height: "90%", overflowY: "scroll", overflowX: "hidden"}}>
                        {chats.map(c => (<Chat key={c.chatId} title={c.chatName}/>))}
                        {chats.map(c => (<Chat key={c.chatId} title={c.chatName}/>))}
                        {chats.map(c => (<Chat key={c.chatId} title={c.chatName}/>))}
                        {chats.map(c => (<Chat key={c.chatId} title={c.chatName}/>))}
                        {chats.map(c => (<Chat key={c.chatId} title={c.chatName}/>))}
                        {chats.map(c => (<Chat key={c.chatId} title={c.chatName}/>))}
                    </div>
                </Col>
                <Col className="col-md-8">
                    <Row>
                        <Col className="col-md-12">
                            {messages.map(m => (<Message key={m.id} text={m.text} username={m.userId}/>))}
                        </Col>
                    </Row>
                    <Row>
                        <Col className="col-md-12">
                            <InputGroup>
                                <Input placeholder="Message" />
                                <InputGroupAddon addonType="append">
                                    <Button color="success">Send</Button>
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