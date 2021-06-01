import React from 'react';

import {
    Container,
    Col,
    Row
} from 'reactstrap';

const Message = () => {


    return (
        <Container>
            <Row className="mt-3">
                <Col>
                    <h2 className="text-center">Simple Chat</h2>
                </Col>
            </Row>
            <hr/>
            <Row>
                <Col className="col-md-4">
                    <p>Test1</p>
                </Col>
                <Col className="col-md-8">
                    <p>Test2</p>
                </Col>
            </Row>
        </Container>
    );
}

export default Message