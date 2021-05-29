const axios = require('axios');
const https = require("https");

var config = {
    url: 'https://google.com', // https://localhost:5001/Students
}

// At request level
const agent = new https.Agent({
    rejectUnauthorized: false
});
axios.get('https://localhost:5001/Students', { httpsAgent: agent }).then((res) => console.log(res.data));

// axios.request(config).then((res) => console.log(res)).catch(err => console.log(err))
