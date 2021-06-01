import socket from './WebsocketClient';

socket.onopen = () => {
    console.log("Connected");
};

socket.onclose = (event) => {
    if (event.wasClean) {
        console.log('Соединение закрыто чисто');
    } else {
        console.log('Обрыв соединения'); // например, "убит" процесс сервера
    }
    console.log('Код: ' + event.code + ' причина: ' + event.reason);
};

socket.onmessage = (event) => {
    console.log("Получены данные " + event.data);
};

socket.onerror = (error) => {
    console.log("Ошибка " + error.message);
};
