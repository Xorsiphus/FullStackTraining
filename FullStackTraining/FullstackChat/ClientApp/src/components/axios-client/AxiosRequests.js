import axios from "./AxiosClient";
import MessageParser from "../Parsers/DateParser";


export async function getChats(storage) {
    return await axios
        .get('/ChatsList',
            {
                params: { userId: storage.profile.sub },
                headers: { 'Authorization': `Bearer ${storage.access_token}` }
            })
        .then((res) => res.data);
}

export async function postChat(chatId, userName, token) {
    await axios
        .post('/ChatsList', { ChatId: chatId, UserName: userName },
            {
                headers: { 'Authorization': `Bearer ${token}` }
            });
}

export async function postLink(chatId, userName, token) {
    await axios
        .post('/Linker', { ChatId: chatId, UserName: userName },
            {
                headers: { 'Authorization': `Bearer ${token}` }
            });
}

export async function getMessages(chatId, storage) {
    return await axios
        .get('/Messages',
            {
                params: { userId: storage.profile.sub, chatId: chatId },
                headers: { 'Authorization': `Bearer ${storage.access_token}` }
            })
        .then((res) => res.data.map(m => MessageParser(m)));
}

export async function postMessage( { chatId, userId, userName, text, token } ) {
    await axios
        .post('/Messages', { chatId, userId, userName, text },
            {
                headers: { 'Authorization': `Bearer ${token}` }
            });
}
