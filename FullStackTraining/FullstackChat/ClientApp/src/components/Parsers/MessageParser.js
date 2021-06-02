function MessageParser(message) {
    return {
        id: message.id,
        chatId: message.chatId,
        text: message.text,
        userId: message.userId,
        userName: message.userName,
        date: message
            .date
            .replace('T', '; ').split('.')[0],
    }
}

export default MessageParser;