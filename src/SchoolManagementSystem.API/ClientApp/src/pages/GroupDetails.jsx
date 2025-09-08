import React from "react";
import NavBar from "../components/NavBar/NavBar";
import {Divider, Tabs} from "antd";
import { useParams } from "react-router-dom";
import CRUD_Table from "../components/Table/CRUD_Table";
import "./detailsHeader.css";
import {DeleteTwoTone, EditTwoTone} from "@ant-design/icons";
import Login from "../components/Login/Login";
import {useState} from 'react';
import axios from "axios";

const { TabPane } = Tabs;

const onChange = (key) => {
    console.log(key);
};

const GroupDetails = () => {
    const groupStudentsColumns = [
        {
            title: 'Carnet de identidad',
            dataIndex: 'key',
            editable: true,
            dataType: 'number',
            sorter: {
                compare: (a, b) => a.key - b.key
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca el carnet de identidad",
                },
                {
                    whitespace: true,
                    message: "Introduzca el carnet de identidad"
                }
            ]
        },
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
            title: 'Fecha de inscripción',
            dataIndex: 'startDate',
            dataType: 'text',
            editable: true,
            sorter: {
                compare: (a, b) => a.startDate.localeCompare(b.startDate)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca la fecha de inscripción",
                }
            ]
        }
    ];
    const groupStudentsTableID = 'groupStudentsTable';
    const groupStudentsSearchboxID = 'groupStudentsSearchbox';


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

    return (
        <div>
            <NavBar></NavBar>
            <Divider className={"detailsHeader"}>
                <strong>Nombre</strong> <Divider type="vertical" />
                Profesor <Divider type="vertical" />
                Capacidad <Divider type="vertical" />
                Cantidad actual de estudiantes <Divider type="vertical" />
                Fecha de inicio <Divider type="vertical" />
                Fecha de terminación
            </Divider>
                    <CRUD_Table title={"Estudiantes"}
                                columns={groupStudentsColumns}
                                operations={["edit","delete","add","details"]}
                                url={"http://localhost:5145/api/TeacherCourseRelation"}
                                tableID={groupStudentsTableID}
                                searchboxID={groupStudentsSearchboxID}
                                link={"../StudentDetails"}
                    thereIsDropdown={false}
                        FormsInitialValues={{ key: "string" }}
                    ></CRUD_Table>
        </div>
    );
};

export default GroupDetails;