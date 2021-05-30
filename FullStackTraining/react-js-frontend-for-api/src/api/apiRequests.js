import axios from "./axiosClient";

export async function getStudents() {
    const students = await axios.get('/Students').then((res) => res.data);
    console.log(students);
    return students;
}