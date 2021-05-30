import React from 'react';

import {
    Col,
    Button
} from 'react-bootstrap';


const Student = ({ student, buttonListener }) => {

    return (
        <Col className="col-md-4 mb-5">
            <div style={{ border: "1px solid black", borderRadius: 30, padding: 45 }}>
                <img src={student ? student.avatar : ""} alt="Avatar" />
                <h4>Name: {student.lastName}</h4>
                <p>FirstMidName: {student.firstMidName}</p>
                <p>Count of misses: {student.misses}</p>
                <p>Date: {student.enrollmentDate}</p>
                {buttonListener ?
                    <Button className="btn btn-warning" onClick={() => buttonListener(student)}>Добавить в список</Button>
                    :
                    <></>}
            </div>
        </Col>
    )
};

export default Student;
