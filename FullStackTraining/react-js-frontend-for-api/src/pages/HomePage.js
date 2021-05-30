import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';
import Student from '../components/Student';
import { getStudents } from '../api/apiRequests';
import cart from "../components/Cart";

import {
  Container,
  Col,
  Row
} from 'react-bootstrap';


const HomePage = () => {

  const [students, setStudents] = useState([]);

  useEffect(() => {
    async function getData() {
      const s = await getStudents();
      console.log(s);
      setStudents(s);
    }
    getData();
  }, []);

  const addStudentToCart = (student) => {
    cart.dispatch({type: "Add", student});
  }

  const studentsList = students.map((s) => (
    <Student
      key={s.id}
      student={s}
      buttonListener={addStudentToCart}
    />
  ));

  return (
    <Container>
      <Row>
        <Col xs={10}>
          <div className="mt-3">
            <h1 className="header">All students:</h1>
          </div>
        </Col>
        <Col xs={2}>
          <div className="mt-2">
            <Link to="/Cart" className="btn btn-success mt-3">Cart</Link>
          </div>
        </Col>

      </Row>
      <hr />
      <Row>
        {studentsList}
      </Row>

    </Container>
  )
};

export default HomePage;
