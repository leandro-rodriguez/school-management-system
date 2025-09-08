import React from 'react';
import './App.css';
import {BrowserRouter as Router, Route, Routes} from "react-router-dom";
import Home from './pages/Home';
import Students from './pages/Students';
import StudentDetails from './pages/StudentDetails';
import Workers from './pages/Workers';
import WorkerDetails from './pages/WorkerDetails';
import SalaryPaymentControlDetails from "./pages/SalaryPaymentControlDetails";
import Courses from './pages/Courses';
import CourseDetails from './pages/CourseDetails';
import GroupDetails from "./pages/GroupDetails";
import Schedules from './pages/Schedules';
import Income from './pages/Income';
import CoursesPayment from './pages/CoursesPayment';
import SalaryPayment from './pages/SalaryPayment';
import Expenses from './pages/Expenses';
import Debtors from './pages/Debtors'
import Users from './pages/Users';
import BasicMean from './pages/BasicMean';
import Positions from './pages/Positions';
import Classrooms from './pages/Classrooms';
import LoginPage from  './pages/Login';
import Dropdown from  './components/Dropdown/Dropdown';
import StudentsRecycleBin from "./pages/StudentsRecycleBin";

function App() {
    return (
        <Router>
            <Routes>
                <Route path='/' element={<LoginPage/>}/>
                <Route path='/Home' element={<Home/>}/>
                <Route path='/Students' element={<Students/>}/>
                <Route path='/StudentsRecycleBin' element={<StudentsRecycleBin/>}/>
                <Route path='/StudentDetails/:id' element={<StudentDetails/>}/>
                <Route path='/Workers' element={<Workers/>}/>
                <Route path='/WorkerDetails/:id' element={<WorkerDetails/>}/>
                <Route path='/SalaryPaymentControlDetails/:id' element={<SalaryPaymentControlDetails/>}/>
                <Route path='/Courses' element={<Courses />}/>
                <Route path='/CourseDetails/:id' element={<CourseDetails/>}/>
                <Route path='/GroupDetails/:id' element={<GroupDetails/>}/>
                <Route path='/Schedules' element={<Schedules/>}/>
                <Route path='/Income' element={<Income/>}/>
                <Route path='/CoursesPayment' element={<CoursesPayment/>}/>
                <Route path='/SalaryPayment' element={<SalaryPayment/>}/>
                <Route path='/Expenses' element={<Expenses/>}/>
                <Route path='/Debtors' element={<Debtors/>}/>
                <Route path='/Users' element={<Users/>}/>
                <Route path='/Positions' element={<Positions/>}/>
                <Route path='/BasicMean' element={<BasicMean />}/>
                <Route path='/Classrooms' element={<Classrooms/>}/>
                <Route path='/test' element={<Dropdown/>}/>
            </Routes>
        </Router>
    );
}

export default App;