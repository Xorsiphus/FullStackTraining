import axios from "./axiosClient";

function studentParser(s){
    return {
        id: s.id,
        lastName: s.lastName,
        firstMidName: s.firstMidName,
        avatar: s.avatar,
        misses: s.misses,
        enrollmentDate: s.enrollmentDate.substring(0, s.enrollmentDate.indexOf('T')),
    }
}

export async function getStudents() {
    const students = await axios.get('/Students').then((res) => res.data);
    return students.map((s) => studentParser(s));
}

export async function getStudentById(id) {
    const student = await axios.get('/Students/' + id).then((res) => res.data);
    console.log(student);
    return studentParser(student);
}