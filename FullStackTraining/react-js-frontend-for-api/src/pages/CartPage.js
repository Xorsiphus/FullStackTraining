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
            <Row>
                <Col xs={10}>
                    <div className="mt-2">
                        <h1 className="header">Cart:</h1>
                    </div>
                </Col>
                <Col xs={2}>
                    <div>
                        <Link to="/" className="btn btn-danger mt-3">Back</Link>
                    </div>
                </Col>

            </Row>
            <hr />
            <Row>
                {cartStudentsList}
            </Row>
            <hr />
            <Row>
                <Col xs={10}>
                    <p>Общее число пропусков: {calculateMisses()}</p>
                </Col>
                <Col xs={2}>
                    <Button className="btn btn-dark" onClick={() => kickStudents()}>Исключить</Button>
                </Col>
            </Row>
        </Container>
    )
};

export default CartPage;
