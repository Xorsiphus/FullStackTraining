// import { get } from 'axios';
// import { Agent } from "https";

const axios = require("axios");

var config = {
    url: 'http://localhost:5000/Students', // https://localhost:5001/Students
}

// At request level
// const agent = new Agent({
//     rejectUnauthorized: false
// });
// get('http://localhost:5000/Students', { httpsAgent: agent }).then((res) => console.log(res.data));

axios.request(config).then((res) => console.log(res)).catch(err => console.log(err))
