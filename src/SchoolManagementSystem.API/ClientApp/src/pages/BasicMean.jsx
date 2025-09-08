import React from "react";
import NavBar from "../components/NavBar/NavBar";
import CRUD_Table from "../components/Table/CRUD_Table";
import Login from "../components/Login/Login";
import {useState} from 'react';
import axios from "axios";


const BasicMean = () => {

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
                    message: "Introduzca el tipo",
                },
                {
                    whitespace: true,
                    message: "Introduzca el tipo"
                }
            ],
        },
        {
            title: 'Origen',
            dataIndex: 'origin',
            width: '15%',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.origin.localeCompare(b.origin)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca el origen",
                },
                {
                    whitespace: true,
                    message: "Introduzca el origen"
                }
            ]
        },
        {
            title: 'Devaluación en el tiempo',
            dataIndex: 'devaluationInTime',
            width: '15%',
            editable: true,
            dataType: 'number',
            sorter: {
                compare: (a, b) => a.devaluationInTime - b.devaluationInTime
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca la devaluación en el tiempo",
                },
                {
                    whitespace: true,
                    message: "Introduzca la devaluación en el tiempo"
                }
            ]
        },
        {
            title: 'Descripción',
            dataIndex: 'description',
            width: '15%',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.description.localeCompare(b.description)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca la descripción",
                },
                {
                    whitespace: true,
                    message: "Introduzca la descripción"
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
                    message: "Introduzca el precio",
                },
                {
                    whitespace: true,
                    message: "Introduzca el precio"
                }
            ]
        },
        {
            title: 'Fecha de inauguración',
            dataIndex: 'inaugurationDate',
            width: '15%',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.inaugurationDate.localeCompare(b.inaugurationDate)
            },
            rules: []
        }
    ];

    const tableID = 'BasicMeanTable';
    const searchboxID = 'BasicMeanSearchbox';

    return (
        <div>
            <NavBar></NavBar>
            <CRUD_Table 
                title={"Medios básicos"} 
                columns={columns} 
                operations={["edit","delete","add"]}
                url={"http://localhost:5145/api/BasicMean"}
                tableID={tableID}
                searchboxID={searchboxID}
            thereIsDropdown={false}
                        FormsInitialValues={{ key: "string" }}
            >
            </CRUD_Table>
        </div>
    );
}

export default BasicMean;