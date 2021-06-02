import React, {Component} from 'react';
import {NotificationContainer, NotificationManager} from 'react-notifications';
import {getChats, getMessages, postChat, postLink, postMessage} from "./axios-client/AxiosRequests";
import hubConnection from "./web-socket/WebsocketClient";
import Message from "./Message";
import Chat from "./Chat";

import {Button, Col, Container, Input, InputGroup, InputGroupAddon, Row,} from 'reactstrap';
import 'react-notifications/lib/notifications.css';
import MessageParser from "./Parsers/MessageParser";


class ChatPage extends Component {

    constructor(props) {
        super(props);

        this.state = {
            addUser: "",
            chats: [],
            chatName: "",
            currentChatId: 0,
            currentChatName: "",
            messages: [],
            messageText: "",
            hubConnection: null,
            userData: JSON
                .parse(localStorage.getItem("FullstackChatuser:https://localhost:5001:FullstackChat")),
        };
    };

    Chats = async () => {
        const chats = await getChats(this.state.userData);
        this.setState({chats});
        return chats;
    };

    Messages = async (chatId) => {
        const messages = await getMessages(chatId, this.state.userData);
        this.setState({messages});
        return messages;
    };

    componentDidMount = () => {
        // localStorage.clear();

        this.setState({ hubConnection }, () => {
            this.state.hubConnection
                .start()
                .then()
                .catch(err => console.log('Error while establishing connection :( ' + err));

            this.state.hubConnection.on('NewMessage', (message) => {
                if (this.state.currentChatId === message.chatId) {
                    console.log(this.state.messages.length, message)
                    const messages = [...this.state.messages, MessageParser(message)];
                    console.log(messages);
                    this.setState({ messages });
                }
            });

            this.state.hubConnection.on("ChatInvite", (userName, chatName, recId) => {
                // const [userName, chatName, recId] = chatNotify.split(";");
                console.log(userName, chatName, recId);
                if (recId === this.state.userData.profile.sub)
                NotificationManager.success(userName + " invited you to " + chatName, 'Chat invite');
                setTimeout(() => this.Chats().then(), 100);
            });
        });

        this.Chats().then((c) => {
            if (c[0] && this.state.currentChatId === 0) {
                this.setState({currentChatId: c[0].chatId, currentChatName: c[0].chatName});
            } else
                return;

            this.Messages(c[0].chatId).then();
        });
    };

    sendMessage = async () => {
        await postMessage({
            chatId: this.state.currentChatId,
            userId: this.state.userData.profile.sub,
            userName: this.state.userData.profile.name.split('@')[0],
            text: this.state.messageText,
            token: this.state.userData.access_token
        });

        this.setState({messageText: ""});
    };

    changeChat = async (id) => {
        if (id !== this.state.currentChatId) {
            this.setState({currentChatId: id, currentChatName: this.state.chats.find(c => c.chatId === id).chatName});
            await this.Messages(id);
        }
    };

    createChat = async () => {
        if (this.state.chatName !== "") {
            await postChat(this.state.chatName, this.state.userData.profile.sub, this.state.userData.access_token);
            await this.Chats();
        }
    };

    addUserRequest = async (chatId, chatName) => {
        await postLink(chatId, chatName, this.state.addUser, this.state.userData.profile.name, this.state.userData.access_token);
        // this.state.hubConnection.invoke("LinkerClient", this.state.addUser, chatName)
        //     .catch(function (err) {
        //     return console.error(err.toString());
        // });        
        this.setState({addUser: ""});
    };

    setAddUser = (input) => {
        this.setState({addUser: input});
    };

    render() {
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
                        <Input onChange={(e) => this.setState({chatName: e.target.value})} value={this.state.chatName}
                               placeholder="Chat Name" className="m-3"/>
                        <Button className="mb-3" color="success" style={{width: "75%"}} onClick={this.createChat}>
                            New Chat
                        </Button>
                        <div
                            style={{overflowY: "scroll", width: "100%", overflowX: "hidden"}}>
                            {this.state.chats.map(c => (
                                <Chat key={c.chatId} func={this.addUserRequest} addUser={this.state.addUser}
                                      setAddUser={this.setAddUser}
                                      chatId={c.chatId}
                                      title={c.chatName} switcher={this.changeChat}/>))}
                        </div>
                    </Col>
                    <Col className="col-md-8">
                        <Row>
                            <h3 className="m-3">{this.state.currentChatName}</h3>
                        </Row>
                        <hr/>
                        <Row>
                            <Col className="col-md-12">
                                {this.state.messages.map(m => (
                                    <Message key={m.id} text={m.text} username={m.userName} date={m.date}/>))}
                            </Col>
                        </Row>
                        <Row>
                            <Col className="col-md-12">
                                <InputGroup>
                                    <Input onChange={(e) => this.setState({messageText: e.target.value})}
                                           value={this.state.messageText}
                                           placeholder="Message"/>
                                    <InputGroupAddon addonType="append">
                                        <Button onClick={this.sendMessage} color="success">Send</Button>
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
}

export default ChatPage