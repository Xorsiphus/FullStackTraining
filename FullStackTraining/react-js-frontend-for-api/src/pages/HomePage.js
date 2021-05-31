import React, { useState, useEffect } from 'react';
import AsyncSelect from 'react-select/async';
import { Link } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';
import Student from '../components/Student';
import {
  getStudents,
  getUniqueCourses,
  getStudentsByCourse
} from '../api/apiRequests';
import cart from "../components/Cart";

import {
  Container,
  CardColumns,
  Col,
  Row
} from 'react-bootstrap';


const HomePage = () => {

  const [students, setStudents] = useState([]);

  useEffect(() => {
    async function getData() {
      const s = await getStudents();
      setStudents(s);
    };
    getData();
  }, []);

  const addStudentToCart = async (student) => {
    await cart.dispatch(
      {
        type: "Add",
        student:
        {
          ...student,
          id: cart.getState().length
        }
      });
  }

  const studentsList = students.map((s) => (
    <Student
      key={s.id}
      student={s}
      buttonListener={addStudentToCart}
    />
  ));

  const coursesDropdownList = (inputValue, callback) => {
    async function getData() {
      const courses = await getUniqueCourses();
      var options = courses.map(c => ({ value: c.id, label: c.title + " - " + c.id }));
      callback(options);
    };
    getData();
  };

  const selectSubscribe = async (props) => {
    const s = await getStudents();
    if (props) {
      const newStudents = await getStudentsByCourse(props.value);
      setStudents(newStudents);
    }
    else {
      setStudents(s);
    }
  };

  return (
    <Container>
      <Row className="mt-3">
        <Col xs={4} >
          <div>
            <h1 className="header">All students:</h1>
          </div>
        </Col>
        <Col xs={3}>
          <AsyncSelect
            isClearable={true}
            cacheOptions
            defaultOptions
            loadOptions={coursesDropdownList}
            onChange={selectSubscribe}
          />
        </Col>
        <Col xs={3} />
        <Col xs={2}>
          <div>
            <Link to="/Cart" className="btn btn-success mt-1">Cart</Link>
          </div>
        </Col>
      </Row>
      <hr />
      <CardColumns>
        {studentsList}
      </CardColumns>
    </Container>
  )
};

export default HomePage;
