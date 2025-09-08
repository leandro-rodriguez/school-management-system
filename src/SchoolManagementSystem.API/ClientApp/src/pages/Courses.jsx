import React from "react";
import NavBar from "../components/NavBar/NavBar";
import CRUD_Table from "../components/Table/CRUD_Table";
import Login from "../components/Login/Login";
import {useState} from 'react';
import axios from "axios";
import jwt_decode from "jwt-decode";
import { useEffect } from "react";

const Courses = () => {

    const [loggedIn] = useState(()=>{
        if (localStorage['token'] == null)
            return false;

        let respOk = true;

        const JWT = JSON.parse(localStorage['token']);

        axios.get("http://localhost:5145/api/Authenticate/loggedIn", 
                    { headers: { "Authorization": `Bearer ${JWT.token}` } })
                .catch((err) => {
                respOk = false;
                console.log(err.response);
            });

        return respOk;
    });

    const [isSecretary, setIsSecretary] = useState(false);

    useEffect(()=>{
        if (localStorage['token'] == null)
            return false;

        var decoded = jwt_decode(localStorage['token']);
            
        const roles = decoded['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];

        for (let i = 0; i < roles.length; i++) {
            console.log(roles[i]);

            if (roles[i] === 'Secretary')
                setIsSecretary(true);
        }
    },[]);

         
    if (!loggedIn)
        window.location.replace("http://localhost:8080/");

    const columns = [
        {
            title: 'Nombre',
            dataIndex: 'name',
            width: '15%',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.name.localeCompare(b.name)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca la capacidad.",
                },
                {
                    whitespace: true,
                    message: "Introduzca la capacidad."
                }
            ]
        },
        {
            title: 'Tipo',
            dataIndex: 'type',
            width: '15%',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.type.localeCompare(b.type)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca el tipo de curso.",
                },
                {
                    whitespace: true,
                    message: "Introduzca el tipo de curso."
                }
            ],
        },
        {
            title: 'Precio',
            dataIndex: 'price',
            width: '15%',
            editable: true,
            dataType: 'number',
            sorter: {
                compare: (a, b) => a.price - b.price
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca el precio.",
                },
                {
                    whitespace: true,
                    message: "Introduzca el precio."
                }
            ]
        }
    ];

    const tableID = 'CoursesTable';
    const searchboxID = 'CoursesSearchbox';
    var operation = ["edit","delete","add","details"];

    if (isSecretary)
        operation = ["details"];

    return (
        <div>
            <NavBar></NavBar>
            <CRUD_Table 
                title={"Cursos"} 
                columns={columns} 
                operations={operation}
                url={"http://localhost:5145/api/Courses"}
                tableID={tableID}
                searchboxID={searchboxID}
                link={"../CourseDetails"}
            thereIsDropdown={false}
                        FormsInitialValues={{ key: "string" }}
            >
            </CRUD_Table>
        </div>
    );
};

export default Courses;