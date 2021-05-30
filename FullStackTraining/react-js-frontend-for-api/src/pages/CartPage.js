import React, { useState } from 'react';

import {
  Button,
  Container,
  Col,
  Row
} from 'react-bootstrap';

import 'bootstrap/dist/css/bootstrap.min.css';
import { Link } from 'react-router-dom';

const HomePage = () => (
  <Container>
    <Row>
      <Col xs={10}>
        <h1 className="header">Cart:</h1>
      </Col>
      <Col xs={2}>
        {/* <Link to="/Cart" className="btn btn-success">Cart</Link> */}
      </Col>
      {/* <Col xs={3}>1</Col> */}
    </Row>

  </Container>
);

export default HomePage;
