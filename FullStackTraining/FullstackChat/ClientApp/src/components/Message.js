import React from 'react';

import {
    Row
} from 'reactstrap';

const Message = ( { username, text, date } ) => {

    return (
        <Row>
            <div
                className="mb-3 ml-3"
                style={{
                    border: "1px solid grey",
                    borderRadius: 25,
                    padding: 10,
                    display: "flex",
                    justifyContent: "center",
                }}
            >
                <p>{date}<br/>{username}: {text}</p>
            </div>
        </Row>
        
    );
}

export default Message