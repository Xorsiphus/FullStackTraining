﻿import axios from 'axios';

const axiosClient = axios.create({
    baseURL: 'https://localhost:5001',
});

export default axiosClient;