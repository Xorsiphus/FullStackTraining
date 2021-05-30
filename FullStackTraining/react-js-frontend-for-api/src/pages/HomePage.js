import React, { useState } from 'react';
import { getStudents } from '../api/apiRequests';
import { Link } from 'react-router-dom';

import {
  Button,
  Container,
  Col,
  Row
} from 'react-bootstrap';

import 'bootstrap/dist/css/bootstrap.min.css';

const HomePage = () => {

  return (
    <Container>
      <Row>
        <Col xs={10}>
          <div className="m-2">
            <h1 className="header">All students:</h1>
          </div>
        </Col>
        <Col xs={2}>
          <div className="m-2">
            <Link to="/Cart" className="btn btn-success">Cart</Link>
          </div>
        </Col>

      </Row>
      <hr />

      <Row>
        <Col xs={10}>
          <h1 className="header">All students:</h1>
        </Col>
        <Col xs={2}>
          {/* <Link to="/Cart" className="btn btn-success mt-2">Cart</Link> */}
          <Button className="btn btn-success mt-2" onClick={getStudents}>Test axios</Button>
        </Col>
      </Row>

    </Container>
  )
};

export default HomePage;
