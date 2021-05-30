import axios from 'axios';
import { Agent } from "https";

const axiosClient = axios.create({
  baseURL: 'https://localhost:5001',
//   httpsAgent: new Agent({rejectUnauthorized: false})
});

export default axiosClient;
