import React from 'react';

import {
    Button,
    Row,
    Col,
    Card
} from 'react-bootstrap';


const Student = ({ student, buttonListener }) => {

    return (
        <Card border="dark" text="dark" className="mb-4">
            <Card.Img variant="top" src={student ? student.avatar : ""} />
            <Card.Body>
                <Card.Title>Name: {student.lastName}</Card.Title>
                <Card.Text>
                    FirstMidName: {student.firstMidName}<br />
                    Date: {student.enrollmentDate}
                </Card.Text>
            </Card.Body>
            <Card.Footer>
                <Row>
                    <Col className="col-md-6">
                        <small className="text-muted">Count of misses: {student.misses}</small>
                    </Col>
                    <Col className="col-md-6">
                        {buttonListener ?
                            <Button
                                className="btn btn-warning"
                                style={{}}
                                onClick={() => buttonListener(student)}>
                                Добавить в список
                            </Button>
                            :
                            <></>}
                    </Col>
                </Row>
            </Card.Footer>
        </Card>
    )
};

export default Student;
