import React, {useEffect, useState} from 'react';

import {Col, Container, Row} from 'reactstrap';
import Chat from "./Chat";
import {getChats} from "./axios-client/AxiosRequests";

const ChatPage = (props) => {

    const [chats, setChats] = useState([]);

    useEffect(() => {
        async function getData(storage) {
            return await getChats(storage);
        }
        const userStorage = JSON
            .parse(localStorage.getItem("FullstackChatuser:https://localhost:5001:FullstackChat"));
        getData(userStorage).then(r => setChats(r));
    }, []);

    return (
        <Container className="h-100">
            <Row className="mt-3">
                <Col>
                    <h2 className="text-center">Simple Chat</h2>
                </Col>
            </Row>
            <hr/>
            <Row className="h-100">
                <Col className="col-md-4 h-75" style={{borderRight: "1px solid lightgrey"}}>
                    {chats.map(c => (<Chat key={c.chatId} title={c.chatName}/>))}

                </Col>
                <Col className="col-md-8">
                    <p>Test2</p>
                </Col>
            </Row>
        </Container>
    );
}

export default ChatPage