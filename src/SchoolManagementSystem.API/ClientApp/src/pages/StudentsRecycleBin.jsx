import React from "react";
import NavBar from "../components/NavBar/NavBar";
import CRUD_Table from "../components/Table/CRUD_Table";
import Login from "../components/Login/Login";
import {useState} from 'react';
import axios from "axios";
import {Divider} from "antd";

const Students = () => {

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

    if (!loggedIn)
        window.location.replace("http://localhost:8080/");

    const columns = [
        {
            title: 'Nombre',
            dataIndex: 'name',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.name.localeCompare(b.name)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca el nombre.",
                },
                {
                    whitespace: true,
                    message: "Introduzca el nombre."
                }
            ]
        },
        {
            title: 'Apellidos',
            dataIndex: 'lastName',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.lastName.localeCompare(b.lastName)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca los apellidos.",
                },
                {
                    whitespace: true,
                    message: "Introduzca los apellidos."
                }
            ]
        },
        {
            title: 'Carnet de identidad',
            dataIndex: 'idCardNo',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.idCardNo.localeCompare(b.idCardNo)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca el carnet de identidad.",
                },
                {
                    whitespace: true,
                    message: "Introduzca el carnet de identidad."
                }
            ]
        },
        {
            title: 'Teléfono',
            dataIndex: 'phoneNumber',
            editable: true,
            dataType: 'number',
            sorter: {
                compare: (a, b) => a.phoneNumber - b.phoneNumber
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca el número de teléfono.",
                },
                {
                    whitespace: true,
                    message: "Introduzca el número de teléfono."
                }
            ]
        },
        {
            title: 'Dirección',
            dataIndex: 'address',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.address.localeCompare(b.address)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca la dirección.",
                },
                {
                    whitespace: true,
                    message: "Introduzca la dirección."
                }
            ]
        },
        {
            title: 'Grado de escolaridad',
            dataIndex: 'scholarityLevel',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.scholarityLevel.localeCompare(b.scholarityLevel)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca el grado de escolaridad.",
                },
                {
                    whitespace: true,
                    message: "Introduzca el grado de escolaridad."
                }
            ],
        },
        {
            title: 'Fecha de inicio en la sede',
            dataIndex: 'dateBecomedMember',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.dateBecomedMember.localeCompare(b.dateBecomedMember)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca la fecha de inicio en la sede.",
                },
                {
                    whitespace: true,
                    message: "Introduzca la fecha de inicio en la sede."
                }
            ]
        },
        {
            title: 'Fondos',
            dataIndex: 'founds',
            editable: true,
            dataType: 'number',
            sorter: {
                compare: (a, b) => a.founds - b.founds
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca los fondos.",
                },
                {
                    whitespace: true,
                    message: "Introduzca los fondos."
                }
            ]
        },
        {
            title: 'Nombre del tutor',
            dataIndex: 'tuitorName',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.tuitorName.localeCompare(b.tuitorName)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca el nombre del tutor.",
                },
                {
                    whitespace: true,
                    message: "Introduzca el nombre del tutor."
                }
            ],
        },
        {
            title: 'Teléfono del tutor',
            dataIndex: 'tuitorPhoneNumber',
            editable: true,
            dataType: 'number',
            sorter: {
                compare: (a, b) => a.tuitorPhoneNumber - b.tuitorPhoneNumber
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca el teléfono del tutor",
                },
                {
                    whitespace: true,
                    message: "Introduzca el teléfono del tutor"
                }
            ]
        }
    ];

    const tableID = 'RecycleBinStudentsTable';
    const searchboxID = 'RecycleBinStudentsSearchbox';

    return (
        <div>
            <NavBar></NavBar>
            <CRUD_Table
                title={"Estudiantes Bajas de la Sede"}
                columns={columns}
                operations={["restore"]}
                url={"http://localhost:5145/api/Students/Inactive"}
                restore_url={"http://localhost:5145/api/Students"}
                tableID={tableID}
                searchboxID={searchboxID}
                FormsInitialValues={{ key: "string" }}
            >
            </CRUD_Table>
        </div>
    );
}

export default Students;