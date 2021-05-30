import React, { useState } from 'react';
import cart from "../components/Cart";
import Student from '../components/Student';

import {
    Button,
    Container,
    Col,
    Row
} from 'react-bootstrap';

import 'bootstrap/dist/css/bootstrap.min.css';
import { Link } from 'react-router-dom';

const CartPage = () => {

    const [studentsFromCart, setStudentsFromCart] = useState(cart.getState());

    const cartStudentsList = studentsFromCart.map((s) => (
        <Student
            key={s.id}
            student={s}
        />
    ));

    const calculateMisses = () =>
        <>{studentsFromCart.reduce((a, curr) => a + curr.misses, 0)}</>;

    const kickStudents = () => {
        cart.dispatch({type: "Clear"});
        setStudentsFromCart([]);
    };


    return (
        <Container>
            <Row className="mt-1">
                <Col className="col-md-10">
                    <div>
                        <h1 className="header">Cart:</h1>
                    </div>
                </Col>
                <Col className="col-md-2 mt-2">
                    <div>
                        <Link to="/" className="btn btn-danger">Back</Link>
                    </div>
                </Col>

            </Row>
            <hr />
            <Row>
                {cartStudentsList}
            </Row>
            <hr />
            <Row>
                <Col className="col-md-10 mt-2">
                    <p>Общее число пропусков: {calculateMisses()}</p>
                </Col>
                <Col className="col-md-2 mb-3">
                    <Button className="btn btn-dark" onClick={() => kickStudents()}>Исключить</Button>
                </Col>
            </Row>
        </Container>
    )
};

export default CartPage;
