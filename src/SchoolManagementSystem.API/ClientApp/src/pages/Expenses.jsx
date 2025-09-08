import React from "react";
import NavBar from "../components/NavBar/NavBar";
import CRUD_Table from "../components/Table/CRUD_Table";
import Login from "../components/Login/Login";
import {useState} from 'react';
import axios from "axios";

const Expenses = () => {

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
            title: 'Categoría',
            dataIndex: 'category',
            width: '15%',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.category.localeCompare(b.category)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca la categoría",
                },
                {
                    whitespace: true,
                    message: "Introduzca la categoría"
                }
            ],
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
            ]
        }
    ];

    const tableID = 'ExpensesTable';
    const searchboxID = 'ExpensesSearchbox';

    return (
        <div>
            <NavBar></NavBar>
            <CRUD_Table 
                title={"Gastos"} 
                columns={columns} 
                operations={["edit","delete","add"]}
                url={"http://localhost:5145/api/Expenses"}
                tableID={tableID}
                searchboxID={searchboxID}
            thereIsDropdown={false}
                        FormsInitialValues={{ key: "string" }}
            >
            </CRUD_Table>
        </div>
    );
};

export default Expenses;