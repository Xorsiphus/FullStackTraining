import axios from "./axiosClient";

function studentParser(s) {
    return {
        id: s.id,
        lastName: s.lastName,
        firstMidName: s.firstMidName,
        avatar: s.avatar,
        misses: s.misses,
        enrollmentDate: s
            .enrollmentDate
            .substring(0, s.enrollmentDate.indexOf('T')),
    }
}

function onlyUnique(value, index, self) {
    return self.indexOf(value) === index;
}

export async function getStudents() {
    const students = await axios
        .get('/Students')
        .then((res) => res.data);
    return students.map((s) => studentParser(s));
}

export async function getStudentById(id) {
    const student = await axios
        .get('/Students/' + id)
        .then((res) => res.data);
    return studentParser(student);
}

export async function getUniqueCourses() {
    const courses = await axios
        .get('/Courses')
        .then((res) => res.data);
    return courses.map(c => c.title).filter(onlyUnique);
}

export async function getStudentsByCourse(course) {
    const students = axios
        .get(
            '/Students',
            {
                params: { course: course },
            })
        .then((res) => res.data);
    return students;
}


